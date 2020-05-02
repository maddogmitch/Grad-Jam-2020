using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public variables
    public int health;
    public float speed = 10f;
    public float acceleration = 3f;
    public bool isJumping;
    public float JumpSpeed = 5f;

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
        width = GetComponent<Collider2D>().bounds.extents.x;
        height = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Start is called before the first frame update
    void Start()
    {

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


        if (canJump() && isJumping == false)
        {
            if (input.y > 0)
            {
                isJumping = true;
            }
        }


    }

    public bool canJump()
    {
        //use the ray cast legth to loon at the space belopw the sprite to see if there is ground
        bool onground = Physics2D.Raycast(new Vector2(transform.position.y - height, transform.position.x), Vector2.down, rayCastLengthCheck);
        if (onground)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void FixedUpdate()
    {
        var xVeloc = 0f;
        // if the x input is nothing there is no velocity
        if (input.x == 0)
        {
            xVeloc = 0f;
        }
        // otherwise there is input we make the velocity exule the rigidbody velocity x
        else
        {
            xVeloc = rb.velocity.x;
        }
        // add force to take the input multiplied by speed minus the velocity all multiplied by the acceration and the secon part is the jumping
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x) * acceleration, 0));
        // used to stop the character from moving when controls are in a nuterl state
        rb.velocity = new Vector2(xVeloc, rb.velocity.y);
    }
}
