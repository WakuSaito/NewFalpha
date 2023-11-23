using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̃X�e�[�^�X�Ǘ��N���X
public class PlayerStatusManager : MonoBehaviour
{
    //�X�e�[�^�X�̏������p
    [SerializeField] private float maxHP;       //�ő�̗�      
    [SerializeField] private float attackDamage;//�ߋ����U���_���[�W
    [SerializeField] private float shotDamage;  //�������U���_���[�W
    [SerializeField] private int criChance;     //�N���e�B�J����
    [SerializeField] private float criDamage;   //�N���e�B�J���_���[�W
    [SerializeField] private int initialMoney;  //����������
    [SerializeField] private float[] barrier = new float[5];  //�o���A�̔{�� �ŏ��͗v�f0��

    public bool onResetHpBr = false;    //�̗́A�o���A���Z�b�g������
    public PlayerStatusData status;     //�v���C���[�̃X�e�[�^�X�i�[�p
    public StatusCalc statusCalc = new StatusCalc();  //�X�e�[�^�X�v�Z�p

    // Start is called before the first frame update
    void Start()
    {
        //�X�e�[�^�X�̏�����
        status = new PlayerStatusData(maxHP, initialMoney, attackDamage, shotDamage, barrier[0], criChance, criDamage);

        Debug.Log("maxHP" + status.MaxHP);
    }

    //�����l���֐�
    public void GettingMoney(int money)
    {
        Debug.Log("�����擾");
        status.Money += statusCalc.MoneyCalc(money);
    }

    //�_���[�W���󂯂�֐�
    public bool TakeDamage(float damage)
    {
        Debug.Log("�_���[�W��H�����");

        //HP�v�Z�֐����Ă�ŁA���ݑ̗͂��X�V
        status.CurrentHP = statusCalc.HPCalc(status.CurrentHP, damage, status.Barrier);

        //HP���O�ȉ���������false��Ԃ�
        //���ڃV�[����ύX���Ă�����
        if (status.CurrentHP <= 0)
            return false;
        else
            return true;
    }

    //�ߋ����U���̃_���[�W�v�Z�֐�
    public float AttackDamageCalc()
    {
        //AttackDamage[0]�������Ƃ��āA�_���[�W�v�Z�֐����Ă�
        return statusCalc.DamageCalc(status.GetAttackDamage(0), status.CriChance, status.CriDamage);
    }

    //�������U���̃_���[�W�v�Z�֐�
    public float ShotDamageCalc()
    {
        //AttackDamage[1]�������Ƃ��āA�_���[�W�v�Z�֐����Ă�
        return statusCalc.DamageCalc(status.GetAttackDamage(1), status.CriChance, status.CriDamage);
    }

    //�o���A�̔{���X�V�֐�
    public void ChangeBarrier(int n)
    {
        //�󂯎���������Ԗڂ̗v�f�ɍX�V
        status.Barrier = barrier[n];
    }
    //�̗́A�o���A���Z�b�g�֐�
    public void ResetHpBr()
    {
        status.CurrentHP = status.MaxHP;
        status.Barrier = barrier[0];

        onResetHpBr = true;//�o���A�Q�[�W�̏������p
    }
}

