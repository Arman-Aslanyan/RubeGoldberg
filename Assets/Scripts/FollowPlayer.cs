using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Object the Camera will follow
    public static Transform target;
    //Offset to make the camera view as desired
    private Vector3 offset = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the Player has started the game and will then follow the Player
        if (PlayerConroller.hasStart)
        {
            transform.position = target.position + offset;
        }
    }
}
