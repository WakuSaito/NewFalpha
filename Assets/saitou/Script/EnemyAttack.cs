using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f; //�U���̃N�[���^�C��
    public int attackType = 0;    //�ǂ̍U���_���[�W���Q�Ƃ��邩
    public float time = 0.0f;    //���Ԍv���p

    private bool moveOn = false;//�s���\�t���O

    public GameObject[] AttackEffect = new GameObject[2];//�N���[������v���n�u
    private GameObject cloneObj;   //�N���[�������I�u�W�F�N�g
    private GameObject objCanvas; //�L�����o�X�̃I�u�W�F�N�g

    EnemyManager enemyManager;//�X�N���v�g
    enemyAttackTypeChange enemyattacktypechange;//�X�N���v�g
    BossHPBarACTIVE active_boss_hpbar;//�X�N���v�g

    private void Start()
    {
        //�ŏ��̍U���^�C�~���O�𗐐��ŏ����ς���
        time = Random.RandomRange(0.0f, coolTime / 2);

        objCanvas = GameObject.Find("Canvas");

        //�X�N���v�g�擾
        //enemyManager = gameObject.GetComponent<EnemyManager>();
        enemyattacktypechange = gameObject.GetComponent<enemyAttackTypeChange>();
        active_boss_hpbar = objCanvas.GetComponent<BossHPBarACTIVE>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��

            if (GameObject.FindWithTag("Boss"))
            {   //BossHPBar��\��������
                active_boss_hpbar.ActiveBossHPBar();
                Debug.Log("BossHP");
            }
            Debug.Log("�s���\");
        }
    }


    private void FixedUpdate()
    {
        if (moveOn)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                Attack();//�U�������Ăяo��

                // Boss01�Ȃ炱�̊֐��̒��ɓ���
                if( gameObject.name == "Boss01(Clone)")
                    enemyattacktypechange.Boss01AttackChange();

                time = 0.0f;//���ԃ��Z�b�g
            }
        }
    }

    //�U�������֐�
    public void Attack()
    {
        enemyManager = gameObject.GetComponent<EnemyManager>();

        //�w��̈ʒu�ɍU���G�t�F�N�g�̃N���[������
        cloneObj = Instantiate(AttackEffect[attackType], transform.position + (transform.up * clonepos), Quaternion.identity);

        if (enemyManager != null)
        {
            //�U���G�t�F�N�g�̃_���[�W���l��ύX����
            cloneObj.GetComponent<EffectData>().damage = enemyManager.status.GetAttackDamage(attackType);
        }
    }

    //�ʒu�w��I�[�o�[���[�h
    public void Attack(Vector3 pos)
    {
        enemyManager = gameObject.GetComponent<EnemyManager>();

        //�w��̈ʒu�ɍU���G�t�F�N�g�̃N���[������
        cloneObj = Instantiate(AttackEffect[attackType], pos, Quaternion.identity);

        if (enemyManager != null)
        {
            //�U���G�t�F�N�g�̃_���[�W���l��ύX����
            cloneObj.GetComponent<EffectData>().damage = enemyManager.status.GetAttackDamage(attackType);
        }
    }

}
