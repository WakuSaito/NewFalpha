using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner_Script : MonoBehaviour
{   
    PlayerManager _player;
    GameObject playerObj;//�v���C���[��T���p
    public GameObject enemyPrefab; // ���g����G�̃v���n�u
    public int numberOfClones = 3; // ���g����G�̐�
    public float cloneDistance = 1.5f; // ���g����G�̊Ԋu

    bool positionflag = true;

    Vector2 position; //Boss02���W]
    Vector2 playerPOS;
    
    Vector2[] clonePosition = new Vector2[2];//clonePosition�̏�����
    GameObject[] clone = new GameObject[2];// clone�����p�ϐ���������
   

    void Start()
    {
        //Boss02���W�̎擾
        position = transform.position;
        playerObj = GameObject.Find("Player");//�v���C���[��T��
        _player = playerObj.GetComponent<PlayerManager>();
        SpawnClones();
    }

    private void FixedUpdate()
    {

        if(transform.position.x != playerObj.transform.position.x&&positionflag)
        {
            StartCoroutine(PositionChange());
        }

        //�v���C���[�̂P�}�X�O�ɂ���Ƃ�
        if( transform.position.x == playerObj.transform.position.x &&
            transform.position.y == playerObj.transform.position.y -1 )
        {

        }
    }


    void SpawnClones()
    {
        
        for (int i = 0; i < numberOfClones; i++)
        {
            clonePosition[i] = new Vector2(transform.position.x + i * cloneDistance -1, transform.position.y);
            clone[i] = Instantiate(enemyPrefab, clonePosition[i], Quaternion.identity);Debug.Log("����");
            clone[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // �T�C�Y��1/2�{�ɕύX����
             // �N���[���ɑ΂���ǉ��̐ݒ�Ȃǂ��s���ꍇ�́A�����ōs���܂�
        }
        
    }

    private IEnumerator PositionChange()
    {
        positionflag = false;
        //�ҋ@
        yield return new WaitForSeconds(0.7f);

        //Boss�{�́@�v���C���[�� x�ʒu �Ɉړ�
        position.x = playerObj.transform.position.x;
        transform.position = position;

        //clone ���W�X�V
        for (int i = 0; i < numberOfClones; i++) 
        {
            //�@�N���[�����W�ϐ��Ƀ{�X�{�̂̍��W����
            clonePosition[i] = new Vector2(transform.position.x + i * cloneDistance - 1, transform.position.y);

            //�@�N���[���ɕϐ��̍��W����
            clone[i].transform.position = clonePosition[i];

            Debug.Log(i + "�Ԗ�");
        }

        yield return new WaitForSeconds(0.35f);
        positionflag = true;
    }
}
