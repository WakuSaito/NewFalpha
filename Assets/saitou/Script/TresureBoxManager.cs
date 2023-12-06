using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxManager : MonoBehaviour
{
    private bool open = false;//�󔠂��J���Ă��邩

    public Sprite closeImg;//�����摜
    public Sprite openImg; //�J�����摜

    private SpriteRenderer spriteRenderer;

    public GameObject itemObj;//�A�C�e���I�u�W�F�N�g

    private ItemSerect itemSerect;

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer���擾
        spriteRenderer = GetComponent<SpriteRenderer>();

        //ItemSerect�X�N���v�g��T��
        GameObject obj = GameObject.Find("UImanager");
        itemSerect = obj.GetComponent<ItemSerect>();

        //�����̉摜������摜�ɂ���
        spriteRenderer.sprite = closeImg;

        open = false;
    }
    
    //�󔠂��J����֐�
    public void OpenBox()
    {
        //�󂢂Ă��Ȃ��Ȃ�
        if (open == false)
        {
            open = true;
            Debug.Log("�󔠂��J����");

            //�J�����摜�ɕς���
            spriteRenderer.sprite = openImg;    

            //�󔠗pUI��\������
            itemSerect.ActiveItemSelectUI();
        }
        else
        {
            Debug.Log("���łɊJ���Ă��܂�");
            itemSerect.OpenUI();
        }
    }
}
