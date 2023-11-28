using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderManager : MonoBehaviour
{
    public bool shopCount = false;  //���łɂ��̃V���b�v���J������ 

    private Trader traderUI;

    private void Start()
    {
        shopCount = false;

        //ItemSerect�X�N���v�g��T��
        GameObject obj = GameObject.Find("TradeUImanager");
        traderUI = obj.GetComponent<Trader>();
    }

    //����J�n�֐�
    public void OpenShop()
    {
        if (shopCount == false)
        {
            shopCount = true;

            //UI�̏�����
            traderUI.ActiveTradeUI();
        }
        else
        {
            //UI���J��
            traderUI.OpenUI();
        }
    }
}
