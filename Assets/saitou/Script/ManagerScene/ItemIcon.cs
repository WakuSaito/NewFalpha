using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�R���摜���Ǘ����A�T���N���X
public class ItemIcon : MonoBehaviour
{
    //�A�C�e���A�C�R���摜������z��
    [SerializeField] private Sprite[] iconImage = new Sprite[20];
    
    //�A�C�R���T���֐�
    public Sprite SearchImage(string id)
    {
        switch(id)
        {
            //ID�ɃA�C�e����ID�������Ă���
            case "ID":
                return iconImage[0];
            
            default:
                Debug.Log("!�A�C�e���摜��������܂���");
                return null;    
        }
    }
}
