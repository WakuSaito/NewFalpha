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
        objboss = GameObject.FindWithTag("Boss");
        //PlayerManager�̓ǂݍ���
        enemyManager = objboss.GetComponent<EnemyManager>();
    }

    //�̗͍X�V�֐�
    public void FixedUpdate()
    {
        //���݂̗̑͂̊������猩���ڂ�ς���
        BosshpBarcurrent.fillAmount = enemyManager.status.CurrentHP / enemyManager.maxHP;
    }
}
