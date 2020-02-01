using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour
{

    Animator myAnim;
    public bool triggered;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("projectile")){
            
            triggered = true;
            myAnim.SetBool("triggered", triggered);
            FindObjectOfType<AudioManager>().Play("Trigger");
            Invoke("Idle", 0.1f);
        }
    }

    void Idle()
    {
        triggered = false;
        myAnim.SetBool("triggered", triggered);
    }

}
