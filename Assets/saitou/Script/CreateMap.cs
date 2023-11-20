using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public bool onNext = true; //���}�b�v�ɐi�񂾂Ƃ�true
    private int mapCount = 0;   //���}�b�v�ڂ��ǂ���
    private int shopRand;       //���l�o�������p
    private int mapWidth = 5;   //�}�b�v�̕�
    public int mapEnemyMinY = 4;  //�G�����������͈�
    public int mapEnemyMaxY = 19;
    public int[] enemyCount = new int[2]; //���������G�̐�

    private int start;
    private int end;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        shopRand = Random.RandomRange(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (onNext)
        {
            //onNext���I���ɂȂ����Ƃ��A�N���[���S�폜
            mapCount++;
            if(mapCount < 5)
            {
                //�}�b�v����
            }
            else
            {
                //�{�X�}�b�v����
            }
            onNext = false;
        }
    }

    //�}�b�v�����֐�
    private void MapCreate()
    {
        start = mapEnemyMinY * mapWidth;
        end = mapEnemyMaxY * (mapWidth + 1);

        List<int> mapNum = new List<int>();

        for (int i = start; i < end; i++)
            mapNum.Add(i);

        for (int i = 0; i < enemyCount.Length; i++)
        {
            while (enemyCount[i]-- > 0)
            {
                int index = Random.RandomRange(0, mapNum.Count);

                int rand = mapNum[index];
                //������mapNum[index]���폜����

                pos.x = rand % 5;
                pos.y = rand / 5;

                //�G�N���[������ pos
            }

        }    
        
        //���X����
    }
}
