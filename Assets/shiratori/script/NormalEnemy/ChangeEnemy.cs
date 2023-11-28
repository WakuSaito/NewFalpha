using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    public Transform object1;
    public Transform object2;

    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p

    private bool moveOn = false;//�s���\�t���O


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�A�N�e�B�u�G���A���ɓ�������
        if (collision.gameObject.tag == "ActiveArea")
        {
            moveOn = true;//�s���\�t���O���I��
            Debug.Log("�s���\");
        }
    }

    void Swap()
    {
        Vector3 tempPos = object1.position;
        object1.position = object2.position;
        object2.position = tempPos;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moveOn)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                Swap();
                time = 0.0f;
            }
        }
    }
}
