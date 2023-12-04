using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�R���摜���Ǘ����A�T���N���X
public class ItemIcon : MonoBehaviour
{
    //�A�C�e���A�C�R���摜������z��
    [SerializeField] private Sprite[] iconImage = new Sprite[20];
    [SerializeField] private Sprite emptyIconImage;
    
    //�A�C�R���T���֐�
    public Sprite SearchImage(string id)
    {
        switch(id)
        {
            //ID�ɃA�C�e����ID�������Ă���
            case "Attack":
                return iconImage[0];
                break;
            case "Revenge":
                return iconImage[1];
                break;
            case "SelfHarm":
                return iconImage[2];
                break;
            case "Health":
                return iconImage[3];
                break;
            case "HealthTreat":
                return iconImage[4];
                break;
            case "ArmorPlate":
                return iconImage[5];
                break;
            case "CRITRate":
                return iconImage[6];
                break;
            case "CRITDmg":
                return iconImage[7];
                break;
            case "Throwable2":
                return iconImage[8];
                break;
            case "Fencing2":
                return iconImage[9];
                break;
            case "Fencing1":
                return iconImage[10];
                break;
            case "Throwable1":
                return iconImage[11];
                break;
            case "Collector":
                return iconImage[12];
                break;
            case "FirstAttack":
                return iconImage[13];
                break;
            case "MoneyTalent":
                return iconImage[14];
                break;
            default:
                Debug.Log("!�A�C�e���摜��������܂���");
                return emptyIconImage;    
        }
    }
    //��̃A�C�R���擾�֐�
    public Sprite Empty()
    {
        return emptyIconImage;//��A�C�R����Ԃ�
    }
}
