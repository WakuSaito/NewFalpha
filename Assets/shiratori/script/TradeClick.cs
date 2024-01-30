using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeClick : MonoBehaviour
{
    GameObject traderOBJ;
    Trader trader = new Trader();

    int thisTab;
    private string objname, objname2;
    bool onactive;

    private void Start()
    {
        traderOBJ = GameObject.Find("TradeUImanager");
        trader = traderOBJ.GetComponent<Trader>();

        Active();

        switch (transform.parent.gameObject.name)
        {
            case "BuyTab":
                thisTab = (int)Tabs.BUY;
                break;
            case "UpgradeTab":
                thisTab = (int)Tabs.UPGRADE;
                break;
        }
    }

    public void Onclick()
    {
        if (onactive)
        {
            objname = this.name;

            //�@������̍Ōォ��P�����𒊏o����
            objname2 = objname.Substring(objname.Length - 1);

            
            //�@���o����������𐮐��ɕϊ����ēn��
            if (trader.TradeChoice(int.Parse(objname2),thisTab) == true)
            {
                onactive = false;
                gameObject.GetComponent<Image>().color = Color.gray;
            }
        }    
    }

    public void Active()
    {
        onactive = true;
        gameObject.GetComponent<Image>().color = Color.white;
    }

}
