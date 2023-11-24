using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierManager : MonoBehaviour
{
    [SerializeField] private Image BarrierBarcurrent;
    private float barrierMax = 100.0f; //�o���A�Q�[�W�̒���
    [SerializeField] private float barrierDec = 3.0f;   //1�b�ԂɌ��炷�o���A�Q�[�W

    [SerializeField]
    private float barrierCur; //���݂̃o���A
    private bool on75 = false;//�o���A��75%�ȉ��ɂȂ�����
    private bool on50 = false;//�o���A��50%�ȉ��ɂȂ�����
    private bool on25 = false;//�o���A��25%�ȉ��ɂȂ�����
    private bool on0 = false; //�o���A��0�ȉ��ɂȂ�����

    PlayerStatusManager playerStatusManager;

    private void Start()
    {
        //PlayerStatusManager���擾
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();

        //���݂̃o���A�̏�����
        barrierCur = barrierMax;     
    }
    private void FixedUpdate()
    {
        barrierCur -= barrierDec * 0.02f; //1�b��barrierDec���X�V

        //���݂̃o���A�̊������A�Q�[�W��ς���
        BarrierBarcurrent.fillAmount = barrierCur / barrierMax;

        //�o���A��75%�ȉ��ɂȂ����Ƃ���x����
        if (barrierCur == 75.0f && !on75)
        {
            on75 = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playerStatusManager.ChangeBarrier(2);

            Debug.Log("�o���A�������ȉ�");
        }
        //�o���A�������ȉ��ɂȂ����Ƃ���x����
        if (barrierCur == 50.0f && !on50)
        {
            on50 = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playerStatusManager.ChangeBarrier(2);

            Debug.Log("�o���A�������ȉ�");
        }
        //�o���A��25%�ȉ��ɂȂ����Ƃ���x����
        if (barrierCur == 25.0f && !on25)
        {
            on25 = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playerStatusManager.ChangeBarrier(2);

            Debug.Log("�o���A�������ȉ�");
        }
        //�o���A��0�ȉ��ɂȂ����Ƃ���x����
        if (barrierCur == 0.0f && !on0)
        {
            on0 = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playerStatusManager.ChangeBarrier(4);

            Debug.Log("�o���A��0�ȉ�");
        }
        //���Z�b�g�t���O���I���ɂȂ����Ƃ�
        if(playerStatusManager.onResetHpBr == true)
        {
            //�o���A�Q�[�W�̏�����
            barrierCur = barrierMax;
            //�t���O�̏�����
            on75 = false;
            on50 = false;
            on25 = false;
            on0  = false;

            //�t���O��������
            playerStatusManager.onResetHpBr = false;
        }
    }
}
