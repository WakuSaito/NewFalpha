using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update
    public class PlayerManager : MonoBehaviour
    {
    public float speed = 1.0f;      //�ړ�����
    public float shotSpeed = 0.2f;  //�藠���̑��x
    public float playerHP = 4.0f;   //�v���C���[�̗̑�
    public float barrierCur = 2.0f;  //���݂̃o���A�l
    public float takesDamage = 2.0f;  //��_���[�W
    
    public float effectLimit;       //�ߋ����U���̔��肪�c�鎞��
    public float shotLimit = 3.5f;  //�������U���̔򋗗��̏��
    public float shotLange;        //�������U���̔򋗗�
    public float swordDamage = 2.0f;     //�ߋ����U���_���[�W
    public float syurikenDamage = 1.5f;  //�������U���_���[�W

    public float leftLimit = 1.0f;  //�N���ł��鍶�̌��E
    public float rightLimit = 5.0f; //�N���ł���E�̌��E
    public float upLimit = 20.0f;   //�N���ł����̌��E

    bool onAttack = false;      //�ߋ����U���t���O
    bool onShot = false;        //�������U���t���O
    bool onBottomColumn = true; //����ɂ��邩�ǂ���
    private float time; //���Ԍv���p

    public GameObject AttackEffect;  //�ߋ����U��
    public GameObject ShotEffect;    //�������U��
    public GameObject ghostPrefab;   //�c���p�̃v���n�u
    public HPBar hpbar;              //HPBar�X�N���v�g
    public BarrierManager barrierbar;//BarrierManager�X�N���v�g

    void Start()
    {
        barrierCur = 2.0f;
    }

    // Update is called once per frame

    void Update()
    {
        //�v���C���[���W�̎擾
        Vector2 position = transform.position;

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
            onBottomColumn = false;
        }
        if ((Input.GetKeyDown("down") ||
            Input.GetKeyDown(KeyCode.S)) &&
            !onBottomColumn)
        {
            CloneAfterimage();
            position.y -= speed;
            //�{�X�G���A����O�Ȃ�
            if(transform.position.y < 19.0f)
                onBottomColumn = true;  //��ގ��ɉ���ɂ��邱�Ƃɂ���
        }
        

        transform.position = position;  //���W�̍X�V

        //�ߋ����U��
        if (Input.GetKeyDown(KeyCode.Space) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //�v���C���[�̑O���ɍU���G�t�F�N�g�̃N���[������
            Instantiate(AttackEffect, transform.position + transform.up, Quaternion.identity);

            time = 0.0f;        //���Ԃ̃��Z�b�g
            onAttack = true;    //�U���t���O�I��
        }

        //�������U��
        if (Input.GetKeyDown(KeyCode.LeftShift) && !onAttack && !onShot)//�U���J�n��(Space�L�[�������ƍU���J�n)
        {
            //���݂����ɂ���Ĕ򋗗���ύX
            if (onBottomColumn)
                shotLange = shotLimit;
            else
                shotLange = shotLimit - 1.0f;

            //�v���C���[�̈ʒu�Ɏ藠���̃N���[������
            Instantiate(ShotEffect, transform.position, Quaternion.identity);

            time = 0.0f;        //���Ԃ̃��Z�b�g
            onShot = true;      //�U���t���O�I��
        }

    }

        private void FixedUpdate()
        {
        //�ߋ����U������
        if (onAttack)
        {
            //�P�b��1.0f���₷
            time += 0.02f;

            //time���w�肵�����Ԉȏ�ɂȂ��
            if (time >= effectLimit)
            {
                //�U���t���O��������
                onAttack = false;
            }
        }

        //�������U������
        if (onShot)
        {
            //time�𑬓x�Ɠ����������₷
            time += shotSpeed;

            //time���w�肵�����Ԉȏ�ɂȂ��
            if (time >= shotLange)
            {
                //�U���t���O��������
                onShot = false;
            }
        }
        barrierbar.UpdateBarrier();
        }

    //�G�ȂǂƂ̐ڐG���̃_���[�W����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ڐG�^�O���G�̍U�����A�G�{�̂Ȃ�HP�����炷
        if(collision.gameObject.tag == "EnemyAttack"|| collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�_���[�W��H�����");
            playerHP -= ( takesDamage / barrierCur );   //�v���C���[�̗̑͂����炷�i��ŉE��ύX�j

            //HPBar�̌Ăяo��
            hpbar.UpdateHP(playerHP);

            PlayerDead();       //�v���C���[���|��邩�`�F�b�N
        }
    }

    //�v���C���[�����ꂽ�Ƃ��֐�
    void PlayerDead()
    {
        if (playerHP <= 0)
        {
            Debug.Log("���ꂽ");
            Destroy(gameObject, 0.4f);
        }
    }

    //�c�������֐�
    void CloneAfterimage()
    {
        //���̃I�u�W�F�N�g�̈ʒu�Ɏc���𐶐�
        GameObject ghost =
            Instantiate(ghostPrefab, transform.position, transform.rotation);
    }
}



