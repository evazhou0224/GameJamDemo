using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Movement Variables
    public float maxSpeed;

    //Jumping Variables
    bool grounded = false;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    private float jumpHeightCounter;
    public float jumpTime;
    private bool isJumping;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //For projectile
    public Transform bowOrigin;
    public GameObject arrow;
    private float fireRate = 0.7f;
    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //Player shoots
        if (Input.GetAxisRaw("Fire1") > 0) fireArrow();

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        //player jump
        if (grounded && Input.GetKeyDown(KeyCode.Z))
        {
         
            grounded = false;
            myAnim.SetBool("isGrounded", grounded); ;
            isJumping = true;
            jumpHeightCounter = jumpTime;
            myRB.velocity = Vector2.up * jumpHeight;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if(Input.GetKey(KeyCode.Z)&& isJumping == true)
        {
            if(jumpHeightCounter > 0)
            {
                myRB.velocity = Vector2.up * jumpHeight;
                jumpHeightCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if grounded
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        // Gets value between -1 and 1 from pressing left, right, a, or d and puts it in move

         float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed,myRB.velocity.y);
        
        //Jump! But only if the player is on a surface marked "Ground"
           //if(Input.GetButton())
        //if (grounded && Input.GetButton("Jump"))
        //{
        //    grounded = false;
        //    myAnim.SetBool("isGrounded", grounded);
        //    myRB.velocity = new Vector2(move * maxSpeed, 0);
        //    myRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        //    FindObjectOfType<AudioManager>().Play("Jump");
        //}

        //Flips the sprite left or right depending on where they're going
        if (move < 0 && !facingRight)
        {
            flip();
        } else if (move > 0 && facingRight)
        {
            flip();
        }
    }

    //Method for flipping the sprite
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireArrow()
    {
        if (Time.time > nextFire)
        {
            myAnim.SetBool("isFiring", true);
            nextFire = Time.time + fireRate;
            if(facingRight)
            {
                Instantiate(arrow, bowOrigin.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            else if(!facingRight)
            {
                Instantiate(arrow, bowOrigin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
        else
        {
            myAnim.SetBool("isFiring", false);
        }
    }
}
