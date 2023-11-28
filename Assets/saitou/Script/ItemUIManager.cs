using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    public bool onChange = false; 

    //�C���X�y�N�^�[��ɕ\������Ȃ��i���������R���p�C���G���[�j
    [SerializeField] private float iconFirstPosX;   //�A�C�R���̏����ʒuX�i����j
    [SerializeField] private float iconFirstPosY;   //�A�C�R���̏����ʒuY�i����j
    [SerializeField] private float iconPos;         //�A�C�R���ʒu�����p
    [SerializeField] private GameObject iconPrefab; //��������Prefab    
    
    [SerializeField]
    private Transform iconParent; //���̐e�I�u�W�F�N�g
    private GameObject[] iconObj = new GameObject[20]; //�N���[�������I�u�W�F�N�g

    PlayerItemManager playerItemManager;
    ItemIcon itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        int column = 0;
        int row = 0;

        //�R���p�C���G���[�͂����炭����̂���
        //�X�N���v�g�̎擾
        playerItemManager = LoadManagerScene.GetPlayerItemManager();
        itemIcon = LoadManagerScene.GetItemIcon();

        //Icon���܂Ƃ߂�p�̃I�u�W�F�N�g�𐶐����ACanvas�̎q�ɂ���
        //iconParent = new GameObject("Icon").transform;
        //iconParent.SetParent(gameObject.transform);

        //�N���[���i�A�C�R���j����
        for(int i = 0; i < iconObj.Length; i++)
        {
            Debug.Log("�A�C�R���쐬");

            //�q�Ƃ���Image������Prefab���N���[��
            iconObj[i] = Instantiate(iconPrefab, //�N���[������I�u�W�F�N�g
                new Vector2(iconParent.position.x + iconFirstPosX + (iconPos * column),
                            iconParent.position.y + iconFirstPosY + (iconPos * -row)),//leftInfo�n�_�̈ʒu
                Quaternion.identity,
                iconParent);//��]

            if (column < 3)
            {
                column++;
            }
            else
            {
                column = 0;
                row++;
            }
        }
    }

    //�A�C�R���X�V�֐�
    public void ChangeIcon()
    {
        Debug.Log("�A�C�e���A�C�R���X�V");
        Sprite iconImage; //�T�����摜������p�̕ϐ�

        //�A�C�R���̉摜�������A�C�e���ɂ���ĕς���
        for (int i = 0; i < playerItemManager.havingItem.Count; i++)
        {
            //�����A�C�e������摜��T��
            iconImage = itemIcon.SearchImage(playerItemManager.havingItem[i]);

            //�G���[�łȂ����
            if (iconImage != null)
            {
                //�N���[���̉摜��ς���
                iconObj[i].GetComponent<Image>().sprite = iconImage;
            }
        }
    }

    private void Update()
    {
        if (onChange)
        {
            ChangeIcon();
            onChange = false;
        }
    }
}
