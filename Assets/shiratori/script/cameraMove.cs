using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraMove : MonoBehaviour
{
    public float Movespeed = 0.5f;

    GameObject playerObj;
    //PlayerManager playerManager;
    Transform playerTransform;

    public float bottomLimit = 3.0f;//�J������Y����
    public float upLimit = 19.0f;//�J������Y���
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //playerManager = playerObj.GetComponent<PlayerManager>();//����Ȃ���
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        if (playerTransform.position.y >= bottomLimit && playerTransform.position.y <= upLimit)
        {
            //�c���������Ǐ]
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + Movespeed, transform.position.z);
            bottomLimit++;
        }

    }
 }
