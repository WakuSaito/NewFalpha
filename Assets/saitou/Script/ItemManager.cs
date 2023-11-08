using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//�A�C�e���f�[�^
public class ItemData
{
    public string id;   //�A�C�e��id

    private int count;  //������

    //�R���X�g���N�^
    public ItemData(string id, int count = 1)
    {
        this.id = id;
        this.count = count;
    }

    //�������J�E���g�A�b�v
    public void CountUp(int value = 1)
    {
        count += value;
    }

    //�������J�E���g�_�E��
    public void CountDown(int value = 1)
    {
        count -= value;
    }
}

//�A�C�e���Ǘ��N���X
public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemSourceData> _itemSourceDataList;  //�A�C�e���\�[�X���X�g

    private List<ItemData> _playerItemDataList = new List<ItemData>();  //�v���C���[�̏����A�C�e��


    private void Awake()
    {
        LoadItemSourceData();
    }

    //�A�C�e�������[�h����
    private void LoadItemSourceData()
    {
        _itemSourceDataList = Resources.LoadAll("ScriptableObject", typeof(ItemSourceData)).Cast<ItemSourceData>().ToList();
    }

    //�A�C�e���\�[�X�f�[�^���擾
    public ItemSourceData GetItemSourceData(string id)
    {
        //�A�C�e��������
        foreach (var sourceData in _itemSourceDataList)
        {
            //ID����v���Ă�����
            if (sourceData.id == id)
            {
                return sourceData;
            }
        }
        return null;
    }

}