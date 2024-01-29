using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpUI : MonoBehaviour
{
    public Text HP;

    GameObject Boss;
    EnemyManager enemyManager;

    //CreateMap�X�N���v�g��T��
    CreateMap createMap;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Main Camera");
        createMap = obj.GetComponent<CreateMap>();
    }

    // Update is called once per frame
    void Update()
    {

        if (createMap.isMakeBoss == true) 
        {
            Boss = GameObject.FindWithTag("Boss");
            enemyManager = Boss.GetComponent<EnemyManager>();
        }

        //�ő�̗͂ƌ��݂̗̑͂�\��
        HP.text = "HP " + (int)enemyManager.status.CurrentHP + " / " + (int)enemyManager.maxHP;
    }
}
