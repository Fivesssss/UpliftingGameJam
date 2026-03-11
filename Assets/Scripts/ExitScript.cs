using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private bool gateEnter = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!gateEnter)
        {
            gateEnter = true;
            Debug.Log("Press enter to leave");  
        }
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
        {
            //add more later
            Debug.Log("Enter pressed");
            if (PlayerInventory.keysCollected == 5)
            {
                //Load next scene
            }
            else 
            {
                Debug.Log("You dont have 5 pieces of the gate key");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gateEnter = false;
    }
}
