using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public float enemyHP;       //�G�I�u�W�F�N�gHP

    public GameObject ClearText;//�N���A�e�L�X�g

    //��collider�ڐG��
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerManager playermanager;
        GameObject obj = GameObject.Find("Player");
        playermanager = obj.GetComponent<PlayerManager>();

        Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);

        //���Ƃ̐ڐG
        if (other.gameObject.tag == "Sword")
        {
            Debug.Log("���̃_���[�W");
            enemyHP -= playermanager.SwordDamage; //HP�����_���[�W�����炷
        }
        //�藠���Ƃ̐ڐG
        if (other.gameObject.tag == "Syuriken")
        {
            Debug.Log("�藠���̃_���[�W");
            enemyHP -= playermanager.SyurikenDamage; //HP���藠���_���[�W�����炷
        }
        //�|��邩���ׂ�
        EnemyDead();
    }

    //�|��邩���ׂ�֐�
    void EnemyDead()
    {
        //�GHP��0�ȉ��Ȃ�A���̃I�u�W�F�N�g������
        if (enemyHP <= 0.0f)
        {
            SceneManager.LoadScene("Clear");
            Destroy(gameObject);
            Debug.Log("�G���|�ꂽ");
        }
    }
}
