using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Start is called before the first frame update
public class PlayerClone : MonoBehaviour
{
    public float speed = 1.0f;      //�ړ�����
    public float shotSpeed = 0.2f;  //�藠���̑��x
    public float takesDamage = 2.0f;  //��_���[�W

    public float effectLimit;       //�ߋ����U���̔��肪�c�鎞��
    public float shotLimit = 3.5f;  //�������U���̔򋗗��̏��
    public float shotLange;        //�������U���̔򋗗�
    public float attackCooltime = 0.3f;//�ߋ����U���N�[���^�C��
    public float shotCooltime = 0.3f;  //�������U���N�[���^�C��

    public float upLimit = 21.0f;   //�N���ł����̌��E
    public float backLimitArea = 19.0f; //��ނɐ���������͈�(�ȉ�) CreateMap�œK�X�X�V

    bool onAttack = false;          //�ߋ����U���t���O
    bool onShot = false;            //�������U���t���O
    bool onBottomColumn = false;    //����ɂ��邩�ǂ���


    private float time; //���Ԍv���p

    Vector2 position; //�v���C���[�̍��W�p
    public GameObject AttackEffect;  //�ߋ����U��
    public GameObject ShotEffect;    //�������U��

    PlayerManager playerManager;

    void Start()
    {
        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();

        //�v���C���[���W�̎擾
        position = transform.position;
    }

    // Update is called once per frame

    void Update()
    {
        //�ړ��s�t���O�𒲂ׂ�
        if (playerManager.dontMove == false)
        {
            //�ړ�(��O�ɂ����Ȃ��悤�ɂ���)
            if (Input.GetKeyDown("left") ||
                Input.GetKeyDown(KeyCode.A))
            {

                position.x -= speed;
            }
            if (Input.GetKeyDown("right") ||
                Input.GetKeyDown(KeyCode.D))
            {

                position.x += speed;
            }
            if ((Input.GetKeyDown("up") ||
                Input.GetKeyDown(KeyCode.W)) &&
                position.y < upLimit)
            {

                position.y += speed;

                onBottomColumn = false;
            }
            if ((Input.GetKeyDown("down") ||
                Input.GetKeyDown(KeyCode.S)) &&
                !onBottomColumn)
            {
                position.y -= speed;
                //�{�X�G���A����O�Ȃ�
                if (transform.position.y <= backLimitArea)
                    onBottomColumn = true;  //��ގ��ɉ���ɂ��邱�Ƃɂ���
            }
        }


        //�ߋ����U��
        //if (Input.GetKeyDown(KeyCode.Space) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        if (Input.GetMouseButtonDown(1))//�E�N���b�N�������ꂽ�Ƃ�

        {
            //�v���C���[�̑O���ɍU���G�t�F�N�g�̃N���[������
            Instantiate(AttackEffect, transform.position + transform.up, Quaternion.identity);

            //�t���O�Ǘ��p�R���[�`���Ăяo��
            StartCoroutine(AttackFlag());
        }

        //�������U��
        //if (Input.GetKeyDown(KeyCode.LeftShift) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
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
    }

    private void FixedUpdate()
    {
        transform.position = position;  //���W�̍X�V
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
}