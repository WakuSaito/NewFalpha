using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSerect : MonoBehaviour
{
    // ItemSelectUI���i�[����ϐ�
    // �C���X�y�N�^�[����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject ItemSelectUI;
    [SerializeField] GameObject[] Item = new GameObject[12];

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ActiveItemSelectUI();
        }
    }

    public void ActiveItemSelectUI()
    {
        ItemSelectUI.SetActive(true);

        // �����_����3�̃A�C�e�����A�N�e�B�u�ɂ���
        ActivateRandomItems(3);
    }

    void ActivateRandomItems(int count)
    {
        // ���ׂẴA�C�e�����A�N�e�B�u�ɂ���
        foreach (var item in Item)
        {
            item.SetActive(false);
        }

        List<int> selectedIndices = new List<int>();

        //�����_���ȃA�C�e����I��
        while (selectedIndices.Count < count)
        {
            int randomIndex = Random.Range(0, Item.Length);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        // �I�����ꂽ�A�C�e�����A�N�e�B�u�ɂ���
        foreach (int index in selectedIndices)
        {
            if (index >= 0 && index < Item.Length)
            {
                Item[index].SetActive(true);
            }
        }
    }
}
