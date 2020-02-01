using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHit : MonoBehaviour
{
    public int arrowDamage;
    public float pushBackForce;
    //Get reference to projectileController.cs script
    projectileController myPC;
    enemyHealth myEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        //Allows you to interact with the projectileController methods
        myPC = GetComponentInParent<projectileController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When the arrow collides with a Shootable object, remove the arrow, check if its an enemy, then do damage if applicable
    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.layer == LayerMask.NameToLayer("Shootable")) || (other.gameObject.layer == LayerMask.NameToLayer("Ground")))
        {
            myPC.removeForce();
            FindObjectOfType<AudioManager>().Play("Pop");
            Destroy(gameObject);

            if(other.tag == "Enemy")
            {
                myEnemy = other.gameObject.GetComponent<enemyHealth>();
                myEnemy.addDamage(arrowDamage);

                pushBack(other.transform);
            }
        }
    }

    void pushBack(Transform pushedObject)
    {
        //Determine the direction to push
        Vector2 pushDirection = new Vector2(pushedObject.position.x - transform.position.x, pushedObject.position.y - transform.position.y).normalized;

        //Calculate push forces in the x and y directions
        pushDirection.x *= (0.7f*pushBackForce);
        pushDirection.y *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();

        //Stops the object in its tracks and then pushes it
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
