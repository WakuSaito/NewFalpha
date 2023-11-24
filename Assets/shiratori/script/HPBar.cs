using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image hpBarcurrent;
    
    PlayerStatusManager playerStatusManager;//PlayerManager�X�N���v�g

    //private float currentHealth;//���݂̗̑�

    void Start()
    {
        //PlayerManager�̓ǂݍ���
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();
    }

    //�̗͍X�V�֐�
    public void Update()
    {
        //���݂̗̑͂̊������猩���ڂ�ς���
        hpBarcurrent.fillAmount = playerStatusManager.HPper();
    }
}
