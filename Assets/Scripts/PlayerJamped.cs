using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJamped : MonoBehaviour {

    public float PlayerJumpPower; //This Variavle Jumppower :ジャンプで上方向にかける強さを決めます。
    public float JumpTime; //Maximum Time for jump
    private float JumpTimeCounter; //Time for jump depending on touch
    public float PlayerSpeed; //Maximum Player Movement Speed
    public float PlayerMaxSpeed; //Maximum Player Movement Speed

    private bool jump;

    private Rigidbody2D rb;

    private bool isGrounded;
    private bool groundedDelay = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // Use this for initialization
    void OnEnable() {   
        rb = GetComponent<Rigidbody2D>();
        bool jump = true;
    }           //OnEnable is called everytime the Object is enabled. It's better for player respawn.

    void Start () {
    }
	
	// Update is called once per frame
    void Update() { }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(isGrounded)
            { groundedDelay = true; }       //Due to uneven ground, player sometimes is not not grounded, even if he is only minimally above the floor. GroundedDelay ignores that.
        Jump();
        Move();
    }


    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        jump = false;
    //    }
    //}

    void Jump()
    {
        if (Input.GetMouseButtonDown(0) && groundedDelay)
        {
            jump = true;
            JumpTimeCounter = JumpTime;
            rb.AddForce(Vector2.up * PlayerJumpPower * (1 + JumpTime));
            groundedDelay = false;

        }

        if (Input.GetMouseButton(0) && jump)        //Adds jo jump as long as player touches screen
        {
            if (JumpTimeCounter > 0)
            {
                rb.AddForce(Vector2.up * PlayerJumpPower * (1 + JumpTimeCounter)); // (1 + JumpTimeCounter) and (1 + JumpTime) are multiplied to make Jump smooth
                JumpTimeCounter -= Time.deltaTime;      //Maximum Jump is limited by JumpTimeCounter
            }
            else
            {
               
            }
        }
    }

    void Move()
    {
        Vector2 v = rb.velocity;

        if (Input.acceleration.x < 0 && v.x > -PlayerMaxSpeed)       //If the Smartphone is tilted to the left and Player is not faster than PlayerMaxSpeed
        {
            if (v.x > 0)                                                //And if he is still moving to the right                                                   
            {
                rb.AddForce(Vector2.left * PlayerSpeed * 10 * Time.deltaTime);         //Move him faster to the left --> Smooth change of direction
            }
            else if(Input.acceleration.x > -0.1 && v.x > -0.5 && v.x < 0.5)     //Or if the phone is only lightly tilted and he is slower than 0.5 either left or right
            {
                v.x = 0;                                                               //Make Player stand still
            }
            else
            {
                rb.AddForce(Vector2.left * PlayerSpeed * 2 * Time.deltaTime);   //Otherwise player moves to right 
            }

        }
        else if (Input.acceleration.x < 0 && v.x >= -PlayerMaxSpeed) //If the Smartphone is tilted to the left and Player is equals to or faster than PlayerMaxSpeed
        {
            v.x = -PlayerMaxSpeed * Time.deltaTime;
            rb.velocity = v;                                        //Limit Player speed to PlayerMaxSpeed
        }
        else if (Input.acceleration.x > 0 && v.x <= PlayerMaxSpeed) //If the Smartphone is tilted to the right and Player is not faster than PlayerMaxSpeed
        {
            if (v.x < 0)                                               //And if he is still moving to the left
            {
                rb.AddForce(Vector2.right * PlayerSpeed * 10 * Time.deltaTime);         //Move him faster to the right --> Smooth change of direction
            }
            else if (Input.acceleration.x < 0.1 && v.x > -0.5f && v.x < 0.5f)     //Or if the phone is only lightly tilted and he is slower than 0.5 either left or right
            {
                v.x = 0f;
                rb.velocity = v;   //Make Player stand still
            }
            else
            {
                rb.AddForce(Vector2.right * PlayerSpeed * 2 * Time.deltaTime);    //Otherwise player moves to right 
            }
        }
        else if (Input.acceleration.x > 0 && v.x <= PlayerMaxSpeed) //If the Smartphone is tilted to the right and Player is equals to or faster than PlayerMaxSpeed
        {
            v.x = PlayerMaxSpeed * Time.deltaTime;
            rb.velocity = v;                                        //Limit Player speed to PlayerMaxSpeed
        }
        Debug.Log(rb.velocity);
    }
   
}
