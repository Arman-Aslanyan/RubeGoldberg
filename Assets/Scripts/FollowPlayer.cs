using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerConroller.hasStart)
        {
            transform.position = target.position + offset;
        }
    }
}
