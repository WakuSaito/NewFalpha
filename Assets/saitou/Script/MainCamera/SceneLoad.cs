using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ManagerScene���[�h�N���X
public class SceneLoad : MonoBehaviour
{
    //private static bool Loaded { get; set; }

    void Awake()
    {
        SceneManager.LoadScene("ManagerScene", LoadSceneMode.Additive);
    }

}
