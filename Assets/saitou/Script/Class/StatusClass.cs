using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�X�e�[�^�X�Ǘ��N���X
public class StatusData
{
    protected float maxHP;      //�ő�HP   
    protected float currentHP;  //���݂�HP
    protected int money;        //������
    protected List<float> attackDamage = new List<float>();//�U���̃_���[�W

    //�R���X�g���N�^
    public StatusData(float hp, int mon, float attack1, float attack2 = 10)
    {
        //��������X�e�[�^�X��������
        maxHP = hp;
        currentHP = maxHP;
        money = mon;
        attackDamage.Insert(0, attack1);
        attackDamage.Insert(1, attack2);
    }

    public float MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    public float CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }
    public void SetAttackDamage(int n, float damage)
    {
        attackDamage.Insert(n, damage);
    }
    public float GetAttackDamage(int n)
    {
        return attackDamage[n];
    }

    //��S�_���[�W�@��S���@��ǉ��\��
}

//�v���C���[�X�e�[�^�X�Ǘ��N���X
public class PlayerStatusData : StatusData
{
    float barrier;          //�o���A�l(��_���[�W���������銄��)
    int criticalChance;   //�N���e�B�J����
    float criticalDamage;   //�N���e�B�J���_���[�W
    
    //�R���X�g���N�^
    public PlayerStatusData(float hp,  int mon, float attack, float shot, float barri, int criC, float criD) : base(hp, mon, attack, shot)
    {
        //��������X�e�[�^�X��������
        barrier = barri;
        criticalChance = criC;
        criticalDamage = criD;
    }

    //�v���p�e�B
    public float Barrier
    {
        get { return barrier; }
        set { barrier = value; }
    }
    public int CriChance
    {
        get { return criticalChance; }
        set { criticalChance = value; }
    }
    public float CriDamage
    {
        get { return criticalDamage; }
        set { criticalDamage = value; }
    }
}


//�X�e�[�^�X�v�Z�N���X
public class StatusCalc
{
    private float addMaxHP;       //�ǉ��ő�̗�
    private float increaseAttack; //�����_���[�W(*)
    private float increaseBlock;  //�h��i�����j��

    private float addCriticalDamage;    //��S�_���[�W
    private int addCriticalChance;    //��S��
    

    //�R���X�g���N�^
    public StatusCalc()
    {
        //������
        addMaxHP = 1f;
        increaseAttack = 1f;
        increaseBlock = 1f;

        addCriticalDamage = 0f;
        addCriticalChance = 0;
    }
    //�_���[�W�v�Z�֐� �������P�Ȃ�N���e�B�J���͋N���Ȃ�
    public float DamageCalc(float damage, int criC = -100, float criD = 1f)
    {
        //1~100�̃����_��
        int dice = Random.RandomRange(1, 101);

        //�����_���̒l���A�N���e�B�J�����ȉ��Ȃ�
        if( dice <= criC + addCriticalChance)
        {
            //�N���e�B�J���_���[�W��������
            return damage * increaseAttack * (criD + addCriticalDamage);
        }
        else
        {
            //�ʏ�̃_���[�W
            return damage * increaseAttack;
        }     
    }
    //�̗͌v�Z�֐�
    public float HPCalc(float hp, float damage, float barrier = 1.0f)
    {
        return hp - (damage* increaseBlock * barrier);
    }
    //�̗͐��l�񕜊֐�
    public float HealHP(float maxhp, float hp, float heal)
    {
        //�񕜂��čő�̗͂𒴂���Ȃ�
        if (hp + heal >= MaxHPCalc(maxhp))
        {
            //���݂̗̑͂��ő�̗͂Ɠ����ɂ���
            return MaxHPCalc(maxhp);
        }
        else
        {
            //���݂̗̑͂��񕜂���
            return hp + heal;
        }
    }
    //�̗͊����񕜊֐�
    public float HealHPper(float maxhp, float hp, float per)
    {
        float maxHP = MaxHPCalc(maxhp);

        float heal = maxHP * per;

        //�񕜂��čő�̗͂𒴂���Ȃ�
        if (hp + heal >= maxHP)
        {
            //���݂̗̑͂��ő�̗͂Ɠ����ɂ���
            return maxHP;
        }
        else
        {
            //���݂̗̑͂��񕜂���
            return hp + heal;
        }
    }
    //�ő�̗͌v�Z
    public float MaxHPCalc(float maxhp)
    {
        return maxhp *= addMaxHP;
    }

    //�v���p�e�B
    public float AddMaxHP
    {
        get { return addMaxHP; }
        set { addMaxHP = value; }
    }
    public float IncreaseAttack
    {
        get { return increaseAttack; }
        set { increaseAttack = value; }
    }
    public float IncreaseBlock
    {
        get { return increaseBlock; }
        set { increaseBlock = value; }
    }
    public float AddCriticalDamage
    {
        get { return addCriticalDamage; }
        set { addCriticalDamage = value; }
    }
    public int AddCriticalChance
    {
        get { return addCriticalChance; }
        set { addCriticalChance = value; }
    }
}