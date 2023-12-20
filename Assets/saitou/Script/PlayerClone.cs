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

    public float upLimit = 21.0f;       //�N���ł����̌��E
    public float backLimitArea = 19.0f; //��ނɐ���������͈�(�ȉ�) CreateMap�œK�X�X�V

    public Vector3 clonePos; //�N���[�������猩�Ăǂ̈ʒu��

    bool onAttack = false;          //�ߋ����U���t���O
    bool onShot = false;            //�������U���t���O
    bool onBottomColumn = false;    //����ɂ��邩�ǂ���


    private float time; //���Ԍv���p

    public GameObject AttackEffect;  //�ߋ����U��
    public GameObject ShotEffect;    //�������U��
    GameObject baseObj; //�N���[�����̐e�I�u�W�F�N�g

    PlayerManager playerManager;

    void Start()
    {
        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();


        //�e�I�u�W�F�N�g�̎擾
        baseObj = transform.parent.gameObject;
    }

    // Update is called once per frame

    void Update()
    {
        //�t���O�`�F�b�N
        if (!onAttack && !onShot)
        {


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
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = baseObj.transform.position + clonePos;
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