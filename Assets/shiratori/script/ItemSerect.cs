using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using TMPro;

public class ItemSerect : MonoBehaviour
{

    // ItemSelectUI���i�[����ϐ�
    // �C���X�y�N�^�[����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject ItemSelectUI;
    [SerializeField] private EventSystem eventSystem;
    //[SerializeField] GameObject[] Item = new GameObject[12];

    GameObject SelectButton;
    GameObject FindID;
    //GameObject datainfo;
    ItemManager itemmanager = new ItemManager();
    PlayerItemManager PIM = new PlayerItemManager();
    ItemIcon itemicon = new ItemIcon();

    PlayerManager playerManager;
    ItemUIManager itemUI;
    Sounds sounds;

    public GameObject[] Item = new GameObject[3];
    public Text[] textname = new Text[3];
    public Text[] textdisc = new Text[3];
    public string[] ItemId = new string[3];
    //�@TextMeshProUGUI   ���b�V���v����g���ۂ͂�����

    private bool getItem = false; //���̕󔠂ŃA�C�e�����擾������
    private void Start()
    {
        //datainfo = GameObject.Find("DataInfo");
        itemmanager = LoadManagerScene.GetItemManager();

        PIM = LoadManagerScene.GetPlayerItemManager();
        itemicon = LoadManagerScene.GetItemIcon();

        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();

        GameObject canv = GameObject.Find("Canvas");
        itemUI = canv.GetComponent<ItemUIManager>();

        GameObject soun = GameObject.Find("SoundObject");
        sounds = soun.GetComponent<Sounds>();

        getItem = false;
    }

    public void ActiveItemSelectUI()
    {
        sounds.Treasure_ChestSE();//�󔠂��J������
        ItemSelectUI.SetActive(true);
        playerManager.dontMove = true;

        ItemId = itemmanager.GetRandomItem(3) ;

        for (int i = 0; i < 3; i++)
        {
            if (ItemId[i] != null)
            {
                Item[i].GetComponent<Image>().sprite = itemicon.SearchImage(ItemId[i]);
                textname[i].text = itemmanager.GetName(ItemId[i]);
                textdisc[i].text = itemmanager.GetDescription(ItemId[i]);
            }
            //�A�C�e����������Ȃ������ꍇ
            else
            {
                
                Item[i].GetComponent<Image>().sprite = itemicon.Empty();
                textname[i].text = "NoName";
                textdisc[i].text = " ";
            }

        }

    }

    public void CloseUI()
    {
        ItemSelectUI.SetActive(false);
        playerManager.dontMove = false;
        sounds.MenuCloseSE();//SE ����
    }

    public void OpenUI()
    {
        //�܂����̕󔠂���A�C�e�����擾���Ă��Ȃ��Ȃ�
        if (getItem == false)
        {
            ItemSelectUI.SetActive(true);
            playerManager.dontMove = true;
        }
    }

    // ActiveItemSelectUI �ŕ\������Ă���A�C�e����I��
    public void ItemChoice(int objectname)
    {
        Debug.Log("�X�e�[�^�X�㏸" + objectname);

        //�A�C�e���ǉ��֐����Ăяo���āA�擾�o������
        if (PIM.AddItem(ItemId[objectname]) == true)
        {
            getItem = true;
            sounds.ClickSE();
            itemUI.ChangeIcon();//�����A�C�e���A�C�R���X�V

            CloseUI();//UI�����
        }
        
    }

}