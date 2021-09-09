using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private float moveTime = 2.5f;
    private bool moveRight = true;

    public void Start()
    {
        StartCoroutine(Timer());
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(moveTime);
        speed *= -1;
    }
}
