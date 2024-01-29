using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public  enum Tabs
{
    BUY,
    UPGRADE
}

//�\���f�[�^
public struct BuyData
{
    public string id;
    public int grade;
    public Text price;
    public Text itemname;
    public Text disc;
}

public class Trader : MonoBehaviour
{
    // ItemSelectUI���i�[����ϐ�
    // �C���X�y�N�^�[����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject TradeUI;
    //[SerializeField] GameObject[] Item = new GameObject[12];


    //GameObject datainfo;
    ItemManager itemmanager = new ItemManager();
    PlayerItemManager PIM = new PlayerItemManager();
    ItemIcon itemicon = new ItemIcon();

    PlayerManager playerManager;
    ItemUIManager itemUI;
    Sounds sounds;

    //�w���A�C�e���A�C�R��
    public GameObject[] TradeItem = new GameObject[6];
    public Text[] textamount = new Text[6];
    public Text[] textname = new Text[6];
    public Text[] textdisc = new Text[6];
    public string[] ItemId = new string[6];

    //�A�b�v�O���[�h�A�C�R��
    public GameObject[] UpgradeItem = new GameObject[8];
    private GameObject[] UpgradeFrame = new GameObject[8];
    private BuyData[] UpgradeItemData = new BuyData[8];

    private int curTab; //���݂̃^�u

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

        GameObject soun = GameObject.Find("SoundObject");
        sounds = soun.GetComponent<Sounds>();

        for (int i = 0; i < 8; i++)
        {
            foreach (Transform child in UpgradeItem[i].transform)
            { 
                switch (child.name)
                {
                    case "Name":
                        UpgradeItemData[i].itemname = child.GetComponent<Text>();
                        break;
                    case "Disc":
                        UpgradeItemData[i].disc = child.GetComponent<Text>();
                        break;
                    case "Price":
                        UpgradeItemData[i].price = child.GetComponent<Text>();
                        break;
                    case "Frame":
                        UpgradeFrame[i] = child.gameObject;
                        break;
                    default:
                        Debug.Log("�A�C�R�����̃I�u�W�F�N�g���擾�ł��܂���ł���");
                        break;
                }
            }
        }
    }

    public void ActiveTradeUI()
    {
        //�A�C�R���̗L����
        foreach(GameObject obj in TradeItem)
        {
            obj.GetComponent<TradeClick>().Active();
        }
        foreach (GameObject obj in UpgradeItem)
        {
            obj.GetComponent<TradeClick>().Active();
        }

        curTab = (int)Tabs.BUY;

        TradeUI.SetActive(true);
        playerManager.dontMove = true;

        ItemId = PIM.GetRandomItem(6, false);

        for ( int i = 0; i < 6; i++)
        {
            if (ItemId[i] != null)
            {
                TradeItem[i].GetComponent<Image>().sprite = itemicon.SearchImage(ItemId[i]);
                textname[i].text = itemmanager.GetItemData(ItemId[i], 0, (int)ItemElement.NAME);
                textdisc[i].text = itemmanager.GetItemData(ItemId[i], 0, (int)ItemElement.DESCRIPTION);
                textamount[i].text = itemmanager.GetBuyingPrice(0).ToString();
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
        GetHaveItemData();
        for (int i = 0; i < 8; i++)
        {
            if (UpgradeItemData[i].id != null)
            {
                //�摜�̎擾
                UpgradeItem[i].GetComponent<Image>().sprite = itemicon.SearchImage(UpgradeItemData[i].id);
                UpgradeFrame[i].GetComponent<Image>().sprite = itemicon.SearchFrame(UpgradeItemData[i].grade);
            }
            //�A�C�e����������Ȃ������ꍇ
            else
            {
                UpgradeItem[i].GetComponent<Image>().sprite = itemicon.Empty();
                UpgradeItemData[i].itemname.text = "NoName";
                UpgradeItemData[i].disc.text = " ";
                UpgradeItemData[i].price.text = "0";
            }

        }
    }

    public void CloseUI()
    {
        TradeUI.SetActive(false);
        playerManager.dontMove = false;
        sounds.MenuCloseSE();//SE ����
    }

    public void OpenUI()
    {
        TradeUI.SetActive(true);
        playerManager.dontMove = true;
    }

    // ActiveItemSelectUI �ŕ\������Ă���A�C�e����I��
    public bool TradeChoice(int objectname, int tab)
    {
        Debug.Log("�X�e�[�^�X�㏸" + objectname);

        switch (tab)
        {
            case (int)Tabs.BUY:

                //�w���֐����Ăяo���A�w���ł����Ȃ�
                if (PIM.BuyingItem(ItemId[objectname]) == true)
                {
                    itemUI.ChangeIcon();//�����A�C�e���A�C�R���X�V
                    GetHaveItemData();
                    sounds.BuySE();//SE �w��
                    return true;
                }
                else
                {
                    sounds.ClickSE();//SE �N���b�N
                    return false;
                }

            case (int)Tabs.UPGRADE:
                //�w���֐����Ăяo���A�w���ł����Ȃ�
                if (PIM.BuyingItem(UpgradeItemData[objectname].id) == true)
                {
                    itemUI.ChangeIcon();//�����A�C�e���A�C�R���X�V
                    sounds.BuySE();//SE �w��
                    return true;
                }
                else
                {
                    sounds.ClickSE();//SE �N���b�N
                    return false;
                }
            default:
                return false;
        }
    }


    //�����A�C�e�����̎擾�֐�
    public void GetHaveItemData()
    {
        //�����A�C�e��ID�擾
        string[] haveitem = new string[PIM.maxItem];
        haveitem = PIM.GetHaveItem();

        foreach(string str in haveitem)
        {
            Debug.Log(str);
        }

        //�����A�C�e����id���瑼�v�f�����߂�
        for (int i = 0; i < PIM.maxItem; i++)
        {
            if (haveitem[i] != null)
            {
                UpgradeItemData[i].id = haveitem[i];

                UpgradeItemData[i].grade = PIM.GetHaveGrade(haveitem[i]) + 1;

                UpgradeItemData[i].itemname.text = itemmanager.GetItemData(
                    haveitem[i], 
                    UpgradeItemData[i].grade, 
                    (int)ItemElement.NAME);

                UpgradeItemData[i].disc.text = itemmanager.GetItemData(
                    haveitem[i], 
                    UpgradeItemData[i].grade, 
                    (int)ItemElement.DESCRIPTION);

                UpgradeItemData[i].price.text = itemmanager.GetBuyingPrice(UpgradeItemData[i].grade).ToString();
            }
        }
    }
}
