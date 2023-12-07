using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    public GameObject OriginObjct;//�I���W�i���̃I�u�W�F�N�g
    public GameObject CloneObject;//�N���[������I�u�W�F�N�g

    private bool skillused = false;
    private bool buttonOn = true;  //�{�^���������邩�ǂ���

    private Button button;
    private Color normalColor  = Color.white; //�m�[�}���J���[
    private Color pressedlColor = Color.gray; //�v���X�h�J���[�i������Ă���Ƃ��j


    public float right = 1.0f;
    public float time = 5.0f;
    public float cooldownTime = 10.0f;



    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ChangeColor);
    }

    public void OnClick()
    {

        if (!skillused)
        {
            StartCoroutine(Startskill());

            GameObject a;
            GameObject b;

            //���ݒn���擾
            Vector3 currentPositione = transform.position;


            //�N���[���쐬
            a = Instantiate(CloneObject, OriginObjct.transform.position + (transform.right * right), Quaternion.identity);

            //�N���[���쐬
            b = Instantiate(CloneObject, OriginObjct.transform.position + (transform.right * right * -1.0f), Quaternion.identity);

            //5�b��ɏ���
            Destroy(a, time);
            Destroy(b, time);
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
}
