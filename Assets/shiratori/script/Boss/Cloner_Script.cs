using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner_Script : MonoBehaviour
{
    public GameObject enemyPrefab; // ���g����G�̃v���n�u
    public int numberOfClones = 3; // ���g����G�̐�
    public float cloneDistance = 1.5f; // ���g����G�̊Ԋu

    GameObject ClonerforClone;
    EnemyAttack attack = new EnemyAttack();

    void Start()
    {
        SpawnClones();
        ClonerforClone= GameObject.FindGameObjectWithTag("Cloner for clone");
        attack=ClonerforClone.GetComponent<EnemyAttack>();
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
