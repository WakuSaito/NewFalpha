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
    public float addAttackDamage;   //�ǉ��ߋ����U���_���[�W
    public float addShotDamage;     //�ǉ��������U���_���[�W
    public float plusShotDamage;
    public float addMoney;         //�������ǉ�
    public bool onSelfHarm = false;   //�A�C�e���p�t���O
    public bool onHealthTreat = false;

    public bool onResetHpBr = false;    //�̗́A�o���A���Z�b�g������
    public PlayerStatusData status;     //�v���C���[�̃X�e�[�^�X�i�[�p
    public StatusCalc statusCalc = new StatusCalc();  //�X�e�[�^�X�v�Z�p

    // Start is called before the first frame update
    void Start()
    {
        //�X�e�[�^�X�̏�����
        status = new PlayerStatusData(maxHP, initialMoney, attackDamage, shotDamage, barrier[0], criChance, criDamage);

        addAttackDamage = 1;
        addShotDamage = 1;
        addMoney = 1;

        Debug.Log("maxHP" + status.MaxHP);
    }

    //�����l���֐�
    public void GettingMoney(int money)
    {
        Debug.Log("�����擾");
        status.Money += (int)(money * addMoney);
    }
    //�������g�����Ƃ��֐�
    public void UseMoney(int money)
    {
        status.Money -= money;
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
        return statusCalc.DamageCalc(status.GetAttackDamage(0), status.CriChance, status.CriDamage)
                * addAttackDamage;
    }

    //�������U���̃_���[�W�v�Z�֐�
    public float ShotDamageCalc()
    {
        //SelfHarm�������Ă��邩�̗͂��P��葽���Ȃ�
        if(onSelfHarm == true && status.CurrentHP >1f)
        {
            //�ő�̗͂�5%���󂯂�
            TakeDamage(MaxHP() * 0.05f);
        }

        //AttackDamage[1]�������Ƃ��āA�_���[�W�v�Z�֐����Ă�
        return (statusCalc.DamageCalc(status.GetAttackDamage(1), status.CriChance, status.CriDamage)
                + plusShotDamage )
                * addShotDamage;
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
        status.CurrentHP = statusCalc.MaxHPCalc(status.MaxHP);
        status.Barrier = barrier[0];

        onResetHpBr = true;//�o���A�Q�[�W�̏������p
    }
    //���݂̗̑͂̊��������߂�֐�
    public float HPper()
    {
        return status.CurrentHP / statusCalc.MaxHPCalc(status.MaxHP);
    }
    //HealthTreat�p�֐�
    public void HT()
    {
        status.CurrentHP = statusCalc.HealHPper(status.MaxHP, status.CurrentHP, 0.03f);
    }
    //�ő�̗͊֐�
    public float MaxHP()
    {
        return statusCalc.MaxHPCalc(status.MaxHP);
    }
    //���݂̗̑͂𒲐�����֐�
    public void RoadHP()
    {
        //���݂̗̑͂��ő�̗͂𒴂��Ă�����
        if(status.CurrentHP > statusCalc.MaxHPCalc(status.MaxHP))
        {
            //���݂̗̑͂��ő�̗͂ɍX�V
            status.CurrentHP = statusCalc.MaxHPCalc(status.MaxHP);
        }
    }
}

