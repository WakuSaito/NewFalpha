using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxManager : MonoBehaviour
{
    public Sprite closeImg;//�����摜
    public Sprite openImg; //�J�����摜

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer���擾
        spriteRenderer = GetComponent<SpriteRenderer>();

        //�����̉摜������摜�ɂ���
        spriteRenderer.sprite = closeImg;
    }
    
    //�󔠂��J����֐�
    public void OpenBox()
    {
        //�J�����摜�ɕς���
        spriteRenderer.sprite = openImg;
    }
}
