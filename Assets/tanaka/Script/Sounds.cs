using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip Clickbutton;
    public AudioClip Attack;
    public AudioClip Shot;
    public AudioClip Enemydeath;
    public AudioClip GameClear;
    public AudioClip GameOver;
    public AudioClip menuclose;
    public AudioClip buy;
    public AudioClip treasure_chest;
    public AudioClip warp;
    public AudioClip playerDamage;
    public AudioClip move;

    public AudioSource stage1;
    public AudioSource stage2;
    public AudioSource stage3;
    public AudioSource titleBGM;
    public AudioSource bossBGM;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Stage1BGM()
    {
        //�X�e�[�W�P�ȊO���~�߂ăX�e�[�W�P�𗬂�
        stage2.Stop();
        stage3.Stop();

        stage1.Play();

    }
    public void Stage2BGM()
    {
        //�X�e�[�W�Q�ȊO���~�߂ăX�e�[�W�R�𗬂�
        stage1.Stop();
        stage3.Stop();

        stage2.Play();

    }
    public void Stage3BGM()
    {
        //�X�e�[�W�R�ȊO���~�߂ăX�e�[�W�R�𗬂�
        stage2.Stop();
        stage1.Stop();

        stage3.Play();

    }
    public void TitleBGM()
    {
        //�^�C�g��BGM�𗬂�
        titleBGM.Play();

    }
    public void BossBGM()
    {
        //�{�XBGM�ȊO���~�߂ă{�XBGM�𗬂�
        stage1.Stop();
        stage2.Stop();
        stage3.Stop();

        bossBGM.Play();

    }

    public void StopBGM()
    {
        //���ׂĂ�BGM���X�g�b�v
        stage1.Stop();
        stage2.Stop();
        stage3.Stop();
        bossBGM.Stop();
        titleBGM.Stop();

    }


    public void ClickSE()
    {
            //�N���b�N�{�^��
        audioSource.PlayOneShot(Clickbutton);

    }
    public void AttackSE()
    {
        //�ߋ����U��
        audioSource.PlayOneShot(Attack);

    }
    public void ShotSE()
    {
        //�������U��
        audioSource.PlayOneShot(Shot);

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
    public void WarpSE()
    {
        //���[�v�|�C���g�ɓ������Ƃ��̉�
        audioSource.PlayOneShot(warp);

    }
    public void DamageSE()
    {
        //�v���C���[���_���[�W���󂯂����̉�
        audioSource.PlayOneShot(playerDamage);

    }
    public void MoveSE()
    {
        //�v���C���[���ړ��������̉�
        audioSource.PlayOneShot(move);

    }
}
