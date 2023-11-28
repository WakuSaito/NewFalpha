using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����A�C�e���Ǘ��N���X
public class PlayerItemManager : MonoBehaviour
{
    //�v���C���[�����A�C�e�����X�g
    public List<string> havingItem = new List<string>();

    //�A�C�e�����ʗp
    private float addMaxHP;         //�ő�̗́{

    private float increaseAttack;   //�U���i�����j��

    private float increaseBlock;    //�h��i�����j��
    private float addCriticalDamage;  //��S�_���[�W
    private int addCriticalChance;    //��S��
    private float takeDamage;         //�����_���[�W
    private float addMoney;           //�l�����z
    private float addSword;           //�ߋ����U���_���[�W*
    private float addShot;            //�������U���_���[�W*
    private float plusShot;

    [SerializeField] private float iconPosX;//�A�C�R���̏����ʒuX�i����j
    [SerializeField] private float iconPosY;//�A�C�R���̏����ʒuY�i����j


    //���X�N���v�g�̃C���X�^���X
    PlayerStatusManager playerStatusManager;
    ItemManager itemManager;

    //�A�C�e���A�C�R���p�I�u�W�F�N�g
    GameObject itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        //���I�u�W�F�N�g�̕ʃX�N���v�g���擾
        playerStatusManager = GetComponent<PlayerStatusManager>();
        itemManager = GetComponent<ItemManager>();
    }

    private void FixedUpdate()
    {
        //�ϐ��̃��Z�b�g
        addMaxHP = 1;
        increaseAttack = 1;
        increaseBlock = 1;
        addCriticalDamage = 1;
        addCriticalChance = 0;
        addMoney = 1;
        addShot = 1;
        addSword = 1;
        plusShot = 0;

        //�����A�C�e���̌��ʂ��v�Z
        for (int i = 0; i < havingItem.Count; i++)
        {
            //�A�C�e���̌��ʂ͍��ケ���ɑ��₷ ���ꂼ��֐��ŕ����Ă���������
            switch (havingItem[i])
            {
                case "Attack":
                    increaseAttack += 0.12f;
                    break;
                case "Revenge":
                    if(playerStatusManager.HPper() < 0.20f)
                    {
                        increaseAttack += 0.70f;
                    }
                    break;
                case "SelfHarm":
                    //�����Ă��鎞�ɉ������U�����������ʂ����� �̂Ă��Ƃ��̓��얢����
                    playerStatusManager.onSelfHarm = true;
                    plusShot += playerStatusManager.statusCalc.MaxHPCalc(playerStatusManager.status.MaxHP) 
                                 * 0.1f;
                    break;
                case "Health":
                    //�ő�̗�20%����
                    addMaxHP += 0.20f;
                    break;
                case "HealthTreat":
                    //�G��|���ƍő�̗͂�3%����
                    playerStatusManager.onHealthTreat = true;
                    break;
                case "ArmorPlate":
                    increaseBlock += -0.04f;
                    break;
                case "CRITRate":
                    addCriticalChance += 10;
                    break;
                case "CRITDmg":
                    addCriticalDamage += 0.30f;
                    break;
                case "Throwable2":
                    addSword += -0.10f;
                    addShot  += 0.20f;
                    break;
                case "Fencing2":
                    addShot  += -0.10f;
                    addSword += 0.20f;        
                    break;
                case "Fencing1":
                    addSword += 0.10f;
                    break;
                case "Throwable1":
                    addShot += 0.10f;
                    break;
                case "Collector":
                    increaseAttack += (havingItem.Count * 0.02f);
                    break;
                case "FirstAttack":
                    increaseAttack += 0.20f - (havingItem.Count * 0.01f);
                    break;
                case "MoneyTalent":
                    addMaxHP += -0.50f;
                    addMoney += 2.0f;
                    break;
                default:
                    Debug.Log("!�A�C�e�����ʂ�������܂���");
                    break;
            }
            //�v���C���[�X�e�[�^�X�N���X���̌v�Z�N���X�ɑ��
            playerStatusManager.statusCalc.AddMaxHP = addMaxHP;
            playerStatusManager.statusCalc.IncreaseAttack = increaseAttack;
            playerStatusManager.statusCalc.IncreaseBlock = increaseBlock;
            playerStatusManager.statusCalc.AddCriticalChance = addCriticalChance;
            playerStatusManager.statusCalc.AddCriticalDamage = addCriticalDamage;
            playerStatusManager.addMoney = addMoney;
            playerStatusManager.addAttackDamage = addSword;
            playerStatusManager.addShotDamage = addShot;
            playerStatusManager.plusShotDamage = plusShot;
            playerStatusManager.RoadHP();
        }
    }

    //�A�C�e���擾�֐�
    public void AddItem(string id)
    {
        //�擾�A�C�e���������A�C�e�����ɂ��邩���ׂ�
        for (int i = 0; i < havingItem.Count; i++)
        {
            if (havingItem[i] == id)
            {
                //���łɏ������Ă����Ȃ牽�����Ȃ�
                Debug.Log(id + "�����łɏ������Ă��܂�");
                return;
            }
        }
        //�������Ȃ�
        havingItem.Add(id);//�����A�C�e����id��ǉ�
        Debug.Log(id + "���l�����܂���");
    }
    //�A�C�e���p���֐�
    public void RemoveItem(string id)
    {
        havingItem.Remove(id);//�����A�C�e������w���id���폜
    }

    //�A�C�e���w���֐�
    public void BuyingItem(string id)
    {
        //�w�����i���擾
        int price = itemManager.GetBuyingPrice(id);

        //������������Ă���Ȃ�
        if (playerStatusManager.status.Money >= price)
        {
            //���i���A�����������炷
            playerStatusManager.GettingMoney(price * -1);
            AddItem(id);    //�A�C�e�����l��

            Debug.Log(id + "���w�� : " + price);
        }
        else
        {
            Debug.Log("����������܂���");
        }
    }
    //�A�C�e�����p�֐� ���̂Ƃ���g���\��Ȃ�
    public void SellingItem(string id)
    {
        //�w�����i���擾
        int price = itemManager.GetSellingPrice(id);

        //���i���A�������𑝂₷
        playerStatusManager.GettingMoney(price);
        RemoveItem(id);     //�A�C�e�����l��

        Debug.Log(id + "�𔄋p");
    }

    //�����A�C�e���̃A�C�R����\������֐�
    private void MakeIcon()
    {
        for (int i = 0; i < havingItem.Count; i++)
        {
            //�q�Ƃ���Image������Prefab���N���[��
            //�N���[�������I�u�W�F�N�g
        }
    }

    //�����A�C�e���f�o�b�O�\���֐�
    public void CheckHaveItem()
    {
        if (havingItem.Count == 0)
            Debug.Log("�A�C�e�����������Ă��܂���");

        for(int i = 0; i < havingItem.Count;i++)
        {
            Debug.Log(i + " : " + havingItem[i]);
        }

    }
}
