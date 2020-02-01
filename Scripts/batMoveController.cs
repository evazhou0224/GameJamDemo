using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMoveController : MonoBehaviour
{
    Rigidbody2D myRB;
    public float enemySpeed;

    //Facing direction
    bool canFlip = true;
    bool facingRight = true;
    public GameObject enemyGraphic;
    int move = 1;
    int moveVert = 1;
    private float nextVertical = 1f;
    public float vertChangeRate;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponentInParent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (nextVertical < Time.time)
        {
            moveVert *= -1;
            nextVertical = Time.time + vertChangeRate;
        }

        myRB.velocity = new Vector2(move * enemySpeed, moveVert * 0.8f * enemySpeed);
    }

    //Originally the script checked if the surface the slime collided with was to the left or the right of it, but this works better
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if ((facingRight /*&& other.transform.position.x > transform.position.x*/) || (!facingRight /*&& other.transform.position.x < transform.position.x*/))
            {
                flipFacing();
            }
        }
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
