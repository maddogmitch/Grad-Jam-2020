using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public variables
    public int health;
    public float speed = 10f;
    public float acceleration = 3f;

    //private variables
    private Vector2 input;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        // gets required components when the game starts
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x)* acceleration, 0));
        // used to stop the character from moving when controls are in a nuterl state
        rb.velocity = new Vector2(xVeloc, rb.velocity.y);
    }
}
