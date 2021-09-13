using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTrap : MonoBehaviour
{
    private Transform tr;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tr = other.gameObject.GetComponent<Transform>();
            tr.position = new Vector3(10.3f, -92.99f, 0.0f);
        }
    }
}
