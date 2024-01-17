using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����A�C�e���Ǘ��N���X
public class PlayerItemManager : MonoBehaviour
{
    //�v���C���[�����A�C�e�����X�g(ID, �O���[�h)
    //public List<string> havingItem = new List<string>();
    public Dictionary<string, int> havingItem = new Dictionary<string, int>();

    public int maxItem = 8;//�A�C�e���̍ő及����

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
        foreach (KeyValuePair<string, int> haveitem in havingItem)
        {
            //�A�C�e���̌��ʂ͍��ケ���ɑ��₷ ���ꂼ��֐��ŕ����Ă���������
            switch (haveitem.Key)
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
                    plusShot += playerStatusManager.MaxHP() * 0.1f;
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
                    addMoney += 1.0f;
                    break;
                default:
                    Debug.Log("!�A�C�e�����ʂ�������܂���");
                    break;
            }
            //�v���C���[�X�e�[�^�X�N���X���̌v�Z�N���X�ɑ��
            
            playerStatusManager.statusCalc.IncreaseAttack = increaseAttack;
            playerStatusManager.statusCalc.IncreaseBlock = increaseBlock;
            playerStatusManager.statusCalc.AddCriticalChance = addCriticalChance;
            playerStatusManager.statusCalc.AddCriticalDamage = addCriticalDamage;
            playerStatusManager.addMaxHP = addMaxHP;
            playerStatusManager.addMoney = addMoney;
            playerStatusManager.addAttackDamage = addSword;
            playerStatusManager.addShotDamage = addShot;
            playerStatusManager.plusShotDamage = plusShot;

            //playerStatusManager.RoadHP();
        }
    }

    //�A�C�e���擾�֐� ���łɏ������Ă�����false��Ԃ�
    public bool AddItem(string id)
    {
        if (id != null)
        {
            if(havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
            {
                Debug.Log("�A�C�e�����ő�ł�");
                return false;
            }
            //ID���������Ă�����
            if (havingItem.ContainsKey(id))
            {
                //���łɏ������Ă����Ȃ牽�����Ȃ�
                Debug.Log(id + "�����łɏ������Ă��܂�");
                //�A�b�v�O���[�h�֐��Ɉړ�������
                UpgradeItem(id);
                return false;

            }
            //�������Ȃ�
            havingItem.Add(id, 0);//�����A�C�e����id��ǉ�
            Debug.Log(id + "���l�����܂���");
            return true;
        }
        return false;
    }

    //�A�C�e���A�b�v�O���[�h�֐�
    public void UpgradeItem(string id)
    {
        //ID���������Ă�����
        if (havingItem.ContainsKey(id))
        {
            if (havingItem[id] < 3)
                havingItem[id]++;
            else
                Debug.Log(id + " : �̓A�b�v�f�[�g�o���܂���");
        }
        else
        {
            Debug.Log("!�������Ă��܂���");
        }
    }

    //�A�C�e���p���֐�
    public void RemoveItem(string id)
    {
        havingItem.Remove(id);//�����A�C�e������w���id���폜
    }

    //�A�C�e���w���֐�
    public bool BuyingItem(string id)
    {
        if (id != null)
        {
            //���̃A�C�e�����������Ă��邩
            if (!havingItem.ContainsKey(id))//�������̏ꍇ
            {
                //�w�����i���擾
                int price = itemManager.GetBuyingPrice(0);

                //������������Ă���Ȃ�                                                       
                if (playerStatusManager.status.Money >= price)
                {
                    if (havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
                    {
                        Debug.Log("�A�C�e�����ő�ł�");
                        return false;
                    }
                    //�A�C�e�����l�� 
                    AddItem(id);

                    //���i���A�����������炷
                    playerStatusManager.UseMoney(price);

                    Debug.Log(id + "���w�� : " + price);
                    return true;

                }
                else
                {
                    Debug.Log("����������܂���");
                    return false;
                }
            }
            else//�����ς̏ꍇ
            {
                //�w�����i���擾
                int price = itemManager.GetBuyingPrice(havingItem[id]);

                //������������Ă���Ȃ�                                                       
                if (playerStatusManager.status.Money >= price)
                {
                    //�A�C�e�����A�b�v�O���[�h
                    UpgradeItem(id);

                    //���i���A�����������炷
                    playerStatusManager.UseMoney(price);
                    return true;
                }
                else
                {
                    Debug.Log("����������܂���");
                    return false;
                }
            }
        }
        return false;
    }


    //�����_���A�C�e���w��֐�(�擾���鐔(�Ԃ�l�̗v�f��), �O���[�h1,2���o�����邩)
    public string[] GetRandomItem(int num = 1, bool ongrade = true)
    {
        string[] ans = new string[num];//�Ԃ�l�p�z��

        Debug.Log("ID��" + itemManager.GetID(1));
        //�A�C�e��ID�ꗗ�̐���
        List<string> itemId = new List<string>();
        for (int i = 0; i < itemManager.GetCount(); i++)
        {
            itemId.Add(itemManager.GetID(i));
        }

        for(int i = 0;i<itemId.Count;i++)
        {
            Debug.Log("ID : "+itemId[i]);
        }

        //�����A�C�e�������ׂĒT��
        foreach (KeyValuePair<string, int> haveitem in havingItem)
        {
            switch(ongrade)
            {
                case true:
                    //�O���[�h��2(����ȏ�A�b�v�O���[�h�ł��Ȃ�)�Ȃ��₩��O��
                    if (haveitem.Value == 2)
                        itemId.Remove(haveitem.Key);
                    break;

                case false:
                    if (havingItem.Count >= maxItem)//�ő及�����ȏ�Ȃ�
                    {
                        Debug.Log("�A�C�e�����ő�ł�");
                        return null;
                    }
                    //�����A�C�e������₩��O��
                    itemId.Remove(haveitem.Key);

                    break;
            }
        }

        //�Ԃ�l�����߂�
        for (int i = 0; i < num; i++)
        {
            //itemId�̒��g�����邩�`�F�b�N
            if (itemId.Count != 0)
            {
                //0�`�S�A�C�e���̎�ނ̃����_���Ȑ��l���擾
                int r = Random.RandomRange(0, itemId.Count);

                ans[i] = itemId[r];//�Ԃ�l�p�z��Ƀ����_����ID����

                itemId.RemoveAt(r);//�������ID���폜
            }
            else
            {
                //�G���[
                Debug.Log("!�������̃A�C�e����������܂���");
                ans[i] = null;
            }
        }
        return ans;
    }

    //�����A�C�e���f�o�b�O�\���֐�
    public void CheckHaveItem()
    {
        if (havingItem.Count == 0)
            Debug.Log("�A�C�e�����������Ă��܂���");

        foreach (KeyValuePair<string, int> haveitem in havingItem){  
                Debug.Log("�A�C�e��ID : "+haveitem.Key+" �O���[�h : "+haveitem.Value);
        }

    }
}
