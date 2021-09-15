using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float launchPower = 50.0f;
    private bool launch;

    private Transform launcher;
    private Rigidbody2D playerRb;

    public void Start()
    {
        launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Transform>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.25f);
        launch = true;
        yield return new WaitForSeconds(1);
        playerRb.constraints = RigidbodyConstraints2D.None;
        launch = false;
        yield return new WaitForSeconds(0.75f);
        FollowPlayer.target = playerRb.gameObject.GetComponent<Transform>();
    }

    public void Update()
    {
        if (launch)
        {
            launcher.Rotate(new Vector3(0, 0, -1) * -launchPower * Time.deltaTime);
        }
    }
}