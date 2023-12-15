using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool onUpdate = true;  //FixedUpdate�̒��g�����s���邩
    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f; //�U���̃N�[���^�C��
    public int attackType = 0;    //�ǂ̍U���_���[�W���Q�Ƃ��邩
    private float time = 0.0f;    //���Ԍv���p

    private bool moveOn = false;//�s���\�t���O

    public GameObject AttackEffect;//�N���[������v���n�u
    private GameObject cloneObj;   //�N���[�������I�u�W�F�N�g

    EnemyManager enemyManager;//�X�N���v�g

    private void Start()
    {
        //�ŏ��̍U���^�C�~���O�𗐐��ŏ����ς���
        time = Random.RandomRange(0.0f, coolTime / 2);

        //�X�N���v�g�擾
        enemyManager = gameObject.GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��
            Debug.Log("�s���\");
        }
    }


    private void FixedUpdate()
    {
        if (moveOn && onUpdate)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                Attack();//�U�������Ăяo��

                time = 0.0f;//���ԃ��Z�b�g
            }
        }
    }

    //�U�������֐�
    public void Attack()
    {
        //�w��̈ʒu�ɍU���G�t�F�N�g�̃N���[������
        cloneObj = Instantiate(AttackEffect, transform.position + (transform.up * clonepos), Quaternion.identity);

        if (enemyManager != null)
        {
            //�U���G�t�F�N�g�̃_���[�W���l��ύX����
            cloneObj.GetComponent<EffectData>().damage = enemyManager.status.GetAttackDamage(attackType);
        }
        
    }
    //�ʒu�w��I�[�o�[���[�h
    public void Attack(Vector3 pos)
    {
        //�w��̈ʒu�ɍU���G�t�F�N�g�̃N���[������
        cloneObj = Instantiate(AttackEffect, pos, Quaternion.identity);

        if (enemyManager != null)
        {
            //�U���G�t�F�N�g�̃_���[�W���l��ύX����
            cloneObj.GetComponent<EffectData>().damage = enemyManager.status.GetAttackDamage(attackType);
        }

    }
}
