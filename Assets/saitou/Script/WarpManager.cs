using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public GameObject checkText;  //�\������e�L�X�g
    Transform canvas;            //�L�����o�X
    GameObject ui;                //�N���[���Ǘ��p

    CreateMap createMap;          //�}�b�v�����X�N���v�g

    bool ontext = false;          //text���\������Ă��邩�ǂ���

    void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�ƐڐG
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("���[�v�]�[���ɓ�����");

            //CreateMap�X�N���v�g���擾
            GameObject obj = GameObject.Find("Main Camera");
            createMap = obj.GetComponent<CreateMap>();

            //Canvas��Transform���擾
            GameObject parent = GameObject.Find("Canvas");
            canvas = parent.transform;

            ui = Instantiate(checkText, canvas.position + transform.up*20f, Quaternion.identity, canvas);

            ontext = true;   
        }
    }

    private void Update()
    {
        if (ontext)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //�}�b�v�����t���O���I��
                createMap.onNext = true;

                Destroy(ui);
                ontext = false;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(ui);
                ontext = false;
            }
        }
    }
}
