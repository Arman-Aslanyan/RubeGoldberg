using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enemy speed
    public float speed;
    //Time the enemy will move with certain speed
    private float moveTime = 0.5f;

    //Used to get enemy's first random speed
    public void Start()
    {
        speed = Random.Range(-1, 1);
        speed *= 5;
        StartCoroutine(Timer());
    }

    //Moves the enemy
    public void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    /*Control center of the enemies: after a certain time, the enemies speed is randomized.
      And if the enemy is too far to the left or the right it will forcibly alter their speed to return them near the middle*/
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(moveTime);
        speed = Random.Range(-7.0f, 7.0f);
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
