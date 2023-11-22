using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���֘A�p

public class SceneChange : MonoBehaviour
{
    public string[] stageScene = new string[3];  //�X�e�[�W���ꂼ��̃V�[����
    public string clearScene;   //�N���A�V�[��
    public string gameoverScene;//�Q�[���I�[�o�[�V�[��

    private string nextStage;   //�؂�ւ���V�[��������
    private int stageCount = 0; //���X�e�[�W�ڂ��i�ŏ��͂P�X�e�[�W�ځj

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextStage()
    {
        //stageCount��3�����̏ꍇ�A���X�e�[�W�ɐ؂�ւ�
        if (stageCount < 3)
        {
            //nextStage�����݉��X�e�[�W�ڂ��ɂ���ĕς���
            nextStage = stageScene[stageCount];

            //�V�[���̐؂�ւ�
            Debug.Log(nextStage + "�ɐ؂�ւ��܂�");
            SceneManager.LoadScene(nextStage);
            Debug.Log(nextStage + "�؂�ւ��܂���");

            //�X�e�[�W�J�E���g��1�i�߂�
            stageCount++;
        }
        else
        {
            //�N���A��ʂɈڍs
            SceneManager.LoadScene(clearScene);
        }
    }
}
