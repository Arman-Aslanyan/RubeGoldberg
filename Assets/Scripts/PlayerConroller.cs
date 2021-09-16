using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    //Set an array for possible starting positions
    public Vector2[] Positions;
    //The tet that will signify the player's victory and/or help guide the player
    public GameObject txt;
    public GameObject helperTxt;
    public GameObject helperTxt2;

    //An Int to keep track of player's current position number
    public int posNum;
    //Has the game begun?
    public static bool hasStart;
    //Player's RigidBody
    private Rigidbody2D rb;

    //Player's movement speed
    public float speed = 5.0f;

    [Tooltip("Enables the player to move on the horizontal axis")]
    public static bool enableControls = false;

    //Adds to Positions Array and sets values to certain variables;
    void Start()
    {
        //Set all text to not be active in-game
        txt.SetActive(false);
        helperTxt.SetActive(false);

        //Stores player's rigidbody component and sets the player body type to static
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        //Creating and storing 7 elements in the Positions Array
        Positions = new Vector2[7];
        Positions[0] = new Vector2(-5.84f, 4.32f);
        Positions[1] = new Vector2(-3.92f, 4.32f);
        Positions[2] = new Vector2(-2.02f, 4.32f);
        Positions[3] = new Vector2(0, 4.32f);
        Positions[4] = new Vector2(1.95f, 4.32f);
        Positions[5] = new Vector2(3.8f, 4.32f);
        Positions[6] = new Vector2(5.67f, 4.32f);

        //Spawn the player in the middle slot
        posNum = 4;
        ChangePosition(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Will change Player's chosen slot
        if (Input.GetKeyDown(KeyCode.E))
        {
            //If the player is at the right-most slot and clicks "E", then move them to the left-most slot
            if (posNum == 7)
            {
                posNum = 1;
            }
            else
            {
                posNum++;
            }
            ChangePosition(true);
        }

        //Will start the game with Player at chosen slot
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            hasStart = true;
            helperTxt2.SetActive(false);
        }
    }

    //Used for player movement
    void FixedUpdate()
    {
        if (enableControls)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
    }

    //Upon entering a trigger enable PlayerControls and if other's tag is "VictoryCheck" then Start the timer() Coroutine
    public void OnTriggerEnter2D(Collider2D other)
    {
        enableControls = true;
        //Sets Player's rotation to zero to reduce movement issues
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        //Freezes Player's rotation to reduce movement issues
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (other.name == "ControlEnabler")
        {
            StartCoroutine(timer(true));
        }

        if (other.CompareTag("VictoryCheck"))
        {
            StartCoroutine(timer(false));
        }
    }

    //Upon entering a collider check if the objects tag is "NewTarget" then change camera's target
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            FollowPlayer.target = other.gameObject.GetComponent<Transform>();
        }
    }

    //When called will wait one second to enable to "Victory!!" text
    public IEnumerator timer(bool helper)
    {
        yield return new WaitForSeconds(1);
        if (helper)
        {
            helperTxt.SetActive(true);
            yield return new WaitForSeconds(5);
            helperTxt.SetActive(false);
        }

        if (!helper)
        {
            txt.SetActive(true);
        }
    }

    //Changes the player's chosen slot
    public void ChangePosition(bool canChangePos)
    {
        if (canChangePos)
        {
            if (posNum == 1)
            {
                transform.position = Positions[0];
            }
            else if (posNum == 2)
            {
                transform.position = Positions[1];
            }
            else if (posNum == 3)
            {
                transform.position = Positions[2];
            }
            else if (posNum == 4)
            {
                transform.position = Positions[3];
            }
            else if (posNum == 5)
            {
                transform.position = Positions[4];
            }
            else if (posNum == 6)
            {
                transform.position = Positions[5];
            }
            else if (posNum == 7)
            {
                transform.position = Positions[6];
            }
            else
            {
                Debug.LogError("Code not working");
            }
        }
    }
}
