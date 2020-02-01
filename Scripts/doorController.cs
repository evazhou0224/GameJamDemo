using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{

    Animator myAnim;
    public bool open;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void door()
    {
        myAnim.SetBool("triggered", true);
            open = !open;
            myAnim.SetBool("isOpen", open);
            Invoke("Idle", 0.1f);
     }

    void Idle()
    {
        myAnim.SetBool("triggered", false);
    }

}

