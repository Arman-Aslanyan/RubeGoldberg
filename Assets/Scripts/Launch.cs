using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float rotateSpeed = 500.0f;
    private bool rotate;

    private Rigidbody2D launchRb;
    private Transform launcher;
    private BoxCollider2D launcherBox;

    public void Start()
    {
        launchRb = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Rigidbody2D>();
        launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Transform>();
        launcherBox = GameObject.FindGameObjectWithTag("Launcher").GetComponent<BoxCollider2D>();
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
        rotate = true;
        yield return new WaitForSeconds(0.5f);
        launcherBox.enabled = false;
        yield return new WaitForSeconds(2);
        rotate = false;
    }

    public void Update()
    {
        if (rotate)
        {
            //launchRb.AddForce(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
            launcher.transform.Rotate(new Vector3(0, 0, -1) * -rotateSpeed * Time.deltaTime);
        }
    }
}
