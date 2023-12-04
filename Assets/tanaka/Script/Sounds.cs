using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip Clickbutton;
    public AudioClip Shot;
    public AudioClip Longattack;
    public AudioClip Enemydeath;
    public AudioClip GameClear;
    public AudioClip GameOver;
    public AudioClip menuclose;
    public AudioClip buy;
    public AudioClip treasure_chest;


    public AudioSource stage1;
    public AudioSource stage2;
    public AudioSource stage3;


    //public bool on1BGM = false;
    //public bool on2BGM = false;
    //public bool on3BGM = false;
    //public bool onClickMouse = false;
    //public bool onShot = false;
    //public bool onLongAttack = false;
    //public bool onEnemydeath= false;
    //public bool onGameClear = false;
    //public bool onGameOver = false;
    //public bool onmenuclose = false;
    //public bool onbuy = false;
    //public bool onTreasure_Chest = false;





    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    //private void Update()
    //{
    //    if(on1BGM == true)
    //    {
    //        on1BGM = false;

    //        Stage1BGM();
    //    }
    //    if (on2BGM == true)
    //    {
    //        on2BGM = false;

    //        Stage2BGM();
    //    }
    //    if (on3BGM == true)
    //    {
    //        on3BGM = false;

    //        Stage3BGM();
    //    }

    //    if(onClickMouse == true)
    //    {
    //        onClickMouse = false;
    //        ClickSE();
    //    }
    //    if (onShot == true)
    //    {
    //        onShot = false;
    //        ClickSE2();
    //    }
    //    if (onLongAttack == true)
    //    {
    //        onLongAttack = false;
    //        ClickSE3();
    //    }
    //    if (onEnemydeath == true)
    //    {
    //        onEnemydeath = false;
    //        ClickSE4();
    //    }
    //    if (onGameClear == true)
    //    {
    //        onGameClear = false;
    //        ClickSE5();
    //    }

    //    if (onGameOver == true)
    //    {
    //        onGameOver = false;
    //        ClickSE6();
    //    }
    //    if (onmenuclose == true)
    //    {
    //        onmenuclose = false;
    //        ClickSE7();
    //    }
    //    if (onbuy == true)
    //    {
    //        onbuy = false;
    //        ClickSE8();
    //    }
    //    if (onTreasure_Chest == true)
    //    {
    //        onTreasure_Chest = false;
    //        ClickSE9();
    //    }








    //}

    public void Stage1BGM()
    {
        stage2.Stop();
        stage3.Stop();

        stage1.Play();

    }
    public void Stage2BGM()
    {
        stage1.Stop();
        stage3.Stop();

        stage2.Play();

    }
    public void Stage3BGM()
    {
        stage2.Stop();
        stage1.Stop();

        stage3.Play();

    }
    public void ClickSE()
    {
            //�N���b�N�{�^��
        audioSource.PlayOneShot(Clickbutton);

    }
    public void ShotSE()
    {
        //�ߋ����U��
        audioSource.PlayOneShot(Shot);

    }
    public void LongAtaackSE()
    {
        //�������U��
        audioSource.PlayOneShot(Longattack);

    }
    public void EnemyDeathSE()
    {
        //�G���S�T�E���h
        audioSource.PlayOneShot(Enemydeath);

    }
    public void GameClearSE()
    {
        //�Q�[���N���A
        audioSource.PlayOneShot(GameClear);

    }
    public void GameOverSE()
    {
        //�Q�[���I�[�o�[
        audioSource.PlayOneShot(GameOver);

    }
    public void MenuCloseSE()
    {
        //���j���[�N���[�Y�{�^��
        audioSource.PlayOneShot(menuclose);

    }
    public void BuySE()
    {
        //���l���炨�������{�^��
        audioSource.PlayOneShot(buy);

    }
    public void Treasure_ChestSE()
    {
        //�󔠊J�������̉�
        audioSource.PlayOneShot(treasure_chest);

    }







}
