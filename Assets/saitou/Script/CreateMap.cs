using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�}�b�v�����p�N���X
//�J�����ɃA�^�b�`
public class CreateMap : MonoBehaviour
{
    public bool onNext = true;  //���}�b�v�ɐi�񂾂Ƃ�true
    private int mapCount = 0;   //���}�b�v�ڂ��ǂ���
    private int shopRand;       //���l�o�������p
    private int mapWidth = 5;   //�}�b�v�̕�
    public int mapHeight = 22;
    public float cameraPosX = 2;    //�J�����̏����ʒu
    public float cameraPosY = 2;
    private float cameraPosZ = -10;
    public int mapEnemyMinY = 4;  //�G�����������͈�
    public int mapEnemyMaxY = 19;

    public GameObject floorTiles;//���I�u�W�F�N�g

    public GameObject player;    //�v���C���[�I�u�W�F�N�g
    public GameObject tresureBox;//�󔠃I�u�W�F�N�g
    public GameObject warpZone;  //���[�v�]�[���I�u�W�F�N�g
    public GameObject shop;      //���l�I�u�W�F�N�g
    public GameObject[] enemyObj = new GameObject[2];//��������G�I�u�W�F�N�g
    public int[] enemyNum = new int[2];              //��������G�̐�
    private int[] enemyCount = new int[2]; //�J�E���g�p

    //�I�u�W�F�N�g�̈ʒu����ۑ�����ϐ�
    private Transform boardHolder;

    PlayerManager playerManager;

    [SerializeField]
    private int start;
    [SerializeField]
    private int end;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        shopRand = Random.RandomRange(1, 4);
        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onNext)
        {
            //onNext���I���ɂȂ����Ƃ��A�N���[���S�폜
            DestroyClone();

            mapCount++;

            //1�}�b�v�ڂ����n�ʂ̐���
            if(mapCount == 1)
            {
                //������
                BoardSetup();
            }

            if(mapCount < 5)
            {
                //�}�b�v����
                MapCreate();
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
        end = ((mapEnemyMaxY+1) * mapWidth)-1;

        //�J�E���g�p�̕ϐ���������
        for (int i = 0; i < enemyNum.Length; i++)
            enemyCount[i] = enemyNum[i];

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
                Instantiate(enemyObj[i], pos, Quaternion.identity);
            }

        }
        //���X����
        Instantiate(tresureBox, new Vector2(2f, 21f), Quaternion.identity);
        Instantiate(warpZone, new Vector2(4f, 21f), Quaternion.identity);
        Instantiate(shop, new Vector2(1f, 21f), Quaternion.identity);//���l�͌�Ő�������
        //Instantiate(player, new Vector2(2f, 1f), Quaternion.identity);
        

        //�J�������ړ�
        transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);

        playerManager.ResetPos(new Vector2(2f, 1f));
    }

    //����z�u
    void BoardSetup()
    {
        // Board�Ƃ����I�u�W�F�N�g���쐬���Atransform����boardHolder�ɕۑ�
        boardHolder = new GameObject("Board").transform;

        // ��5�}�X
        for (int x = 0; x < mapWidth; x++)
        {
            //�@�����P�`�Q�O�����[�v
            for (int y = 0; y < mapHeight; y++)
            {
                GameObject toInstantiate = floorTiles;


                //���𐶐����Ainstance�ϐ��Ɋi�[
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f),
                            Quaternion.identity) as GameObject;

                //��������instance��Board�I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ���
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    void DestroyClone()
    {
        var enemyClones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemyclone in enemyClones)
        {
            Destroy(enemyclone);
        }

        //�����Ȃ�
        var boxClones = GameObject.FindGameObjectsWithTag("TreasureBox");
        foreach (var clone in enemyClones)
        {
            Destroy(clone);
        }

        //shop�폜

        //���[�v�]�[���폜
    }
}
