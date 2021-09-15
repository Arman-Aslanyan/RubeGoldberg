using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
/*    private Vector2 pos1 = new Vector2(-5.84f, 4.32f);
    private Vector2 pos2 = new Vector2(-3.92f, 4.32f);
    private Vector2 pos3 = new Vector2(-2.02f, 4.32f);
    private Vector2 pos4 = new Vector2(0, 4.32f);
    private Vector2 pos5 = new Vector2(1.95f, 4.32f);
    private Vector2 pos6 = new Vector2(3.8f, 4.32f);
    private Vector2 pos7 = new Vector2(5.67f, 4.32f);*/

    public Vector2[] Positions;

    public int posNum;
    public static bool hasStart;
    private Rigidbody2D rb;

    public float speed = 5.0f;

    /*public float jumpPower = 500.0f;
    private float jumpCooldown = 1.5f;
    private bool canJump;*/

    [Tooltip("Enables the player to move on the horizontal axis")]
    public static bool enableControls = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        Positions = new Vector2[7];
        Positions[0] = new Vector2(-5.84f, 4.32f);
        Positions[1] = new Vector2(-3.92f, 4.32f);
        Positions[2] = new Vector2(-2.02f, 4.32f);
        Positions[3] = new Vector2(0, 4.32f);
        Positions[4] = new Vector2(1.95f, 4.32f);
        Positions[5] = new Vector2(3.8f, 4.32f);
        Positions[6] = new Vector2(5.67f, 4.32f);

        posNum = 4;
        ChangePosition(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            hasStart = true;
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && enableControls)
        {
            Jump();
            StartCoroutine(JumpTimer());
        }*/
    }

    void FixedUpdate()
    {
        if (enableControls)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        enableControls = true;
        //canJump = true;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NewTarget"))
        {
            FollowPlayer.target = other.gameObject.GetComponent<Transform>();
        }
    }

    /*public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpPower);
            canJump = false;
        }
    }

    public IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }*/

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
