using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Animator animator;    //�A�j���I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();  //�A�j���R���|�[�l���g�̎擾
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        animator.SetTrigger("Death");   //�|���A�j���Ɉڍs
    }
}