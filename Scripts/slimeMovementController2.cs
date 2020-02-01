using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMovementController2 : MonoBehaviour
{
    Rigidbody2D myRB;
    public float enemySpeed;
    public float moveRange;

    //Facing direction
    bool canFlip = true;
    bool facingRight = false;
    public GameObject enemyGraphic;
    int move = -1;

    float x;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponentInParent<Rigidbody2D>();
        x = transform.position.x; //get the origianal location

    }

    // Update is called once per frame
    void Update()
    {
            if ((facingRight) && (transform.position.x >= x + moveRange)) // check if it's in the range
            {
                flipFacing();
            }else if((!facingRight) && (transform.position.x <= x))
        {
            flipFacing();
        }
        myRB.velocity = new Vector2(move * enemySpeed, myRB.velocity.y);
    }

 


    //Flips the slime sprite and changes its direction
    void flipFacing()
    {
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
        move *= -1;
    }
}

