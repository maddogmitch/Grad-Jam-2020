using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public variables
    public int lives;
    public float speed = 10f;
    public float acceleration = 3f;
    public bool isJumping;
    public float JumpSpeed = 5f;
    public float threshold = 0.1f;
    public float jumptime;
    public float jump;
    public bool isAlive;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject StartPosition;

    //private variables
    private Vector2 input;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private float rayCastLengthCheck = 0.005f;
    private float width;
    private float height;

    void Awake()
    {
        // gets required components when the game starts
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // on awake make the width and hieght equle the collider width and hieght
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y +0.2f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool canJump()
    {
        //use the ray cast legth to loon at the space belopw the sprite to see if there is ground
        bool onground = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, rayCastLengthCheck);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - height, 0), -Vector3.up, Color.red);
        if (onground)
        {
            Debug.Log("can jump");
            return true;

        }
        else
        {
            Debug.Log("can't jump");
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // gets the unity control axes
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Jump");

        //if statment defult the sprite to face left can change it to be opisite if the art we get defaults to the right
        if (input.x > 0)
        {
            sr.flipX = false;
        }
        else if (input.x < 0)
        {
            sr.flipX = true;
        }

        //adds time to jump time and resets the time to 0 and makes jumping false once the inmput y is 0 
        if(input.y >= 1f)
        {
            jumptime += Time.deltaTime;
        }
        else
        {      
          isJumping = false;
            jumptime = 0;
        }

        //checks if you can jump if you can you will be now at a state of jumping if the input y is more then 0 
        if (canJump() && !isJumping)
        {
            if (input.y > 0)
            {
                isJumping = true;
            }
          
        }

        //if we exceed jump time then we want to stop the player from jumping
        if (jumptime>threshold)
        {
            input.y = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isAlive = true;
        if (isAlive == true)
        {
            if (other.CompareTag("spikes"))
            {
                heart3.SetActive(false);
                isAlive = true;
                transform.position = StartPosition.transform.position;
                
            }
        }
    }


    void FixedUpdate()
    {
        var xVeloc = 0f;
        var yveloc = 0f;
        // if the x input is nothing there is no velocity
        if (canJump() && input.x == 0)
        {
            xVeloc = 0f;
        }
        // otherwise there is input we make the velocity exule the rigidbody velocity x
        else
        {
            xVeloc = rb.velocity.x;
        }


        if (canJump() && input.y == 1)
        {
            yveloc = jump;
        }
        else
        {
            yveloc = rb.velocity.y;
        }


        // add force to take the input multiplied by speed minus the velocity all multiplied by the acceration and the secon part is the jumping
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x) * acceleration, 0));
        // used to stop the character from moving when controls are in a nuterl state
        rb.velocity = new Vector2(xVeloc,yveloc);
    
        // change velocity to have the x of the cur velocityx and y is the jump speed as long as time does not exceed the threshold time
        if(isJumping && jumptime < threshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

    }
    
}
