using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�A�C�e���f�[�^�̗v�f
public enum ItemElement
{
    ID,
    NAME,
    DESCRIPTION,
    GRADE,
    MAXHP,
    ATTACK,
    SWORD,
    SHOT,
    BLOCK,
    CRICHANCE,
    CRIDAMAGE,
    PRICE
}

//�S�A�C�e���̊Ǘ��N���X
//��{�I�ɑ��I�u�W�F�N�g����A�N�Z�X�o���Ȃ��悤�ɂ�����
public class ItemManager : MonoBehaviour
{
    
    //�S�A�C�e���f�[�^List
    //private List<ItemDataC> ItemData = new List<ItemDataC>();

    private List<ItemDataC> ItemData = new List<ItemDataC>();


    private TextAsset csvFile; // CSV�t�@�C��
    private List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g

    private PlayerItemManager playerItemManager;

    void Start()
    {
        {
        //    playerItemManager = GetComponent<PlayerItemManager>();

        //    csvFile = Resources.Load("ItemData") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        //    StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�

        //    while (reader.Peek() != -1)
        //    {
        //        string line = reader.ReadLine(); // 1�s���ǂݍ���
        //        csvData.Add(line.Split(',')); // csvData���X�g�ɒǉ����� 
        //    }
        //    for (int i = 0; i < 5; i++)
        //        Debug.Log(csvData[1][i]);

        //    //2�s�ڂ���f�[�^��ǂݍ���
        //    for (int i = 1; i < csvData.Count; i++)
        //    {
        //        ItemDataC LoadItem = new ItemDataC();
        //        LoadItem.Id = csvData[i][0];
        //        LoadItem.ItemName = csvData[i][1];
        //        LoadItem.Description = csvData[i][2];
        //        LoadItem.BuyingPrice = int.Parse(csvData[i][3]);
        //        LoadItem.SellingPrice = int.Parse(csvData[i][4]);

        //        //�A�C�e���f�[�^�Ƀf�[�^��ǉ�
        //        ItemData.Add(LoadItem);
        //    }
        //    Debug.Log("�A�C�e���f�[�^���쐬���܂���");
        }

        playerItemManager = GetComponent<PlayerItemManager>();

        csvFile = Resources.Load("ItemData_v2") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1�s���ǂݍ���
            csvData.Add(line.Split(',')); // csvData���X�g�ɒǉ����� 
        }
        //for (int i = 0; i < 11; i++)
        //    Debug.Log(csvData[1][i]);

        int c = 1;

        //2�s�ڂ���f�[�^��ǂݍ���
        while (c < csvData.Count)
        {
            ItemDataC LoadItem = new ItemDataC();

            for (int j = 0; j < 3; j++)
            {
                LoadItem.grade[j].Id            = csvData[c][(int)ItemElement.ID];
                LoadItem.grade[j].ItemName      = csvData[c][(int)ItemElement.NAME];
                LoadItem.grade[j].Description   = csvData[c][(int)ItemElement.DESCRIPTION];
                LoadItem.grade[j].Grade         = int.Parse(  csvData[c][(int)ItemElement.GRADE]);
                LoadItem.grade[j].MaxHp         = float.Parse(csvData[c][(int)ItemElement.MAXHP]);
                LoadItem.grade[j].Attack        = float.Parse(csvData[c][(int)ItemElement.ATTACK]);
                LoadItem.grade[j].SwordAttack   = float.Parse(csvData[c][(int)ItemElement.SWORD]);
                LoadItem.grade[j].ShotAttack    = float.Parse(csvData[c][(int)ItemElement.SHOT]);
                LoadItem.grade[j].Block         = float.Parse(csvData[c][(int)ItemElement.BLOCK]);
                LoadItem.grade[j].CriChance     = float.Parse(csvData[c][(int)ItemElement.CRICHANCE]);
                LoadItem.grade[j].CriDamage     = float.Parse(csvData[c][(int)ItemElement.CRIDAMAGE]);

                c++;
            }
                Debug.Log(LoadItem.grade[0].Id);
                
                //�A�C�e���f�[�^�Ƀf�[�^��ǉ�
                ItemData.Add(LoadItem);

        }
        Debug.Log("�A�C�e���f�[�^���쐬���܂���");
    }

    //ID�ƃO���[�h����A�C�e�������擾����֐�(ID,�O���[�h,�Ԃ�l�̗v�f)
    public string GetItemData(string id,int gra,int elem)
    {
        //�O���[�h�̒l���������Ȃ��Ȃ�
        if (gra < 0 || gra > 2)
        {            
            Debug.Log("!�O���[�h�̒l���������Ȃ��ł�");
            return null;
        }
        //�v�f�̒l���������Ȃ��Ȃ�
        if(elem<0||elem>10)
        {
            Debug.Log("!�v�f�̒l���������Ȃ��ł�");
            return null;
        }
        

        //�A�C�e���f�[�^��S�ĒT��
        for (int i = 0; i < ItemData.Count; i++)
        {
            //ID����v�����Ȃ�
            if (ItemData[i].grade[0].Id == id)
            {
                switch (elem)
                {
                    case (int)ItemElement.NAME:
                        return ItemData[i].grade[gra].ItemName;

                    case (int)ItemElement.DESCRIPTION:
                        return ItemData[i].grade[gra].Description;

                    case (int)ItemElement.MAXHP:
                        return ItemData[i].grade[gra].MaxHp.ToString();

                    case (int)ItemElement.ATTACK:
                        return ItemData[i].grade[gra].Attack.ToString();

                    case (int)ItemElement.SWORD:
                        return ItemData[i].grade[gra].SwordAttack.ToString();

                    case (int)ItemElement.SHOT:
                        return ItemData[i].grade[gra].ShotAttack.ToString();

                    case (int)ItemElement.BLOCK:
                        return ItemData[i].grade[gra].Block.ToString();

                    case (int)ItemElement.CRICHANCE:
                        return ItemData[i].grade[gra].CriChance.ToString();

                    case (int)ItemElement.CRIDAMAGE:
                        return ItemData[i].grade[gra].CriDamage.ToString();
                }               
            }
        }
        //������ID���A�C�e���f�[�^�ɑ��݂��Ȃ��Ȃ�
        Debug.Log("!�w�肵���A�C�e����ID��������܂���");
        return null;

    }


    //�w�����i��Ԃ��֐� �폜�\��
    public int GetBuyingPrice(int gra)
    {
        switch (gra)
        {
            case 0:
                return 100;
            case 1:
                return 200;
            case 2:
                return 300;
            default:
                Debug.Log("!�O���[�h�̒l�����������ł�");
                return 0;
        }  
    }

    //�A�C�e���̗v�f��
    public int GetCount()
    {
        return ItemData.Count;
    }

    //�����̗v�f�Ԗڂ�ID���擾����֐�
    public string GetID(int num)
    {
        if (num< ItemData.Count)
        {
            Debug.Log("ID��Ԃ�"+ ItemData[num].grade[0].Id);
            return ItemData[num].grade[0].Id;
        }
        else
        {
            Debug.Log("ID�˂���");
            return null;
        }
    }

    //�����_���A�C�e���w��֐��@�قږ��g�p
    public string GetRandomItem()
    {
        //0�`�S�A�C�e���̎�ނ̃����_���Ȑ��l���擾
        int r = Random.RandomRange(0, ItemData.Count);

        //���̐��l����AID��Ԃ�
        return ItemData[r].grade[0].Id;
    }
    //������id�Ɣ��Ȃ��I�[�o�[���[�h num�͌� havingItem�̕��Ɉڍs������
    //public string[] GetRandomItem(int num = 1)
    //{
    //    string[] ans = new string[num];//�Ԃ�l�p�z��

    //    //�A�C�e��ID�ꗗ�̐���
    //    List<string> itemId = new List<string>();
    //    for(int i = 0; i<ItemData.Count; i++)
    //    {
    //        itemId.Add(ItemData[i].grade[0].Id);
    //    }

    //    //������ID�Ɣ���Ă���v�f���폜
    //    for (int i = 0; i < playerItemManager.havingItem.Count; i++) 
    //    {
    //        itemId.Remove(playerItemManager.havingItem.grade[0]);
    //    }

    //    for (int i = 0; i < num; i++)
    //    {
    //        //itemId�̒��g�����邩�`�F�b�N
    //        if (itemId.Count != 0)
    //        {
    //            //0�`�S�A�C�e���̎�ނ̃����_���Ȑ��l���擾
    //            int r = Random.RandomRange(0, itemId.Count);

    //            ans[i] = itemId[r];//�Ԃ�l�p�z��Ƀ����_����ID����

    //            itemId.RemoveAt(r);//�������ID���폜
    //        }
    //        else
    //        {
    //            //�G���[
    //            Debug.Log("!�������̃A�C�e����������܂���");
    //            ans[i] = null;
    //        }
    //    }
    //    //���̐��l����AID��Ԃ�
    //    return ans;
    //}

}

