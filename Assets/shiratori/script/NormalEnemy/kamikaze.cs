using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamikaze : MonoBehaviour
{
    public float speed = 2.0f;

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

    private void FixedUpdate()
    {
        if (moveOn)
        {
            transform.position -= transform.up * (speed * 0.02f);
        }
    }
}
