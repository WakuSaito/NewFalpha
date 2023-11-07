using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierManager : MonoBehaviour
{
    [SerializeField] private Image BarrierBarcurrent;

    public float barrierMax = 100.0f; //�o���A�̍ő�
    public float barrierDec = 2.0f;   //1�b�ԂɌ��炷�o���A�Q�[�W
    [SerializeField]
    private float barrierCur; //���݂̃o���A
    private bool halfOn = false;//�o���A�������ȉ��ɂȂ�����
    private bool zeroOn = false;//�o���A��0�ȉ��ɂȂ�����

    GameObject playerObj;
    PlayerManager playermanager;

    private void Awake()
    {
        //PlayerManager��T��
        playerObj = GameObject.Find("Player");
        playermanager = playerObj.GetComponent<PlayerManager>();

        //���݂̃o���A�̏�����
        barrierCur = barrierMax;
        
    }
    public void UpdateBarrier()
    {
        barrierCur -= barrierDec * 0.02f; //1�b��barrierDec���X�V

        //���݂̃o���A�̊������A�Q�[�W��ς���
        BarrierBarcurrent.fillAmount = barrierCur / barrierMax;

        //�o���A�������ȉ��ɂȂ����Ƃ���x����
        if(barrierCur / barrierMax < 0.5f && !halfOn)
        {
            halfOn = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playermanager.barrierCur = 1.5f;

            Debug.Log("�o���A�������ȉ�");
        }
        //�o���A��0�ȉ��ɂȂ����Ƃ���x����
        if (barrierCur / barrierMax < 0.0f && !zeroOn)
        {
            zeroOn = true;//�t���O�𗧂Ăē����Ȃ��悤�ɂ���

            //Player�̃o���A�l�̕ω�
            playermanager.barrierCur = 0.5f;

            Debug.Log("�o���A��0�ȉ�");
        }
    }
}
