using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float maxHP = 100.0f;       //�ő�̗�
    [SerializeField] private int money = 100;            //���Ƃ�����
    [SerializeField] private float attackDamage1 = 10.0f;//�U��1�̃_���[�W
    [SerializeField] private float attackDamage2 = 10.0f;//�U��2�̃_���[�W

    public Color mainColor = new Color(1f, 1f, 1f, 1f);     //�ʏ펞
    public Color damageColor = new Color(1f, 0.6f, 0.6f, 1f); //��_���[�W��

    private float takeDamage;   //��_���[�W

    private StatusData status;    //�G�X�e�[�^�X�N���X
    private StatusCalc statusCalc = new StatusCalc();     //�_���[�W�v�Z�N���X
    Sounds sounds;

    PlayerStatusManager playerStatusManager;//PlayerStatusManager�X�N���v�g
    GameObject obj;//DataInfo�p

    void Start()
    {
        Debug.Log("�{�X������");
        //PlayerStatusManager�̎擾
        playerStatusManager = LoadManagerScene.GetPlayerStatusManager();

        GameObject soun = GameObject.Find("SoundObject");
        sounds = soun.GetComponent<Sounds>();

        //�X�e�[�^�X������
        status = new StatusData(maxHP, money, attackDamage1, attackDamage2);

        Debug.Log("�{�X����������");

        //mainColor = gameObject.GetComponent<Color>();
    }

    //��collider�ڐG��
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);

        //���Ƃ̐ڐG
        if (other.gameObject.tag == "Sword")
        {
            //�v���C���[�̋ߋ����U���_���[�W�𒲂ׂ�
            takeDamage = playerStatusManager.AttackDamageCalc();

            //HP�v�Z
            status.CurrentHP = statusCalc.HPCalc(status.CurrentHP, takeDamage);

            StartCoroutine(DamageEfect());

            Debug.Log("���̃_���[�W : " + takeDamage);
        }
        //�藠���Ƃ̐ڐG
        if (other.gameObject.tag == "Syuriken")
        {
            //�v���C���[�̉������U���_���[�W�𒲂ׂ�
            takeDamage = playerStatusManager.AttackDamageCalc();

            //HP�v�Z
            status.CurrentHP = statusCalc.HPCalc(status.CurrentHP, takeDamage);

            StartCoroutine(DamageEfect());

            Debug.Log("�藠���̃_���[�W : " + takeDamage);
        }
        //�|��邩���ׂ�
        EnemyDead();
    }

    //�|��邩���ׂ�֐�
    void EnemyDead()
    {
        //�GHP��0�ȉ��Ȃ�A���̃I�u�W�F�N�g������
        if (status.CurrentHP <= 0.0f)
        {
            //CreateMap�X�N���v�g��T��
            CreateMap createMap;
            GameObject obj = GameObject.Find("Main Camera");
            createMap = obj.GetComponent<CreateMap>();

            //�{�X���|���ꂽ�Ƃ��֐�
            createMap.BossDead();

            sounds.EnemyDeathSE();//SE �G���|�ꂽ

            //gameObject.SetActive(true);
            Destroy(gameObject);
            Debug.Log("�{�X���|�ꂽ");

                ////�@�{�XHP���O�ɂȂ�Ǝ��̃X�e�[�W�ɍs�����߂̃}�X���\�������
                //if (BossHP <= 0)
                //{
                //    Instantiate(NextStageTiles, new Vector2(5, 20), Quaternion.identity);
                //}
        }
    }

    //��_���[�W�G�t�F�N�g
    public IEnumerator DamageEfect()
    {
        //�F�ύX
        gameObject.GetComponent<SpriteRenderer>().color = damageColor;

        //SE�@��_���[�W

        yield return new WaitForSeconds(0.1f);

        //�F��߂�
        gameObject.GetComponent<SpriteRenderer>().color = mainColor;
    }
}
