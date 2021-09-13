using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D launchRb;

        if (other.gameObject.CompareTag("Launcher"))
        {
            launchRb = other.gameObject.GetComponent<Rigidbody2D>();

            launchRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
