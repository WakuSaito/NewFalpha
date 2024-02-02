using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    [SerializeField] private Image BosshpBarcurrent;

    EnemyManager enemyManager;//PlayerManager�X�N���v�g
    GameObject objboss;

    //private float currentHealth;//���݂̗̑�

    void Start()
    {
        
    }

    //�̗͍X�V�֐�
    public void FixedUpdate()
    {
        objboss = GameObject.FindWithTag("Boss");
        //PlayerManager�̓ǂݍ���
        enemyManager = objboss.GetComponent<EnemyManager>();

        //���݂̗̑͂̊������猩���ڂ�ς���
        BosshpBarcurrent.fillAmount = enemyManager.status.CurrentHP / enemyManager.maxHP;
    }
}
