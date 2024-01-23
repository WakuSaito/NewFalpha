using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�R���摜���Ǘ����A�T���N���X
public class ItemIcon : MonoBehaviour
{
    //�A�C�e���A�C�R���摜������z��
    [SerializeField] private Sprite[] iconImage = new Sprite[20];
    [SerializeField] private Sprite[] frameImage = new Sprite[3];

    [SerializeField] private Sprite emptyIconImage;
    
    //�A�C�R���T���֐�
    public Sprite SearchImage(string id)
    {
        switch(id)
        {
            //ID�ɃA�C�e����ID�������Ă���
            case "Attack":
                return iconImage[0];
            case "ArmorPlate":
                return iconImage[1];
            case "Health":
                return iconImage[2];
            case "CRITRate":
                return iconImage[3];
            case "CRITDmg":
                return iconImage[4];
            case "Fencing1":
                return iconImage[5];
            case "Fencing2":
                return iconImage[6];
            case "Throwable1":
                return iconImage[7];
            case "Throwable2":
                return iconImage[8];
            case "Revenge":
                return iconImage[9];
            case "Collector":
                return iconImage[10];
            case "FirstAttack":
                return iconImage[11];
            case "SelfHarm":
                return iconImage[12];
            case "MoneyTalent":
                return iconImage[13];
            default:
                Debug.Log("!�A�C�e���摜��������܂���");
                return emptyIconImage;    
        }
    }
    //�Ή�����g��Ԃ��֐�
    public Sprite SearchFrame(int grade)
    {
        return frameImage[grade];
    }
    //��̃A�C�R���擾�֐�
    public Sprite Empty()
    {
        return emptyIconImage;//��A�C�R����Ԃ�
    }
}
