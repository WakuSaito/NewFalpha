using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform Enemy04Transform;
    GameObject playerObj;

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

    private void Start()
    {
        playerObj = GameObject.Find("Player");
        Vector2 EnemyPos = transform.position;
    }

    public void Swap()
    {
        //Vector2 PlayerPos = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y);
        //PlayerTransform.position = Enemy04Transform.position;
        transform.position = playerObj.transform.position + transform.up;
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
