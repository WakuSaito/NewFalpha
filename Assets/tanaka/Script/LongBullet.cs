using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LongBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    float speed;
    float bullet_count = 0;
    public float lifeTime = 1.0f;
    public float Ra    = 20; //Remaining_ammunition
    public float resetbullet = 20; 

    public Text ammoText;


    void Start()
    {
        speed = 10.0f;
        ammoText.text = "�c�e:20";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && bullet_count < Ra)
        {


            //�e�i�Q�[���I�u�W�F�N�g�j�̍쐬
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);

            //�N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //�����̐����iZ�����̏����Ɛ��K���j
            Vector3 shotForward = Vector3.Scale(mouseWorldPos - transform.position, new Vector3(1, 1, 0)).normalized;

            //�e�ɑ��x��^����
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;

            bullet_count++;

            UpdateAmmoText();

            Destroy(clone, lifeTime);


        }


    }

    void UpdateAmmoText()
    {
        //�c�e�����炷����
        ammoText.text = "�c�e:" + (Ra - bullet_count);
    }

    void ResetBullet()
    {
      
        resetbullet = Ra;

        bullet_count = 0;

    }
}

