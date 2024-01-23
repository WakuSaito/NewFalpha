using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    GameObject playerObj;

    private Vector2 EnemyPos;

    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p

    private bool moveOn = false;//�s���\�t���O

    EnemyAttack enemyAttack;//�U���p�X�N���v�g


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��
            Debug.Log("�s���\");
        }
    }

    private void Start()
    {
        playerObj = GameObject.Find("Player");
        EnemyPos = transform.position;

        enemyAttack = GetComponent<EnemyAttack>();

        //�ŏ��̍U���^�C�~���O�𗐐��ŏ����ς���
        time = Random.RandomRange(0.0f, coolTime / 2);
    }

    public void teleport()
    {
        //�v���C���[�̂P�}�X�O�Ɉړ�
        transform.position = playerObj.transform.position + transform.up;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moveOn)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                teleport();


                //�U�������R���[�`���Ăяo��
                StartCoroutine(AttackCt());


                //���������R���[�`���Ăяo��
                StartCoroutine(Escape());
                time = 0.0f;

            }
        }
    }

    private IEnumerator AttackCt()
    {
        //�ҋ@
        yield return new WaitForSeconds(0.4f);

        //�U������
        enemyAttack.Attack();
    }

    private IEnumerator Escape()
    {
        //�ҋ@
        yield return new WaitForSeconds(0.6f);

        //���̈ʒu�ɓ�����
        transform.position = EnemyPos;
    }
}
