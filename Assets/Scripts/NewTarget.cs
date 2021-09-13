using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTarget : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            FollowPlayer.target = GameObject.FindGameObjectWithTag("NewTarget").GetComponent<Transform>();
        }
    }
}
