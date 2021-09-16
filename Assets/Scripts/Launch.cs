using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float rotatePower = 50.0f;
    private bool launch;

    private Transform launcher;
    private Rigidbody2D playerRb;

    //Find and store component values in their respective variable
    public void Start()
    {
        launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Transform>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    //Upon collision with an object with tag "NewTarget", change camera follow target
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            StartCoroutine(Timer());
        }
    }

    //Coroutine that cahnges the value of certain variables after a certain delay.
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.25f);
        launch = true;
        yield return new WaitForSeconds(1);
        //Removes constraints on the player
        playerRb.constraints = RigidbodyConstraints2D.None;
        launch = false;
        yield return new WaitForSeconds(0.75f);
        FollowPlayer.target = playerRb.gameObject.GetComponent<Transform>();
    }

    //Rotates the platform in question
    public void Update()
    {
        if (launch)
        {
            launcher.Rotate(new Vector3(0, 0, -1) * -rotatePower * Time.deltaTime);
        }
    }
}