using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner_Script : MonoBehaviour
{
    public GameObject enemyPrefab; // ���g����G�̃v���n�u
    public int numberOfClones = 3; // ���g����G�̐�
    public float cloneDistance = 1.5f; // ���g����G�̊Ԋu

    public float clonepos = -1.0f;//�N���[�������ʒu�����p
    public float coolTime = 2.0f;//�U���̃N�[���^�C��
    private float time = 0.0f;//���Ԍv���p
    private bool moveOn = true;//�s���\�t���O
    public GameObject AttackEffect;//�N���[������I�u�W�F�N�g

    GameObject ClonerforClone;
    EnemyAttack attack = new EnemyAttack();

    void Start()
    {
        SpawnClones();
        ClonerforClone= GameObject.FindGameObjectWithTag("Cloner for clone");
        attack=ClonerforClone.GetComponent<EnemyAttack>();

        attack.moveOn = true;
    }

    private void FixedUpdate()
    {
       
    }

    void SpawnClones()
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x + i * cloneDistance -1, transform.position.y);
            GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            clone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // �T�C�Y��2�{�ɕύX�����
             // �N���[���ɑ΂���ǉ��̐ݒ�Ȃǂ��s���ꍇ�́A�����ōs���܂�
        }
    }
}
