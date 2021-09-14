using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTrap : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerConroller.enableControls = false;
        }
    }
}
