using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusClass : MonoBehaviour
{
}

//�X�e�[�^�X�Ǘ��N���X
public class StatusData
{
    //�R���X�g���N�^
    public StatusData()
    {

    }
    protected float maxHP;  //�ő�HP   
    protected int money;    //������
    protected List<float> attackDamage = new List<float>();//�U���̃_���[�W


    public float MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
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
    //�R���X�g���N�^
    public PlayerStatusData()
    {

    }
    private float maxBarrier;//�ő�o���A�l

    public float MaxBarrier
    {
        get { return maxBarrier; }
        set { maxBarrier = value; }
    }
}


//�X�e�[�^�X�v�Z�N���X
public class StatusCalc
{
    private float addDamage;      //�ǉ��_���[�W(+)
    private float increaseDamage; //�����_���[�W(*)

    //�R���X�g���N�^
    public StatusCalc()
    {
        //������
        addDamage = 0.0f;
        increaseDamage = 1.0f;
    }
    //�_���[�W�v�Z�֐�
    public float DamageCalc(float damage)
    {
        return (damage + addDamage) * increaseDamage;
    }
    //�̗͌v�Z�֐�
    public float HPCalc(float HP, float damage, float barrier = 1.0f)
    {
        return HP - (damage * barrier);
    }
    //AddDamage�v���p�e�B
    public float AddDamage
    {
        get { return addDamage; }
        set { addDamage = value; }
    }
    //IncreaseDamage�v���p�e�B
    public float IncreaseDamage
    {
        get { return increaseDamage; }
        set { increaseDamage = value; }
    }
}