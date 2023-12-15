using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitakara : MonoBehaviour
{
    GameObject playerObj;

    Vector3 playerCenterPosition;

    EnemyAttack enemyAttack;//�U���p�X�N���v�g


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

        enemyAttack = GetComponent<EnemyAttack>();

        //�ŏ��̍U���^�C�~���O�𗐐��ŏ����ς���
        time = Random.RandomRange(0.0f, coolTime / 2);

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
        // �v���C���[�̒��S�ʒu���擾
        playerCenterPosition = playerObj.transform.position;
        //Invoke("sisyou", 0.5f);

        StartCoroutine(DelayAttack());//�U���ɒx��
    }

    //�U���ɒx����������R���[�`��
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.2f);//�x��

        // �U���G�t�F�N�g�𐶐�
        enemyAttack.Attack(playerCenterPosition);
    }


}
