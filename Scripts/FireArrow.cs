using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireArrow : MonoBehaviour
{
    private float fireRate = 0.7f;
    private float nextFire = 0f;
    Animator myAnim;

    public Transform bowOrigin;
    public GameObject arrow;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }
    public void Firearrow()
    {

     myAnim.SetBool("isFiring", true);          
     Instantiate(arrow, bowOrigin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Invoke("StopFire", 0.1f);
  
    }

    void StopFire()
    {
        myAnim.SetBool("isFiring", false);
    }
}
