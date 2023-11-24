using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�}�b�v�����p�N���X
//�J�����ɃA�^�b�`
public class CreateMap : MonoBehaviour
{
    public bool onNext = true;  //���}�b�v�ɐi�񂾂Ƃ�true
    [SerializeField]
    private int mapCount = 1;   //���}�b�v�ڂ��ǂ���
    [SerializeField]
    private int stageCount = 1; //���X�e�[�W�ڂ��ǂ���
    private int shopRand;       //���l�o�������p
    private int mapWidth = 5;   //�}�b�v�̕�
    public int nomalmapHeight = 22;//�ʏ�}�b�v�̏c��
    public int bossMapHeight = 10;  //�{�X�}�b�v�̏c��
    private int mapHeight;
    public float cameraPosX = 2;    //�J�����̏����ʒu
    public float cameraPosY = 2;
    private float cameraPosZ = -10;
    public int mapEnemyMinY = 4;  //�G�����������͈�
    public int mapEnemyMaxY = 19;

    public GameObject[] floorTiles = new GameObject[3];//���I�u�W�F�N�g

    public GameObject player;    //�v���C���[�I�u�W�F�N�g
    public GameObject tresureBox;//�󔠃I�u�W�F�N�g
    public GameObject warpZone;  //���[�v�]�[���I�u�W�F�N�g
    public GameObject shop;      //���l�I�u�W�F�N�g
    public GameObject[] boss = new GameObject[3];         //�{�X�I�u�W�F�N�g
    public GameObject[] stage1Enemy = new GameObject[2];  //�G�I�u�W�F�N�g (�Q�����z��ł���Ă������A�C���X�y�N�^�[��ŕύX�ł��Ȃ����ߒf�O)
    public GameObject[] stage2Enemy = new GameObject[2];  
    public GameObject[] stage3Enemy = new GameObject[2];
    private GameObject[] enemyObj = new GameObject[2];    //���ۂɐ�������G�I�u�W�F�N�g
    public int[] enemyNum = new int[2];    //��������G�̐�
    private int[] enemyCount = new int[2]; //�J�E���g�p

    //�I�u�W�F�N�g�̈ʒu����ۑ�����ϐ�
    private Transform boardHolder;

    PlayerManager playerManager;
    PlayerStatusManager playerStatusManager;

    private int start;
    private int end;
    Vector2 pos;


    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g�̎擾
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();

