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

    public void StageClear()
    {
        //�N���A��ʂɈڍs
        SceneManager.LoadScene(clearScene);
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[��ʂɈڍs
        SceneManager.LoadScene(gameoverScene);
    }
    public void GameStart()
    {
        //���C���Q�[����ʂɈڍs
        SceneManager.LoadScene(gameScene);
    }
    public void Title()
    {
        //�^�C�g����ʂɈڍs
        SceneManager.LoadScene(titleScene);
    }
}
