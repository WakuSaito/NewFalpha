using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectManager : MonoBehaviour
{
    public string itemID = "1";//���̃A�C�e����ID


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerManager>())
        {
            collider.gameObject.GetComponent<PlayerManager>().CountItem(itemID, 1);

            gameObject.SetActive(false);
        }
    }
}
