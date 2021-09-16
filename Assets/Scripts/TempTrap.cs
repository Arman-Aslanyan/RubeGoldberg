using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTrap : MonoBehaviour
{
    //Upon the Player hitting the trigger the camera will change it's target
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerConroller.enableControls = false;
        }
    }
}
