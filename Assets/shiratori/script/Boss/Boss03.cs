using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03 : EnemyAttack
{
    public GameObject playerObj;
    public float TPcoolTime = 1.5f;
    private float ATtime = 0.0f;

    private bool moveOn = false;//�s���\�t���O

    //public GameObject[] AttackEffect = new GameObject[2];//�N���[������v���n�u
    private GameObject objCanvas; //�L�����o�X�̃I�u�W�F�N�g

    enemyAttackTypeChange enemyattacktypechange;//�X�N���v�g
    BossHPBarACTIVE active_boss_hpbar;//�X�N���v�g

    private void Start()
    {
        //�ŏ��̍U���^�C�~���O�𗐐��ŏ����ς���
        time = Random.RandomRange(0.0f, coolTime / 2);

        objCanvas = GameObject.Find("Canvas");
        playerObj = GameObject.Find("Player");

        //�X�N���v�g�擾
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
            ATtime += 0.02f;

            //time���N�[���^�C���𒴂�����
            if (time >= TPcoolTime)
            {
                teleport();

                time = 0.0f;

            }
            if (ATtime >= coolTime)
            {
                //�U�������R���[�`���Ăяo��
                StartCoroutine(AttackCt());

                ATtime = 0.0f;
            }
        }
    }

    private  void teleport()
    {
        //�v���C���[�̂P�}�X�O�Ɉړ�
        transform.position = playerObj.transform.position + transform.up;
    }

    private IEnumerator AttackCt()
    {
        //�ҋ@
        yield return new WaitForSeconds(1.0f);

        //�U������
        Attack();

        enemyattacktypechange.Boss03AttackChange();
    }
}
