using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private float moveTime = 0.5f;
    /*[Tooltip("A random int speed value of the enemy to make each obstacle have a unique speed")]
    public int randSpeed; */

    public void Start()
    {
        speed = Random.Range(-1, 1);
        speed *= 5;
        StartCoroutine(Timer());
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(moveTime);
        //randSpeed = Random.Range(1, 5);
        speed = Random.Range(-7.0f, 7.0f);
        //speed *= randSpeed;
        //speed *= -1;
        if (transform.position.x > 10.0f)
        {
            speed = -9;
            yield return new WaitForSeconds(moveTime);
        }
        else if (transform.position.x < -10.0f)
        {
            speed = 9;
            yield return new WaitForSeconds(moveTime);
        }
        StartCoroutine(Timer());
    }
}
