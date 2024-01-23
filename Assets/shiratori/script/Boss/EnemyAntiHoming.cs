using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAntiHoming : MonoBehaviour
{
    public GameObject playerObj;
    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    public float TPcoolTime = 1.5f;
    private float time = 0.0f;//���Ԍv���p
    private float ATtime = 0.0f;

    private bool moveOn = false;//�s���\�t���O

    EnemyAttack enemyAttack;//�U���p�X�N���v�g
    enemyAttackTypeChange enemyattacktypechange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��
            Debug.Log("�s���\");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");

        enemyAttack = GetComponent<EnemyAttack>();
        enemyattacktypechange = GetComponent<enemyAttackTypeChange>();


    }

    // Update is called once per frame
    void FixedUpdate()
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
            if(ATtime >= coolTime)
            {
                //�U�������R���[�`���Ăяo��
                StartCoroutine(AttackCt());

                ATtime = 0.0f;
            }
        }
    }

    public void teleport()
    {
        //�v���C���[�̂P�}�X�O�Ɉړ�
        transform.position = playerObj.transform.position + transform.up;
    }

    private IEnumerator AttackCt()
    {
        //�ҋ@
        yield return new WaitForSeconds(1.0f);

        //�U������
        enemyAttack.Attack();

        enemyattacktypechange.Boss03AttackChange();
    }
}
