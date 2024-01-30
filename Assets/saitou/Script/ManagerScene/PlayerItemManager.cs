using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����A�C�e���Ǘ��N���X
public class PlayerItemManager : MonoBehaviour
{
    //�v���C���[�����A�C�e�����X�g(ID, �O���[�h)
    //public List<string> havingItem = new List<string>();
    public Dictionary<string, int> havingItem = new Dictionary<string, int>();

    public int maxItem = 8;//�A�C�e���̍ő及����

    ItemDataS plusEffect;   //�������킹����ʃf�[�^
    ItemDataS resetEffect; //��̌��ʃf�[�^�̏������p
     
    [SerializeField] private float iconPosX;//�A�C�R���̏����ʒuX�i����j
    [SerializeField] private float iconPosY;//�A�C�R���̏����ʒuY�i����j


    //���X�N���v�g�̃C���X�^���X
    PlayerStatusManager playerStatusManager;
    ItemManager itemManager;

    //�A�C�e���A�C�R���p�I�u�W�F�N�g
    GameObject itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        //���I�u�W�F�N�g�̕ʃX�N���v�g���擾
        playerStatusManager = GetComponent<PlayerStatusManager>();
        itemManager = GetComponent<ItemManager>();

        //���Z�b�g�p�̐��l���������i�o����ΐ錾���ɂ����������j
        {
            resetEffect.Id          = null;
            resetEffect.ItemName    = null;
            resetEffect.Description = null;
            resetEffect.Grade       = 0;

            resetEffect.MaxHp       = 1;
            resetEffect.Attack      = 1;
            resetEffect.SwordAttack = 1;
            resetEffect.ShotAttack  = 1;
            resetEffect.Block       = 1;
            resetEffect.CriChance   = 0;
            resetEffect.CriDamage   = 1;
            resetEffect.AddMoney    = 1;
        }
    }

    //�K�v�������̌Ăяo���ł����̂ł́H
    public void GetItemEffect(ref ItemDataS refdata)
    {
        //�ϐ��̃��Z�b�g
        plusEffect = resetEffect;



        //�O���[�h�ɂ���Č��ʂ�ύX������
        //�����A�C�e���̌��ʂ��v�Z
        foreach (KeyValuePair<string, int> haveitem in havingItem)
        {
            //����ȏ����Ȃǂ�������ʂ̏ꍇ�̏����@���̑���default��
            switch (haveitem.Key)
            {
                case "Revenge":
                    switch(haveitem.Value){
                        case 0:
                            if (playerStatusManager.HPper() < 0.20f)
                            {
                                plusEffect.Attack += 0.40f;
                            }
                            break;
                        case 1:
                            if (playerStatusManager.HPper() < 0.20f)
                            {
                                plusEffect.Attack += 0.50f;
                            }
                            break;
                        case 2:
                            if (playerStatusManager.HPper() < 0.20f)
                            {
                                plusEffect.Attack += 0.70f;
                            }
                            break;
                    }
                    break;

                case "SelfHarm":          
                    playerStatusManager.onSelfHarm = true;

                    switch (haveitem.Value){
                        case 0:
                            plusEffect.ShotAttack += 1;
                            break;
                        case 1:
                            plusEffect.ShotAttack += 1.2f; 
                            break;
                        case 2:
                            plusEffect.ShotAttack += 1.4f;
                            break;
                    }
                    break;
               
                case "Collector":
                    switch (haveitem.Value){
                        case 0:
                            plusEffect.Attack += (havingItem.Count * 0.02f);
                            break;
                        case 1:
                            plusEffect.Attack += (havingItem.Count * 0.03f);
                            break;
                        case 2:
                            plusEffect.Attack += (havingItem.Count * 0.04f);
                            break;
                    }
                    break;

                case "FirstAttack":
                    switch (haveitem.Value){
                        case 0:
                            plusEffect.Attack += 0.16f - (havingItem.Count * 0.02f); 
                            break;
                        case 1:
                            plusEffect.Attack += 0.40f - (havingItem.Count * 0.04f);
                            break;
                        case 2:
                            plusEffect.Attack += 0.64f - (havingItem.Count * 0.06f);
                            break;
                    }
                    
                    break;
                default:
                    Debug.Log("!�A�C�e�����ʂ�������܂���");

                    //������ʓ��������ꍇ�A���ʂ𑫂����킹��
                    itemManager.PlusEffect(ref plusEffect, haveitem.Key, haveitem.Value);

                    break;
            }
            //playerStatusManager.plusShotDamage = plusShot;

            //playerStatusManager.RoadHP();
        }
        //�擾�������ʂ������ɑ��
        refdata = plusEffect;
    }

    //�A�C�e���擾�֐� ���łɏ������Ă�����false��Ԃ�
    public bool AddItem(string id)
    {
        if (id != null)
        {          
            //ID���������Ă�����
            if (havingItem.ContainsKey(id))
            {
                //�A�b�v�O���[�h����Ȃ�
                if(havingItem[id] > 2)
                {
                    //���łɏ������Ă����Ȃ牽�����Ȃ�
                    Debug.Log(id + "�����łɏ������Ă��܂�");

                    return false;
                }  
                //�A�b�v�O���[�h�֐��Ɉړ�������
                UpgradeItem(id);
                return true;
            }
            //�������Ȃ�
            if (havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
            {
                Debug.Log("�A�C�e�����ő�ł�");
                return false;
            }
            else
            {
                havingItem.Add(id, 0);//�����A�C�e����id��ǉ�
                Debug.Log(id + "���l�����܂���");
                return true;
            }
        }
        return false;
    }

    //�A�C�e���A�b�v�O���[�h�֐�
    public void UpgradeItem(string id)
    {
        //ID���������Ă�����
        if (havingItem.ContainsKey(id))
        {
            if (havingItem[id] < 3)
            {
                havingItem[id]++;
                Debug.Log(id + " : ���A�b�v�f�[�g���܂���");
            }
            else
                Debug.Log(id + " : �̓A�b�v�f�[�g�o���܂���");
        }
        else
        {
            Debug.Log("!�������Ă��܂���");
        }
    }

    //�A�C�e���p���֐�
    public void RemoveItem(string id)
    {
        havingItem.Remove(id);//�����A�C�e������w���id���폜
    }

    //�A�C�e���w���֐�
    public bool BuyingItem(string id)
    {
        if (id != null)
        {
            //���̃A�C�e�����������Ă��邩
            if (!havingItem.ContainsKey(id))//�������̏ꍇ
            {
                //�w�����i���擾
                int price = itemManager.GetBuyingPrice(0);

                //������������Ă���Ȃ�                                                       
                if (playerStatusManager.status.Money >= price)
                {
                    if (havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
                    {
                        Debug.Log("�A�C�e�����ő�ł�");
                        return false;
                    }
                    //�A�C�e�����l�� 
                    AddItem(id);

                    //���i���A�����������炷
                    playerStatusManager.UseMoney(price);

                    Debug.Log(id + "���w�� : " + price);
                    return true;

                }
                else
                {
                    Debug.Log("����������܂���");
                    return false;
                }
            }
            else//�����ς̏ꍇ
            {
                //�w�����i���擾
                int price = itemManager.GetBuyingPrice(havingItem[id] + 1);

                //������������Ă���Ȃ�                                                       
                if (playerStatusManager.status.Money >= price)
                {
                    //�A�C�e�����A�b�v�O���[�h
                    UpgradeItem(id);

                    //���i���A�����������炷
                    playerStatusManager.UseMoney(price);
                    return true;
                }
                else
                {
                    Debug.Log("����������܂���");
                    return false;
                }
            }
        }
        return false;
    }


    //�����_���A�C�e���w��֐�(�擾���鐔(�Ԃ�l�̗v�f��), �O���[�h1,2���o�����邩)
    public string[] GetRandomItem(int num = 1, bool ongrade = true)
    {
        string[] ans = new string[num];//�Ԃ�l�p�z��

        Debug.Log("ID��" + itemManager.GetID(1));
        //�A�C�e��ID�ꗗ�̐���
        List<string> itemId = new List<string>();

        if (havingItem.Count < maxItem)//�ő及���������Ȃ�
        {
            //�S�A�C�e��ID��itemId�ɓ����
            for (int i = 0; i < itemManager.GetCount(); i++)
            {
                itemId.Add(itemManager.GetID(i));
            }
        }
        else//�ő�܂ŏ������Ă���Ȃ�
        {
            //�����A�C�e���S�Ă�itemId�ɓ����
            foreach (KeyValuePair<string, int> haveitem in havingItem)
            {
                itemId.Add(haveitem.Key);
            }
        }

        //�f�o�b�O�p
        for(int i = 0;i<itemId.Count;i++)
        {
            Debug.Log("ID : "+itemId[i]);
        }

        //�����A�C�e�������ׂĒT��
        foreach (KeyValuePair<string, int> haveitem in havingItem)
        {
            switch(ongrade)
            {
                case true:
                    //�O���[�h��2(����ȏ�A�b�v�O���[�h�ł��Ȃ�)�Ȃ��₩��O��
                    if (haveitem.Value == 2)
                        itemId.Remove(haveitem.Key);
                    break;

                case false:
                    if (havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
                    {
                        Debug.Log("�A�C�e�����ő�ł�");
                        return null;//null�ŕԂ�
                    }
                    //�����A�C�e������₩��O��
                    itemId.Remove(haveitem.Key);

                    break;
            }
        }

        //�Ԃ�l�����߂�
        for (int i = 0; i < num; i++)
        {
            //itemId�̒��g�����邩�`�F�b�N
            if (itemId.Count != 0)
            {
                //0�`�S�A�C�e���̎�ނ̃����_���Ȑ��l���擾
                int r = Random.RandomRange(0, itemId.Count);

                ans[i] = itemId[r];//�Ԃ�l�p�z��Ƀ����_����ID����

                itemId.RemoveAt(r);//�������ID���폜
            }
            else
            {
                //�G���[
                Debug.Log("!�������̃A�C�e����������܂���");
                ans[i] = null;
            }
        }
        return ans;
    }

    //�����A�C�e���̃O���[�h���擾����֐�
    public int GetHaveGrade(string id)
    {
        //����id���������Ă��邩
        if (havingItem.ContainsKey(id))
        {
            return havingItem[id];//�������Ă���id�̃O���[�h��Ԃ�
        }
        else
        {
            Debug.Log("�A�C�e�����������Ă��܂���");
            return -1;
        }
    }

    //�����A�C�e���f�o�b�O�\���֐�
    public string[] GetHaveItem( )
    {
        string[] id = new string[8];
        int i = 0;

        foreach (KeyValuePair<string, int> haveitem in havingItem){
            id[i] = haveitem.Key;
            i++;
        }
        return id;
    }
}
