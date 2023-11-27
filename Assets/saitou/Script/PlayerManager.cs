using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class PlayerManager : MonoBehaviour
    {
    public float swordDamage;
    public float syurikenDamage;//��ō폜�iBossManager��������j

    public float speed = 1.0f;      //�ړ�����
    public float shotSpeed = 0.2f;  //�藠���̑��x
    public float takesDamage = 2.0f;  //��_���[�W
    
    public float effectLimit;       //�ߋ����U���̔��肪�c�鎞��
    public float shotLimit = 3.5f;  //�������U���̔򋗗��̏��
    public float shotLange;        //�������U���̔򋗗�
    public float attackCooltime = 0.3f;//�ߋ����U���N�[���^�C��
    public float shotCooltime = 0.3f;  //�������U���N�[���^�C��

    public float leftLimit = 0.0f;  //�N���ł��鍶�̌��E
    public float rightLimit = 4.0f; //�N���ł���E�̌��E
    public float upLimit = 21.0f;   //�N���ł����̌��E
    public float backLimitArea = 19.0f; //��ނɐ���������͈�(�ȉ�) CreateMap�œK�X�X�V

    bool onAttack = false;      //�ߋ����U���t���O
    bool onShot = false;        //�������U���t���O
    bool onBottomColumn = false; //����ɂ��邩�ǂ���


    private float time; //���Ԍv���p

    Vector2 position; //�v���C���[�̍��W�p
    public GameObject AttackEffect;  //�ߋ����U��
    public GameObject ShotEffect;    //�������U��
    public GameObject ghostPrefab;   //�c���p�̃v���n�u
    public BarrierManager barrierbar;//BarrierManager�X�N���v�g
    private GameObject dataInfo;     //DataInfo�I�u�W�F�N�g
    private GameObject camera;       //Main Camera�I�u�W�F�N�g
    private PlayerStatusManager playerStatus;//PlayerStatusManager�X�N���v�g
    private TresureBoxManager tresureBox;    //TresureBoxManager�X�N���v�g
    private SceneChange sceneChange;         //SceneChange�X�N���v�g

    void Start()
    {
        playerStatus = LoadManagerScene.GetPlayerStatusManager();

        camera = GameObject.Find("Main Camera"); //�J�����̎擾

        //�v���C���[���W�̎擾
        position = transform.position;
    }

    // Update is called once per frame

    void Update()
    {

        //�ړ�(��O�ɂ����Ȃ��悤�ɂ���)
        if ((Input.GetKeyDown("left") ||
            Input.GetKeyDown(KeyCode.A)) &&
            position.x > leftLimit)
        {
            CloneAfterimage();
            position.x -= speed;
        }
        if ((Input.GetKeyDown("right") ||
            Input.GetKeyDown(KeyCode.D)) &&
            position.x < rightLimit)
        {
            CloneAfterimage();
            position.x += speed;
        }
        if ((Input.GetKeyDown("up") ||
            Input.GetKeyDown(KeyCode.W)) &&
            position.y < upLimit)
        {
            CloneAfterimage();
            position.y += speed;

            //�J�����̈ړ����������ł���
            if(onBottomColumn == false && transform.position.y < backLimitArea)
            {
                //�J�����̍��WY��+1
                camera.transform.position += transform.up;
            }
            onBottomColumn = false;
        }
        if ((Input.GetKeyDown("down") ||
            Input.GetKeyDown(KeyCode.S)) &&
            !onBottomColumn)
        {
            CloneAfterimage();
            position.y -= speed;
            //�{�X�G���A����O�Ȃ�
            if(transform.position.y <= backLimitArea)
                onBottomColumn = true;  //��ގ��ɉ���ɂ��邱�Ƃɂ���
        }
        


        

        //�ߋ����U��
        if (Input.GetKeyDown(KeyCode.Space) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //�v���C���[�̑O���ɍU���G�t�F�N�g�̃N���[������
            Instantiate(AttackEffect, transform.position + transform.up, Quaternion.identity);

            //�t���O�Ǘ��p�R���[�`���Ăяo��
            StartCoroutine(AttackFlag());
        }

        //�������U��
        if (Input.GetKeyDown(KeyCode.LeftShift) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //���݂����ɂ���Ĕ򋗗���ύX
            if (onBottomColumn)
                shotLange = shotLimit;
            else
                shotLange = shotLimit - 1.0f;

            //�t���O�Ǘ��p�R���[�`���Ăяo��
            StartCoroutine(ShotFlag());

            //�v���C���[�̈ʒu�Ɏ藠���̃N���[������
            Instantiate(ShotEffect, transform.position, Quaternion.identity);
        }

        //�O���𒲂ׂ�
        if (Input.GetKeyDown(KeyCode.E) &&
            !onAttack && !onShot)
        {
            Debug.DrawRay(transform.position + (transform.up * 0.5f),  transform.up * 0.8f, Color.green, 0.5f);

            Debug.Log("���ׂ�");

            //�v���C���[�̏ォ��A����𒲂ׂ�
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.up * 0.5f), Vector2.up, 0.8f);

            if (hit.collider != null)
            {
                if (hit.collider)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }

                //���ׂ������󔠂Ȃ�
                if (hit.collider.CompareTag("TreasureBox"))
                {
                    Debug.Log("�󔠂�");
                    //�󔠂̃X�N���v�g�����s
                    tresureBox = hit.collider.gameObject.GetComponent<TresureBoxManager>();

                    tresureBox.OpenBox();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position = position;  //���W�̍X�V
    }

    //�G�ȂǂƂ̐ڐG���̃_���[�W����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ڐG�^�O���G�̍U�����A�G�{�̂Ȃ�HP�����炷
        if(collision.gameObject.tag == "EnemyAttack"|| collision.gameObject.tag == "Enemy")
        {
            //��_���[�W�֐����ĂсAfalse���Ԃ��Ă����Ȃ� ( HP��0�ȉ���false )
            if (playerStatus.TakeDamage(takesDamage) == false)
            {
                //�v���C���[���|���
                PlayerDead();
            }                
        }
    }

    //�ߋ����U���t���O�Ǘ�
    private IEnumerator AttackFlag()
    {
        onAttack = true;

        //�ҋ@
        yield return new WaitForSeconds(attackCooltime);

        onAttack = false;
    }
    //�������U���t���O�Ǘ�
    private IEnumerator ShotFlag()
    {
        onShot = true;

        //�ҋ@
        yield return new WaitForSeconds(shotCooltime);

        onShot = false;
    }

    //�v���C���[�����ꂽ�Ƃ��֐�
    void PlayerDead()
    {
        Debug.Log("���ꂽ");
        Destroy(gameObject, 0.4f);

        //SeneChange�X�N���v�g��T���A�Q�[���I�[�o�[�V�[���Ɉڍs
        sceneChange = camera.GetComponent<SceneChange>();
        sceneChange.GameOver();
    }

    //�c�������֐�
    void CloneAfterimage()
    {
        //���̃I�u�W�F�N�g�̈ʒu�Ɏc���𐶐�
        GameObject ghost =
            Instantiate(ghostPrefab, transform.position, transform.rotation);
    }

    public void ResetPos(Vector2 pos)
    {
        position = pos;
    }
}