        GameObject obj = GameObject.Find("Player");
        playerManager = obj.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //onNext���󂯎�����Ƃ��A�X�e�[�W��3�ȉ��Ȃ�
        if (onNext && stageCount <= 3)
        {

            //onNext���I���ɂȂ����Ƃ��A�N���[���S�폜
            DestroyClone();

            //1�}�b�v�ڂ����n�ʂ̐���
            if(mapCount == 1)
            {
                //HP,�o���A�̏�����
                playerStatusManager.ResetHpBr();

                //�c���̐ݒ�
                mapHeight = nomalmapHeight;
                //������
                BoardSetup();

                //���l�����}�b�v�ڂɏo�����邩���߂�(�{�X��O�͌Œ�)
                shopRand = Random.RandomRange(1, 4);
            }

            //�}�b�v����
            if(mapCount < 5)
            {
                PicEnemy();
                //�}�b�v����
                MapCreate();
            }
            else
            {
                //�c���̐ݒ�
                mapHeight = bossMapHeight;
                //�{�X�}�b�v����
                BossMapCreate();

                //�{�X�}�b�v�̃N���A��A���X�e�[�W�̍ŏ��ɂȂ�悤�ɂ���
                stageCount++;
                mapCount = 0;
            }

            onNext = false;
            mapCount++;
        }
        else
        {
            //�N���A
        }
    }

    //�}�b�v�����֐�
    private void MapCreate()
    {
        Debug.Log("�}�b�v����");

        //�}�X�̈ʒu�ɑΉ��������l
        start = mapEnemyMinY * mapWidth;
        end = ((mapEnemyMaxY+1) * mapWidth)-1;

        //�J�E���g�p�̕ϐ���������
        for (int i = 0; i < enemyNum.Length; i++)
            enemyCount[i] = enemyNum[i];

        //�����_���p���X�g
        List<int> mapNum = new List<int>();
        for (int i = start; i < end; i++)
            mapNum.Add(i);

        //�G�N���[������
        for (int i = 0; i < enemyCount.Length; i++)
        {
            while (enemyCount[i]-- > 0)
            {
                //�����_���Ȓl���擾
                int index = Random.RandomRange(0, mapNum.Count);
                int rand = mapNum[index];

                //�擾�����l�ɑΉ��������W��ݒ�
                pos.x = rand % 5;
                pos.y = rand / 5;

                //�����_�����d�����Ȃ��悤�ɁA���X�g����폜
                mapNum.RemoveAt(index);

                //�G�N���[������ pos
                Instantiate(enemyObj[i], pos, Quaternion.identity);
            }
        }
        //���X����
        Instantiate(tresureBox, new Vector2(2f, 21f), Quaternion.identity);
        Instantiate(warpZone, new Vector2(4f, 21f), Quaternion.identity);
        //���݂̃}�b�v�����l�o���}�b�v�Ȃ�
        if (mapCount == shopRand)
        {
            Instantiate(shop, new Vector2(1f, 21f), Quaternion.identity);
        }       

        //�J�������ړ�
        transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);

        //�v���C���[���ړ��@������ύX
        playerManager.ResetPos(new Vector2(2f, 1f));
        playerManager.upLimit = mapHeight - 1;
        playerManager.backLimitArea = mapHeight - 3;
    }

    //�v���C���[�̈ړ��͈͖��ݒ�@�|���ꂽ�Ƃ�����ɕω���������
    //�{�X�}�b�v�����֐�
    private void BossMapCreate()
    {
        Debug.Log("�{�X�}�b�v����");
        //���s10�ŏ��𐶐�����
        BoardSetup();

        //�I�u�W�F�N�g�𐶐�
        Instantiate(boss[stageCount], new Vector2(2f, 7f), Quaternion.identity);
        Instantiate(shop, new Vector2(1f, 3f), Quaternion.identity);   

        //�J�������ړ�
        transform.position = new Vector3(cameraPosX, cameraPosY, cameraPosZ);

        //�v���C���[���ړ� ������ύX
        playerManager.ResetPos(new Vector2(2f, 1f));
        playerManager.upLimit = mapHeight - 3;
        playerManager.backLimitArea = mapHeight - 5;
    }
    //�{�X���|���ꂽ�Ƃ��֐�
    public void BossDead()
    {
        Debug.Log("�{�X���j��");
        if (stageCount <= 3)
        {
            //�ŏI�X�e�[�W�̃{�X�}�b�v�͕󔠂𐶐����Ȃ�
            Instantiate(tresureBox, new Vector2(2f, 9f), Quaternion.identity);
        }

        Instantiate(warpZone, new Vector2(4f, 9f), Quaternion.identity);

        //�v���C���[�̐�����ύX
        playerManager.upLimit += 2;
        playerManager.backLimitArea += 3;
    }

    //����z�u
    void BoardSetup()
    {
        Debug.Log("������");
        // Board�Ƃ����I�u�W�F�N�g���쐬���Atransform����boardHolder�ɕۑ�
        boardHolder = new GameObject("Board").transform;

        // ��5�}�X
        for (int x = 0; x < mapWidth; x++)
        {
            //�@�����P�`�Q�O�����[�v
            for (int y = 0; y < mapHeight; y++)
            {
                GameObject toInstantiate = floorTiles[stageCount];


                //���𐶐����Ainstance�ϐ��Ɋi�[
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f),
                            Quaternion.identity) as GameObject;

                //��������instance��Board�I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ���
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //��������G�����߂�֐�
    void PicEnemy()
    {
        //��������G���A�X�e�[�W�ɂ���ĕς���
        //�G�̎�ނ𑝂₷�ꍇ�����_�����g��
        if (stageCount == 1)
        {
            enemyObj[0] = stage1Enemy[0];
            enemyObj[1] = stage1Enemy[1];
        }
        if (stageCount == 2)
        {
            enemyObj[0] = stage2Enemy[0];
            enemyObj[1] = stage2Enemy[1];
        }
        if (stageCount == 3)
        {
            enemyObj[0] = stage3Enemy[0];
            enemyObj[1] = stage3Enemy[1];
        }

        for (int i= 0;i<enemyNum.Length;i++)
        {
            enemyNum[i] = Random.RandomRange(5, 15);
        }
    }

    //�N���[���S�폜�֐�
    void DestroyClone()
    {
        Debug.Log("�N���[���폜");
        //�G�폜
        var enemyClones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var clone in enemyClones)
        {
            Destroy(clone);
        }

        //�󔠍폜
        var boxClones = GameObject.FindGameObjectsWithTag("TreasureBox");
        foreach (var clone in boxClones)
        {
            Destroy(clone);
        }

        //shop�폜
        var shopClones = GameObject.FindGameObjectsWithTag("Trader");
        foreach (var clone in shopClones)
        {
            Destroy(clone);
        }

        //���[�v�]�[���폜
        var warpClones = GameObject.FindGameObjectsWithTag("WarpZone");
        foreach (var clone in warpClones)
        {
            Destroy(clone);
        }

        //�{�X�}�b�v�ƍŏ��̃}�b�v��������
        if(mapCount == 5 || mapCount == 1)
        {
            Debug.Log("�n�ʍ폜");
            //�n�ʍ폜
            var floorClones = GameObject.FindGameObjectsWithTag("floorTiles");
            foreach (var clone in floorClones)
            {
                Destroy(clone);
            }
        }
    }
}
