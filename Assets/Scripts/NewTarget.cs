using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTarget : MonoBehaviour
{
    //Upon collision Check if objects tag is "NewTarget" then set camera's target to said object
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            FollowPlayer.target = GameObject.FindGameObjectWithTag("NewTarget").GetComponent<Transform>();
        }
    }
}
