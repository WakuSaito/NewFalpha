using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ManagerScene�̃X�N���v�g�Q�ƃ��[�e�B���e�B�N���X
public static class LoadManagerScene
{
    //ManagerScene�̎擾
    static Scene scene = SceneManager.GetSceneByName("ManagerScene");

    //ItemManager�擾�֐�
    public static ItemManager GetItemManager()
    {
        //�q�G�����L�[�̍ŏ�ʂ̃I�u�W�F�N�g���擾�ł���
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            return rootGameObject.GetComponent<ItemManager>();   
        }
        return null;
    }
    //PlayerItemManager�擾�֐�
    public static PlayerItemManager GetPlayerItemManager()
    {
        //�q�G�����L�[�̍ŏ�ʂ̃I�u�W�F�N�g���擾�ł���
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            return rootGameObject.GetComponent<PlayerItemManager>();
        }
        return null;
    }
    //PlayerStatusManager�擾�֐�
    public static PlayerStatusManager GetPlayerStatusManager()
    {
        //�q�G�����L�[�̍ŏ�ʂ̃I�u�W�F�N�g���擾�ł���
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            return rootGameObject.GetComponent<PlayerStatusManager>();
        }
        return null;
    }
    //ItemIcon�擾�֐�
    public static ItemIcon GetItemIcon()
    {
        //�q�G�����L�[�̍ŏ�ʂ̃I�u�W�F�N�g���擾�ł���
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            return rootGameObject.GetComponent<ItemIcon>();
        }
        return null;
    }
}