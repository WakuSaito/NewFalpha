using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTitleScreen : MonoBehaviour
{
    Sounds sounds;
    public GameObject text;

    public bool clearScene = true;
    public bool gameoverScene = false;
    public float keyOnSec = 5.0f; //�^�C�g���ɖ߂��悤�ɂȂ�܂ł̎���

    private bool onAnykey = false;

    private void Start()
    {
        GameObject obj = GameObject.Find("SoundObject");
        sounds = obj.GetComponent<Sounds>();

        StartCoroutine(KeyOn());

        if (clearScene == true)
            sounds.GameClearSE();//SE �N���A
        if (gameoverScene == true)
            sounds.GameOverSE(); //SE �Q�[���I�[�o�[
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && onAnykey == true)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    private IEnumerator KeyOn()
    {
        text.SetActive(false);

        onAnykey = false;

        yield return new WaitForSeconds(keyOnSec);

        text.SetActive(true);//�e�L�X�g��\��

        onAnykey = true;     //�L�[�̗L����
    }
}
