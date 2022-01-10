using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //player components
    Rigidbody2D rb;
    Animator anim;
    Transform hand;
    //player moving variables
    public float speed;
    float moveInput;
    bool facingRight;
    //player jumping variables
    public float jumpForce;
    public float circleRadius;
    Transform groundCheck;
    public LayerMask whatIsGround;
    bool isGrounded;
    bool jumping;
    //player grabbing
    public Transform fruit;
    public bool grabbing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("groundCheck");
        hand = transform.Find("hand");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Methods
       GetInputs();
       Flip();

        anim.SetFloat("speed", moveInput);
        anim.SetBool("gorunded", isGrounded);

       if(grabbing)
       {
            GrabObject();
       }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, circleRadius, whatIsGround);

        //adds upforce to the players rigidbody 
        if (jumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("jump");
            jumping = false;
        }
    }

    private void LateUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.transform.tag == "collectable")
        {
            grabbing = true;            
            fruit = coll.transform;
            coll.GetComponent<PolygonCollider2D>().enabled = false;
            var collRb = coll.GetComponent<Rigidbody2D>();
            collRb.gravityScale = 0f;
            collRb.velocity = new Vector2(0f, 0f);
            
            
        }
        else
        {
            grabbing = false;
            
        }
    }

    //
    void GetInputs()
    {
        //moving input
        moveInput = Input.GetAxisRaw("Horizontal");
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }

    //flips the character left or right depending where the player is going
    void Flip()
    {

       if (moveInput == 1)
        {
            facingRight = true;
        }
        if (moveInput == -1)
        {
            facingRight = false;
        }
        

        if(facingRight)
        {
            transform.localScale = new Vector2(-0.3543522f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(0.3543522f, transform.localScale.y);
        }

    }

    
    
    //Grabs the fruit or berry
    void GrabObject()
    {
        fruit.position = new Vector2(hand.position.x, hand.position.y);
    }

}
