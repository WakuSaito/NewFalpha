using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraMove : MonoBehaviour
{
    public float Movespeed = 0.5f;

    GameObject playerObj;
    GameObject ClearText;
    PlayerManager player;
    Transform playerTransform;

    public float bottomLimit = 3.0f;//カメラのY下限
    public float upLimit = 19.0f;//カメラのY上限
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerManager>();
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        if (player.transform.position.y >= bottomLimit && player.transform.position.y <= upLimit)
        {
            //縦方向だけ追従
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + Movespeed, transform.position.z);
            bottomLimit++;
        }

    }
 }
