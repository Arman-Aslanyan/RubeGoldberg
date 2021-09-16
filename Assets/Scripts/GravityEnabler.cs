using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEnabler : MonoBehaviour
{
    //Upon collision will change objects gravity and RigidBody type as well as Camera's target
    public void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

        rb.gravityScale = 3.0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        FollowPlayer.target = other.gameObject.GetComponent<Transform>();
    }
}
