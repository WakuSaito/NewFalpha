using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�S�A�C�e���̊Ǘ��N���X
//��{�I�ɑ��I�u�W�F�N�g����A�N�Z�X�o���Ȃ��悤�ɂ�����
public class ItemManager : MonoBehaviour
{
    //�S�A�C�e���f�[�^List
    private List<ItemDataC> ItemData = new List<ItemDataC>();

    private TextAsset csvFile; // CSV�t�@�C��
    private List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g

    private PlayerItemManager playerItemManager;

    void Start()
    {
        playerItemManager = GetComponent<PlayerItemManager>();

        csvFile = Resources.Load("ItemData") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1�s���ǂݍ���
            csvData.Add(line.Split(',')); // csvData���X�g�ɒǉ����� 
        }
        for (int i = 0; i < 5; i++)
            Debug.Log(csvData[1][i]);

        //2�s�ڂ���f�[�^��ǂݍ���
        for (int i = 1; i < csvData.Count; i++)
        {
            ItemDataC LoadItem = new ItemDataC();
            LoadItem.Id = csvData[i][0];
            LoadItem.ItemName = csvData[i][1];
            LoadItem.Description = csvData[i][2];
            LoadItem.BuyingPrice = int.Parse(csvData[i][3]);
            LoadItem.SellingPrice = int.Parse(csvData[i][4]);

            //�A�C�e���f�[�^�Ƀf�[�^��ǉ�
            ItemData.Add(LoadItem);
        }
        Debug.Log("�A�C�e���f�[�^���쐬���܂���");
    }

    //���O��Ԃ��֐�
    public string GetName(string id)
    {
        //�A�C�e���f�[�^��S�ĒT��
        for (int i = 0; i < ItemData.Count; i++)
        {
            //ID����v�����Ȃ�
            if (ItemData[i].Id == id)
            {
                return ItemData[i].ItemName;
            }
        }
        //������ID���A�C�e���f�[�^�ɑ��݂��Ȃ��Ȃ�
        Debug.Log("!�w�肵���A�C�e���̖��O��������܂���");
        return null;
    }

    //��������Ԃ��֐�
    public string GetDescription(string id)
    {
        //�A�C�e���f�[�^��S�ĒT��
        for (int i = 0; i < ItemData.Count; i++)
        {
            //ID����v�����Ȃ�
            if (ItemData[i].Id == id)
            {
                return ItemData[i].Description;
            }
        }
        //������ID���A�C�e���f�[�^�ɑ��݂��Ȃ��Ȃ�
        Debug.Log("!�w�肵���A�C�e���̐�������������܂���");
        return null;
    }

    //�w�����i��Ԃ��֐�
    public int GetBuyingPrice(string id)
    {
        //�A�C�e���f�[�^��S�ĒT��
        for (int i = 0; i < ItemData.Count; i++)
        {
            //ID����v�����Ȃ�
            if (ItemData[i].Id == id)
            {
                return ItemData[i].BuyingPrice;
            }
        }
        //������ID���A�C�e���f�[�^�ɑ��݂��Ȃ��Ȃ�
        Debug.Log("!�w�肵���A�C�e���̍w�����i��������܂���");
        return 0;
    }
    //���p���i��Ԃ��֐�
    public int GetSellingPrice(string id)
    {
        //�A�C�e���f�[�^��S�ĒT��
        for (int i = 0; i < ItemData.Count; i++)
        {
            //ID����v�����Ȃ�
            if (ItemData[i].Id == id)
            {
                return ItemData[i].SellingPrice;
            }
        }
        //������ID���A�C�e���f�[�^�ɑ��݂��Ȃ��Ȃ�
        Debug.Log("!�w�肵���A�C�e���̔��p���i��������܂���");
        return 0;
    }

    //�����_���A�C�e���w��֐�
    public string GetRandomItem()
    {
        //0�`�S�A�C�e���̎�ނ̃����_���Ȑ��l���擾
        int r = Random.RandomRange(0, ItemData.Count);

        //���̐��l����AID��Ԃ�
        return ItemData[r].Id;
    }
    //������id�Ɣ��Ȃ��I�[�o�[���[�h num�͌�
    public string[] GetRandomItem(int num = 1)
    {
        string[] ans = new string[num];//�Ԃ�l�p�z��

        //�A�C�e��ID�ꗗ�̐���
        List<string> itemId = new List<string>();
        for(int i = 0; i<ItemData.Count; i++)
        {
            itemId.Add(ItemData[i].Id);
        }

        //������ID�Ɣ���Ă���v�f���폜
        for (int i = 0; i < playerItemManager.havingItem.Count; i++) 
        {
            itemId.Remove(playerItemManager.havingItem[i]);
        }

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
                return null;
            }
        }
        //���̐��l����AID��Ԃ�
        return ans;
    }
}

