using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{

    public Text HP;

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
        //�ő�̗͂ƌ��݂̗̑͂�\��
        HP.text = "HP " + playerStatusManager.status.CurrentHP + " / " + playerStatusManager.MaxHP();
    }
}
