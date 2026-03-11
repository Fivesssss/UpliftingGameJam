using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            PlayerInventory.keysCollected++;
            Destroy(gameObject);
            Debug.Log(PlayerInventory.keysCollected);
        }
    }
}
