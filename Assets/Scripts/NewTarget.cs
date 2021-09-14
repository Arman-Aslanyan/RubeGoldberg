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
            if (other.gameObject.name == "New1")
            {
                Rigidbody2D new1Rb;
                new1Rb = other.gameObject.GetComponent<Rigidbody2D>();

                new1Rb.AddForce(new Vector3(1, 0, 0) * 50 * Time.deltaTime);
            }
        }
    }
}
