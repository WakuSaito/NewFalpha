using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    //public Transform PlayerTransform;
    //public Transform Enemy04Transform;
    GameObject playerObj;

    public Vector2 EnemyPos;

    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p

    private bool moveOn = false;//�s���\�t���O

    public GameObject AttackEffect;//�N���[������I�u�W�F�N�g


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

                //�v���C���[�̂P�}�X��ɂ��邩�ǂ���
                if(transform.position == playerObj.transform.position + transform.up)
                {
                    //�U�������R���[�`���Ăяo��
                    StartCoroutine(Attack());
                }

                //���������R���[�`���Ăяo��
                StartCoroutine(Escape());
                time = 0.0f;

            }
        }
    }

    private IEnumerator Attack()
    {
        //�ҋ@
        yield return new WaitForSeconds(0.3f);

        //�U������
        //����̑O��(������)�ɍU���G�t�F�N�g�̃N���[������
        Instantiate(AttackEffect, transform.position + (transform.up * clonepos), Quaternion.identity);        
    }

    private IEnumerator Escape()
    {
        //�ҋ@
        yield return new WaitForSeconds(0.4f);

        //���̈ʒu�ɓ�����
        transform.position = EnemyPos;
    }
}
