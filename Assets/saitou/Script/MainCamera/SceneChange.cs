using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���֘A�p

public class SceneChange : MonoBehaviour
{
    public string gameScene;    //���C���Q�[���V�[��
    public string titleScene;   //�^�C�g���V�[��
    public string clearScene;   //�N���A�V�[��
    public string gameoverScene;//�Q�[���I�[�o�[�V�[��

    public float changeTime = 0.3f;//�V�[���`�F���W����


    public void StageClear()
    {
        //�N���A��ʂɈڍs
        StartCoroutine(ChangeCooltime(changeTime, clearScene));
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[��ʂɈڍs
        StartCoroutine(ChangeCooltime(changeTime, gameoverScene));
    }
    public void GameStart()
    {
        //���C���Q�[����ʂɈڍs
        StartCoroutine(ChangeCooltime(changeTime, gameScene));
    }
    public void Title()
    {
        //�^�C�g����ʂɈڍs
        SceneManager.LoadScene(titleScene);
    }


    //�����V�[���`�F���W�R���[�`��
    private IEnumerator ChangeCooltime(float sec, string scene)
    {
        yield return new WaitForSeconds(sec);//���������҂�

        SceneManager.LoadScene(scene);//�V�[���؂�ւ�
    }
}
