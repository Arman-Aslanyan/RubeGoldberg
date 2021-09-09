using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private float moveTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // FixedUpdate is called once per fixed framerate frame (Mainly used for physical aspects)
    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public IEnumerator Timer()
    {
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(moveTime);
        speed *= -1;
        StartCoroutine(Timer());
    }
}
