using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemObjectManager : MonoBehaviour
{
    public string itemId = "str_up";    //���̃I�u�W�F�N�g�̃A�C�e��ID
    public float destroyTime = 0.1f;    //������܂ł̎���

    PlayerItemManager playerItemManager;
    ItemManager itemManager;
    ItemUIManager itemUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player�^�O�Ƃ̐ڐG��
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�A�C�e���l��");

            //�X�N���v�g���擾
            playerItemManager = LoadManagerScene.GetPlayerItemManager();
            itemManager = LoadManagerScene.GetItemManager();

            GameObject obj = GameObject.Find("Canvas");
            itemUI = obj.GetComponent<ItemUIManager>();


            //�����_���ȃA�C�e����ID���擾
            itemId = itemManager.GetRandomItem();

            Debug.Log(itemId + "���擾");

            //���̃I�u�W�F�N�g�̃A�C�e��ID���擾������
            playerItemManager.AddItem(itemId);

            //�A�C�R���X�V
            itemUI.ChangeIcon();

            //���̃I�u�W�F�N�g���폜
            Destroy(gameObject, destroyTime);
        }
    }
}

