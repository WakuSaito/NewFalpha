using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�A�C�e���̃\�[�X�f�[�^
[CreateAssetMenu(menuName = "SaitoAssets/ItemSourceData")]
public class ItemSourceData : ScriptableObject
{
    //�A�C�e�����ʗpid
    [SerializeField] private string _id;
    //id���擾
    public string id
    {
        get { return _id; }
    }

    //�A�C�e���̖��O
    [SerializeField] private string _itemName;
    //�A�C�e�������擾
    public string itemName
    {
        get { return _itemName; }
    }

    //�A�C�e���̌�����
    [SerializeField] private Sprite _sprite;
    //�A�C�e���̌����ڂ��擾
    public Sprite sprite
    {
        get { return _sprite; }
    }

    //�A�C�e���̐���
    [SerializeField] private string _itemDescription;
    //�A�C�e���̐������擾
    public string itemDescription
    {
        get { return _itemDescription; }
    }

    //���l
    [SerializeField] private int _buyingPrice;
    //���l���擾
    public int buyingPrice
    {
        get { return _buyingPrice; }
    }

}

