using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    public GameObject OriginObject;//�I���W�i���̃I�u�W�F�N�g
    public GameObject CloneObject;//�N���[������I�u�W�F�N�g

    private bool skillused = false;
    private bool buttonOn = true;  //�{�^���������邩�ǂ���

    private Button button;
    private Color normalColor  = Color.white; //�m�[�}���J���[
    private Color pressedlColor = Color.gray; //�v���X�h�J���[�i������Ă���Ƃ��j


    public float right = 1.0f;
    public float time = 5.0f;
    public float cooldownTime = 10.0f;

    GameObject manager;
    PlayerItemManager playeritem;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ChangeColor);

        playeritem = LoadManagerScene.GetPlayerItemManager();
    }

    public void OnClick()
    {

        if (!skillused)
        {
            playeritem.onskill = true;
            StartCoroutine(Startskill());

            GameObject a;
            GameObject b;

            //�N���[���쐬�@���ɂ���I�u�W�F�N�g�̍��E�Ɏq�Ƃ��Đ���
            a = Instantiate(CloneObject, OriginObject.transform.position + (transform.right * right), Quaternion.identity, OriginObject.transform);
            b = Instantiate(CloneObject, OriginObject.transform.position + (transform.right * right * -1.0f), Quaternion.identity, OriginObject.transform);

            //���I�u�W�F�N�g���猩�Ăǂ̈ʒu�ɌŒ肷�邩
            a.GetComponent<PlayerClone>().clonePos = new Vector3(1,  0, 0);
            b.GetComponent<PlayerClone>().clonePos = new Vector3(-1, 0, 0);

            //5�b��ɏ���
            StartCoroutine(DestroyClone(a, b));
            //Destroy(a, time);
            //Destroy(b, time);
        }
    }

    private void ChangeColor()
    {
        if (buttonOn == true)//�{�^�����������ԂȂ�
        {
            buttonOn = false;
            //�{�^���̃J���[��ύX
            gameObject.GetComponent<Image>().color = pressedlColor;

            //�{�^�����ēx���̃J���[�ɖ߂����߂̃R���[�`�����Ăяo����
            StartCoroutine(ResetColor());
        }
    }
    private IEnumerator ResetColor()
    {
        
        yield return new WaitForSeconds(cooldownTime);//10�b��Ɍ��̃J���[�ɖ߂�

        gameObject.GetComponent<Image>().color = normalColor;//�{�^���̃J���[��߂�

        buttonOn = true;
    }
    IEnumerator Startskill()
    {
        skillused = true;

        yield return new WaitForSeconds(cooldownTime);

        skillused = false;
    }

    IEnumerator DestroyClone(GameObject a, GameObject b)
    {
        yield return new WaitForSeconds(time);

        Destroy(a);
        Destroy(b);

        playeritem.onskill = false;
    }
}
