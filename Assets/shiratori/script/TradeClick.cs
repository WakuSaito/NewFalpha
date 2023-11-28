using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeClick : MonoBehaviour
{
    GameObject traderOBJ;
    Trader trader = new Trader();

    private string objname, objname2;

    private void Start()
    {
        traderOBJ = GameObject.Find("TradeUImanager");
        trader = traderOBJ.GetComponent<Trader>();
    }

    public void Onclick()
    {
        objname = this.name;

        //�@������̍Ōォ��P�����𒊏o����
        objname2 = objname.Substring(objname.Length - 1);

        //�@���o����������𐮐��ɕϊ����ēn��
        trader.TradeChoice(int.Parse(objname2));
    }
}
