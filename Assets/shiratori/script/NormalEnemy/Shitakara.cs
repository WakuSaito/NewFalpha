using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitakara : MonoBehaviour
{
    GameObject playerObj;
    public GameObject enemy; // �G�̃Q�[���I�u�W�F�N�g
    public GameObject attackEffect; // �U���G�t�F�N�g

    Vector3 playerCenterPosition;


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
        playerObj = GameObject.Find("player");
        
    }

    private void FixedUpdate()
    {
        if (moveOn)
        {
            time += 0.02f;//1�b��1������

            //time���N�[���^�C���𒴂�����
            if (time >= coolTime)
            {
                Attack();
                time = 0.0f;
            }
        }
    }

    void Attack()
    {
        if (enemy != null)
        {
            // �v���C���[�̒��S�ʒu���擾
            playerCenterPosition = playerObj.transform.position;
           //Invoke("sisyou", 0.5f);
            // �U���G�t�F�N�g�𐶐�
            if (attackEffect != null)
            {
                Instantiate(attackEffect, playerCenterPosition, Quaternion.identity);
                // �����ɍU���G�t�F�N�g�̔������Ȃǂ�ǉ�����

                // �U���͈͓��̓G�Ƀ_���[�W��^���鏈���Ȃǂ������ɒǉ�����
            }
        }
    }
   
}
