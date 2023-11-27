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

    public GameObject[] Item = new GameObject[3];
    public Text[] textname = new Text[3];
    public Text[] textdisc = new Text[3];
    public string[] ItemId = new string[3];
    //�@TextMeshProUGUI   ���b�V���v����g���ۂ͂�����
    private void Start()
    {
        //datainfo = GameObject.Find("DataInfo");
        itemmanager = LoadManagerScene.GetItemManager();

        PIM = LoadManagerScene.GetPlayerItemManager();
        itemicon = LoadManagerScene.GetItemIcon();
    }

    public void ActiveItemSelectUI()
    {
        ItemSelectUI.SetActive(true);

        ItemId = itemmanager.GetRandomItem(3) ;

        for (int i = 0; i < 3; i++)
        {
             
            Item[i].GetComponent<Image>().sprite = itemicon.SearchImage(ItemId[i]);
            textname[i].text = itemmanager.GetName(ItemId[i]);
            textdisc[i].text = itemmanager.GetDescription(ItemId[i]);

        }

        //string Id =itemmanager.GetRandomItem();
        //string name = itemmanager.GetName(Id);
        //string discription = itemmanager.GetDescription(Id);

        //itemname = name;
        // �����_����3�̃A�C�e�����A�N�e�B�u�ɂ���
        //ActivateRandomItems(3);
    }

    // ActiveItemSelectUI �ŕ\������Ă���A�C�e����I��
    public void ItemChoice(int objectname)
    {

        PIM.AddItem(ItemId[objectname]); Debug.Log("�X�e�[�^�X�㏸"+objectname);
        ItemSelectUI.SetActive(false);
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