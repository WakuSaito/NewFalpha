using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̃X�e�[�^�X�Ǘ��N���X
public class PlayerStatusManager : MonoBehaviour
{
    //�X�e�[�^�X�̏������p
    [SerializeField] private float maxHP;       //�ő�̗�      
    [SerializeField] private float attackDamage;//�ߋ����U���_���[�W
    [SerializeField] private float shotDamage;  //�������U���_���[�W
    [SerializeField] private int criChance;     //�N���e�B�J����
    [SerializeField] private float criDamage;   //�N���e�B�J���_���[�W
    [SerializeField] private int initialMoney;  //����������
    [SerializeField] private float[] barrier = new float[5];  //�o���A�̔{�� �ŏ��͗v�f0��
    
    ItemDataS itemEffect;   //�A�C�e���̒ǉ�����

    public bool onSelfHarm = false; //�A�C�e���p�t���O

    public bool onResetHpBr = false;    //�̗́A�o���A���Z�b�g������
    public PlayerStatusData status;     //�v���C���[�̃X�e�[�^�X�i�[�p


    PlayerItemManager playerItemManager;

    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g�擾
        playerItemManager = GetComponent<PlayerItemManager>();

        //�X�e�[�^�X�̏�����
        status = new PlayerStatusData(maxHP, initialMoney, attackDamage, shotDamage, barrier[0], criChance, criDamage);

        Debug.Log("maxHP" + status.MaxHP);
    }

    //�����A�C�e�����ʎ擾�֐�
    public void GetEffect()
    {
        //PIM��itemEffect���Q�Ɠn�����āA�f�[�^���擾
        playerItemManager.GetItemEffect(ref itemEffect);
    }

    //�_���[�W�v�Z�֐� �������P�Ȃ�N���e�B�J���͋N���Ȃ�
    public float DamageCalc(float damage, int criC = -100, float criD = 1f)
    {
        GetEffect();//�����A�C�e�����ʎ擾

        //1~100�̃����_��
        int dice = Random.RandomRange(1, 101);

        //�����_���̒l���A�N���e�B�J�����ȉ��Ȃ�
        if (dice <= criC + itemEffect.CriChance)
        {
            //�N���e�B�J���_���[�W��������
            return damage * itemEffect.Attack * (criD + itemEffect.CriDamage);
        }
        else
        {
            //�ʏ�̃_���[�W
            return damage * itemEffect.Attack;
        }
    }
    //�̗͌v�Z�֐�
    public float HPCalc(float hp, float damage, float barrier = 1.0f)
    {
        GetEffect();//�����A�C�e�����ʎ擾

        return hp - (damage * itemEffect.Block * barrier);
    }
    //�̗͊����񕜊֐�
    public float HealHPper(float maxhp, float hp, float per)
    {
        float heal = maxhp * per;

        //�񕜂��čő�̗͂𒴂���Ȃ�
        if (hp + heal >= maxhp)
        {
            //���݂̗̑͂��ő�̗͂Ɠ����ɂ���
            return maxhp;
        }
        else
        {
            //���݂̗̑͂��񕜂���
            return hp + heal;
        }
    }

    

    //�_���[�W���󂯂�֐�
    public bool TakeDamage(float damage)
    {
        Debug.Log("�_���[�W��H�����");

        //HP�v�Z�֐����Ă�ŁA���ݑ̗͂��X�V
        status.CurrentHP = HPCalc(status.CurrentHP, damage, status.Barrier);

        //HP���O�ȉ���������false��Ԃ�
        //���ڃV�[����ύX���Ă�����
        if (status.CurrentHP <= 0)
            return false;
        else
            return true;
    }

    //�ߋ����U���̃_���[�W�v�Z�֐�
    public float AttackDamageCalc()
    {
        GetEffect();//�����A�C�e�����ʎ擾

        //AttackDamage[0]�������Ƃ��āA�_���[�W�v�Z�֐����Ă�
        return DamageCalc(status.GetAttackDamage(0), status.CriChance, status.CriDamage)
                * itemEffect.SwordAttack;
    }

    //�������U���̃_���[�W�v�Z�֐�
    public float ShotDamageCalc()
    {
        GetEffect();//�����A�C�e�����ʎ擾

        //SelfHarm�������Ă��邩�̗͂��P��葽���Ȃ� �폜�\��
        if (onSelfHarm == true && status.CurrentHP >1f)
        {
            //�ő�̗͂�5%���󂯂�
            TakeDamage(MaxHP() * 0.05f);
        }

        //AttackDamage[1]�������Ƃ��āA�_���[�W�v�Z�֐����Ă�
        return DamageCalc(status.GetAttackDamage(1), status.CriChance, status.CriDamage)
                * itemEffect.ShotAttack;
    }

    //�o���A�̔{���X�V�֐�
    public void ChangeBarrier(int n)
    {
        //�󂯎���������Ԗڂ̗v�f�ɍX�V
        status.Barrier = barrier[n];
    }
    //�̗́A�o���A���Z�b�g�֐�
    public void ResetHpBr()
    {
        status.CurrentHP = status.MaxHP;
        status.Barrier = barrier[0];

        onResetHpBr = true;//�o���A�Q�[�W�̏������p
    }
    //���݂̗̑͂̊��������߂�֐�
    public float HPper()
    {
        return status.CurrentHP / status.MaxHP;
    }
    //�ő�̗͊֐�
    public float MaxHP()
    {
        GetEffect();//�����A�C�e�����ʎ擾

        status.MaxHP = maxHP * itemEffect.MaxHp;

        //����HP���ő�HP�𒴂��Ă���Ȃ璲��
        if(status.CurrentHP > status.MaxHP)
        {
            status.CurrentHP = status.MaxHP;
        }
        return status.MaxHP;
    }
    //���݂̗̑͂𒲐�����֐�
    public void AdjustHP()
    {
        //���݂̗̑͂��ő�̗͂𒴂��Ă�����
        if(status.CurrentHP > status.MaxHP)
        {
            //���݂̗̑͂��ő�̗͂ɍX�V
            status.CurrentHP = status.MaxHP;
        }
    }

    //�����l���֐�
    public void GettingMoney(int money)
    {
        GetEffect();//�����A�C�e�����ʎ擾

        Debug.Log("�����擾");
        status.Money += (int)(money * itemEffect.AddMoney);
    }
    //�������g�����Ƃ��֐�
    public void UseMoney(int money)
    {
        status.Money -= money;
    }
}

