using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class PlayerManager : MonoBehaviour
    {
    public float swordDamage;
    public float syurikenDamage;//��ō폜�iBossManager��������j

    public float speed = 1.0f;       //�ړ�����
    public float shotSpeed = 0.2f;   //�藠���̑��x
    public float takesDamage = 2.0f; //��_���[�W
    
    public float effectLimit;       //�ߋ����U���̔��肪�c�鎞��
    public float shotLimit = 3.5f;  //�������U���̔򋗗��̏��
    public float shotLange;         //�������U���̔򋗗�
    public float attackCooltime = 0.3f;//�ߋ����U���N�[���^�C��
    public float shotCooltime = 0.3f;  //�������U���N�[���^�C��

    public float leftLimit = 0.0f;  //�N���ł��鍶�̌��E
    public float rightLimit = 4.0f; //�N���ł���E�̌��E
    public float upLimit = 21.0f;   //�N���ł����̌��E
    public float backLimitArea = 19.0f; //��ނɐ���������͈�(�ȉ�) CreateMap�œK�X�X�V
    public float invincibleTime = 0.5f; //���G����

    public bool dontMove = false;    //�ړ��ł��Ȃ�����t���O
    private string lastMove = "down";//�Ō�ɓ���������
    bool onAttack = false;           //�ߋ����U���t���O
    bool onShot = false;             //�������U���t���O
    bool onBottomColumn = false;     //����ɂ��邩�ǂ���
    bool invincible = false;         //���G�t���O

    private float time; //���Ԍv���p

    //�F
    Color mainColor   = new Color(1f, 1f, 1f, 1f);     //�ʏ펞
    Color damageColor = new Color(1f, 0.6f, 0.6f, 1f); //��_���[�W��
    Color inviColor   = new Color(1f, 1f, 1f, 0.5f);   //���G��

    Vector2 position; //�v���C���[�̍��W�p
    public GameObject AttackEffect;  //�ߋ����U��
    public GameObject ShotEffect;    //�������U��
    public GameObject ghostPrefab;   //�c���p�̃v���n�u
    private GameObject camera;       //Main Camera�I�u�W�F�N�g

    private PlayerStatusManager playerStatus;//PlayerStatusManager�X�N���v�g
    private TresureBoxManager tresureBox;    //TresureBoxManager�X�N���v�g
    private TraderManager traderManager;     //TraderManager�X�N���v�g
    private SceneChange sceneChange;         //SceneChange�X�N���v�g
    private Sounds sounds;

    void Start()
    {
        playerStatus = LoadManagerScene.GetPlayerStatusManager();

        camera = GameObject.Find("Main Camera"); //�J�����̎擾

        GameObject obj = GameObject.Find("SoundObject");
        sounds = obj.GetComponent<Sounds>();

        //�v���C���[���W�̎擾
        position = transform.position;
    }

    // Update is called once per frame

    void Update()
    {
        //�ړ��s�t���O�𒲂ׂ�
        if (dontMove == false)
        {
            //�ړ�(��O�ɂ����Ȃ��悤�ɂ���)
            if ((Input.GetKeyDown("left") ||
                Input.GetKeyDown(KeyCode.A)) &&
                position.x > leftLimit)
            {
                CloneAfterimage();
                position.x -= speed;
                lastMove = "left";
            }
            if ((Input.GetKeyDown("right") ||
                Input.GetKeyDown(KeyCode.D)) &&
                position.x < rightLimit)
            {
                CloneAfterimage();
                position.x += speed;
                lastMove = "right";
            }
            if ((Input.GetKeyDown("up") ||
                Input.GetKeyDown(KeyCode.W)) &&
                position.y < upLimit)
            {
                CloneAfterimage();
                position.y += speed;
                lastMove = "up";

                //�J�����̈ړ����������ł���
                if (onBottomColumn == false && transform.position.y < backLimitArea)
                {
                    MoveCamera();//�J�����̍��W�X�V
                }
                onBottomColumn = false;
            }
            if ((Input.GetKeyDown("down") ||
                Input.GetKeyDown(KeyCode.S)) &&
                !onBottomColumn)
            {
                CloneAfterimage();
                position.y -= speed;
                lastMove = "down";
                //�{�X�G���A����O�Ȃ�
                if (transform.position.y <= backLimitArea)
                    onBottomColumn = true;  //��ގ��ɉ���ɂ��邱�Ƃɂ���
            }
        }

        //�t���O�`�F�b�N
        if (!dontMove && !onAttack && !onShot)
        {

            //�ߋ����U��
            //if (Input.GetKeyDown(KeyCode.Space))//�U���J�n��(Space�L�[�������ƍU���J�n)
            if(Input.GetMouseButtonDown(1))//�E�N���b�N�������ꂽ�Ƃ�
            {
                //�v���C���[�̑O���ɍU���G�t�F�N�g�̃N���[������
                Instantiate(AttackEffect, transform.position + transform.up, Quaternion.identity);

                //�t���O�Ǘ��p�R���[�`���Ăяo��
                StartCoroutine(AttackFlag());
            }

            //�������U��
            //if (Input.GetKeyDown(KeyCode.LeftShift))//�U���J�n��(Space�L�[�������ƍU���J�n)
            if (Input.GetMouseButtonDown(0))//���N���b�N�������ꂽ�Ƃ�
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.DrawRay(transform.position + (transform.up * 0.5f), transform.up * 0.8f, Color.green, 0.5f);

                Debug.Log("���ׂ�");

                //�v���C���[�̏ォ��A����𒲂ׂ�
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * 1.5f, 0.8f);

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

                        //�X�N���v�g���擾
                        tresureBox = hit.collider.gameObject.GetComponent<TresureBoxManager>();

                        tresureBox.OpenBox();//�󔠂̃X�N���v�g�����s
                    }
                    //���ׂ��������l�Ȃ�
                    else if (hit.collider.CompareTag("Trader"))
                    {
                        Debug.Log("���l��");

                        //�X�N���v�g���擾
                        traderManager = hit.collider.gameObject.GetComponent<TraderManager>();

                        traderManager.OpenShop();//���l�̃X�N���v�g�����s
                    }
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
        //���G���ԂłȂ����
        if (invincible == false)
        {
            //�ڐG�^�O���G�̍U���Ȃ�
            if (collision.gameObject.tag == "EnemyAttack")
            {
                sounds.DamageSE();//SE ��_���[�W
                StartCoroutine( DamageEfect());//��_���[�W�G�t�F�N�g

                takesDamage = collision.GetComponent<EffectData>().damage;//���������U������_���[�W���擾

                //��_���[�W�֐����ĂсAfalse���Ԃ��Ă����Ȃ� ( HP��0�ȉ���false )
                if (playerStatus.TakeDamage(takesDamage) == false)
                {
                    //�v���C���[���|���
                    PlayerDead();
                }

            }
            //�ڐG�^�O���G�{�̂Ȃ�
            if (collision.gameObject.tag == "Enemy")
            {
                sounds.DamageSE();//SE ��_���[�W

                takesDamage = 10f;//�Ԃ������Ƃ��̃_���[�W�͌Œ�

                //��_���[�W�֐����ĂсAfalse���Ԃ��Ă����Ȃ� ( HP��0�ȉ���false )
                if (playerStatus.TakeDamage(takesDamage) == false)
                {
                    //�v���C���[���|���
                    PlayerDead();
                }
                StartCoroutine( Knockback());
                //���G����
                StartCoroutine(OnInvincible(invincibleTime));
            }
        }
    }

    //�ߋ����U���t���O�Ǘ�
    private IEnumerator AttackFlag()
    {
        onAttack = true;

        //SE �ߋ����U��
        sounds.AttackSE();
        

        //�ҋ@
        yield return new WaitForSeconds(attackCooltime);

        onAttack = false;
    }
    //�������U���t���O�Ǘ�
    private IEnumerator ShotFlag()
    {
        onShot = true;

        //SE �������U��
        sounds.ShotSE();

        //�ҋ@
        yield return new WaitForSeconds(shotCooltime);

        onShot = false;
    }

    //�v���C���[�����ꂽ�Ƃ��֐�
    void PlayerDead()
    {
        Debug.Log("���ꂽ");

        sounds.GameOverSE();//SE �Q�[���I�[�o�[

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

        sounds.MoveSE();//SE �ړ�
    }

    public void ResetPos(Vector2 pos)
    {
        position = pos;
    }
    //�v���C���[�̂�����֐�
    public IEnumerator Knockback()
    {
        Debug.Log("�̂�����");

        dontMove = true;

        //�F��ύX
        gameObject.GetComponent<SpriteRenderer>().color = inviColor;

        //SE ��_���[�W

        yield return new WaitForSeconds(0.1f);

        //�Ō�Ɉړ����������Ƌt�����̃x�N�g�����w��
        switch (lastMove)
        {
            case "left":
                position += Vector2.right;
                break;
            case "right":
                position += Vector2.left;
                break;
            case "up":
                position += Vector2.down;
                onBottomColumn = true;
                break;
            case "down":
                position += Vector2.up;
                onBottomColumn = false;
                break;
            default:
                Debug.Log("!�ŏI�ړ�������������܂���B");
                break;
        }
        //�A���ł̂��������ꍇ�A�X�e�[�W�O�ɏo�����Ȃ̂Œ��g������
        lastMove = null;

        transform.position = position;  //���W�̍X�V   

        yield return new WaitForSeconds(0.3f);

        dontMove = false;
        
    }
    //��莞�Ԗ��G�R���[�`�� �����b���G
    public IEnumerator OnInvincible(float sec)
    {
        invincible = true;  //���G�ɂȂ�
        
        //�F�ύX
        //gameObject.GetComponent<SpriteRenderer>().color = inviColor;       

        yield return new WaitForSeconds(sec);

        invincible = false; //���G����
        //�F��߂�
        gameObject.GetComponent<SpriteRenderer>().color = mainColor;
    }
    //�J�����̍��W�X�V
    public void MoveCamera()
    {
        camera.transform.position = new Vector3(2, transform.position.y + 1.6f, -10);
    }
    //��_���[�W�G�t�F�N�g
    public IEnumerator DamageEfect()
    {
        //�F�ύX
        gameObject.GetComponent<SpriteRenderer>().color = damageColor;

        //SE�@��_���[�W

        yield return new WaitForSeconds(0.1f);

        //�F��߂�
        gameObject.GetComponent<SpriteRenderer>().color = mainColor;
    }
}



