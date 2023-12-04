using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Trader : MonoBehaviour
{
    // ItemSelectUI���i�[����ϐ�
    // �C���X�y�N�^�[����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject TradeUI;
    //[SerializeField] GameObject[] Item = new GameObject[12];

    GameObject SelectButton;
    GameObject FindID;

    //GameObject datainfo;
    ItemManager itemmanager = new ItemManager();
    PlayerItemManager PIM = new PlayerItemManager();
    ItemIcon itemicon = new ItemIcon();

    PlayerManager playerManager;
    ItemUIManager itemUI;

    public GameObject[] TradeItem = new GameObject[6];
    public Text[] textamount = new Text[6];
    public Text[] textname = new Text[6];
    public Text[] textdisc = new Text[6];
    public string[] ItemId = new string[6];
    //�@TextMeshProUGUI   ���b�V���v����g���ۂ͂�����
    private void Start()
    {
       // datainfo = GameObject.Find("DataInfo");
        itemmanager = LoadManagerScene.GetItemManager();

        PIM = LoadManagerScene.GetPlayerItemManager();
        itemicon = LoadManagerScene.GetItemIcon();

        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();

        GameObject canv = GameObject.Find("Canvas");
        itemUI = canv.GetComponent<ItemUIManager>();
    }

    public void ActiveTradeUI()
    {
        TradeUI.SetActive(true);
        playerManager.dontMove = true;

        ItemId = itemmanager.GetRandomItem(6);

        for ( int i = 0; i < 6; i++)
        {
            if (ItemId[i] != null)
            {
                TradeItem[i].GetComponent<Image>().sprite = itemicon.SearchImage(ItemId[i]);
                textname[i].text = itemmanager.GetName(ItemId[i]);
                textdisc[i].text = itemmanager.GetDescription(ItemId[i]);
                textamount[i].text = itemmanager.GetBuyingPrice(ItemId[i]).ToString();
            }
            //�A�C�e����������Ȃ������ꍇ
            else
            {
                TradeItem[i].GetComponent<Image>().sprite = itemicon.Empty();
                textname[i].text = "NoName";
                textdisc[i].text = " ";
                textamount[i].text = "0";
            }

        }

        //string Id =itemmanager.GetRandomItem();
        //string name = itemmanager.GetName(Id);
        //string discription = itemmanager.GetDescription(Id);

        //itemname = name;
        // �����_����3�̃A�C�e�����A�N�e�B�u�ɂ���
        //ActivateRandomItems(3);
    }

    public void CloseUI()
    {
        TradeUI.SetActive(false);
        playerManager.dontMove = false;
    }

    public void OpenUI()
    {
        TradeUI.SetActive(true);
        playerManager.dontMove = true;
    }

    // ActiveItemSelectUI �ŕ\������Ă���A�C�e����I��
    public void TradeChoice(int objectname)
    {
        PIM.BuyingItem(ItemId[objectname]); Debug.Log("�X�e�[�^�X�㏸" + objectname);
        itemUI.ChangeIcon();//�����A�C�e���A�C�R���X�V
    }

    //void ActivateRandomItems(int count)
    //{
    //    // ���ׂẴA�C�e�����A�N�e�B�u�ɂ���
    //    foreach (var item in Item)
    //    {
    //        item.SetActive(false);
    //    }

    //    List<int> selectedIndices = new List<int>();

    //    //�����_���ȃA�C�e����I��
    //    while (selectedIndices.Count < count)
    //    {
    //        int randomIndex = Random.Range(0, Item.Length);
    //        if (!selectedIndices.Contains(randomIndex))
    //        {
    //            selectedIndices.Add(randomIndex);
    //        }
    //    }

    //    // �I�����ꂽ�A�C�e�����A�N�e�B�u�ɂ���
    //    foreach (int index in selectedIndices)
    //    {
    //        if (index >= 0 && index < Item.Length)
    //        {
    //            Item[index].SetActive(true);
    //        }
    //    }
    //}
}
