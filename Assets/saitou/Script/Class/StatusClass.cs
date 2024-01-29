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
