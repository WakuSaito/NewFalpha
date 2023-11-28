using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitakara : MonoBehaviour
{
    GameObject playerObj;
    public GameObject enemy; // �G�̃Q�[���I�u�W�F�N�g
    public GameObject attackEffect; // �U���G�t�F�N�g
    public float attackRange = 1.5f;
    public float attackCooldown = 2.5f; // �U���̃N�[���_�E������
    public float timeSinceLastAttack = 0f; // �Ō�ɍU����������

    Vector3 playerCenterPosition;


    private void Start()
    {
        playerObj = GameObject.Find("player");
        
    }
    void Update()
    {
        // ���Ԃ̌o�߂�ǐ�
        timeSinceLastAttack += Time.deltaTime ;

        //�N�[���_�E�����Ԃ��o�߂�����U��
        if ( timeSinceLastAttack >= attackCooldown)
        {
            Attack();
            timeSinceLastAttack = 0f; // �U�������̂ŃN�[���_�E�������Z�b�g
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

    void sisyou()
    {
        // �U���͈͓����ǂ����𔻒�
        if (Vector3.Distance(playerObj.transform.position, playerCenterPosition) <= attackRange)
        {
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
