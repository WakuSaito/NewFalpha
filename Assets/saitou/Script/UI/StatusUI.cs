using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public Text money;

    PlayerStatusManager playerStatusManager;

    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g�̎擾
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money : " + playerStatusManager.status.Money;
    }
}
