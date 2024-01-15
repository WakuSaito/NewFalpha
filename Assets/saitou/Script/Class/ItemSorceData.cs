using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���f�[�^�N���X
//CSV�t�@�C������̓ǂݍ���
public class ItemDataC
{
    private string id;          //�A�C�e��ID   
    private string itemName;    //����
    private string description; //����
    //private Sprite icon;        //�A�C�e���̃A�C�R��
    private int buyingPrice;    //���l
    private int sellingPrice;   //���l

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    //public Sprite Icon
    //{
    //    get { return icon; }
    //    set { icon = value; }
    //}
    public int BuyingPrice
    {
        get { return buyingPrice; }
        set { buyingPrice = value; }
    }
    public int SellingPrice
    {
        get { return sellingPrice; }
        set { sellingPrice = value; }
    }
}


public struct ItemData
{
    private string id;          //�A�C�e��ID   
    private string itemName;    //����
    private string description; //����
    private int grade;          //�O���[�h

    //�ǉ�����X�e�[�^�X
    private float maxHp;        //�ő�̗�
    private float attack;       //�U����
    private float swordAttack;  //�ߋ����U����
    private float shotAttack;   //�������U����
    private float block;        //�h���
    private float criChance;    //�N���e�B�J����
    private float criDamage;    //�N���e�B�J���_���[�W

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int Grade
    {
        get { return grade; }
        set { grade = value; }
    }


    public float MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    public float SwordAttack
    {
        get { return swordAttack; }
        set { swordAttack = value; }
    }
    public float ShotAttack
    {
        get { return shotAttack; }
        set { shotAttack = value; }
    }
    public float Block
    {
        get { return block; }
        set { block = value; }
    }
    public float CriChance
    {
        get { return criChance; }
        set { criChance = value; }
    }
    public float CriDamage
    {
        get { return criDamage; }
        set { criDamage = value; }
    }
}