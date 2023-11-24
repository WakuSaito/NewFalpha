using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectClick : MonoBehaviour
{
    GameObject selectOBJ;
    ItemSerect itemselect = new ItemSerect();

    private string objname, objname2;

    private void Start()
    {
        selectOBJ = GameObject.Find("UImanager");
        itemselect = selectOBJ.GetComponent<ItemSerect>();
    }

    public void Onclick()
    {
        objname = this.name;

        //�@������̍Ōォ��P�����𒊏o����
        objname2 = objname.Substring(objname.Length - 1);

        //�@���o����������𐮐��ɕϊ����ēn��
        itemselect.ItemChoice(int.Parse(objname2));
    }
}
