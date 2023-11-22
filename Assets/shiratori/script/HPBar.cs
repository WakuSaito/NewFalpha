using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image hpBarcurrent;
    private float maxHP;        //�ő�̗�
    private float currentHP;    //���ݑ̗�
    
    PlayerStatusManager playerStatusManager;//PlayerManager�X�N���v�g

    //private float currentHealth;//���݂̗̑�

    void Start()
    {
        //PlayerManager�̓ǂݍ���
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();

        //�ő�̗͂�PlayermStatusManager����Q��
        maxHP = playerStatusManager.MaxHP;

        ////���݂�HP��������
        //currentHealth = maxHealth;
    }

    //�̗͍X�V�֐�
    public void Update()
    {
        hpBarcurrent.fillAmount = playerStatusManager.GetHPper();
    }
}
