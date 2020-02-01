using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int enemyMaxHealth;
    public float damageRate;
    private int enemyCurrentHealth;

    public GameObject explosionEffect;
    Animator myAnim;

    //For hit
    private float nextDamage;
    private bool enemyDamaged;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        nextDamage = 0f;
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextDamage < Time.time && enemyDamaged)
        {
            myAnim.SetBool("enemyHit", enemyDamaged);
        }
        else if (nextDamage > Time.time && enemyDamaged)
        {
            enemyDamaged = false;    
            myAnim.SetBool("enemyHit", enemyDamaged);
        }
    }

    public void addDamage(int damage)
    {
        if (nextDamage < Time.time)
        {
            enemyDamaged = true;
            enemyCurrentHealth -= damage;
            if (enemyCurrentHealth <= 0) ripEnemy();
            nextDamage = Time.time + damageRate;
            myAnim.SetBool("enemyHit", enemyDamaged);
        }
    }

    void ripEnemy()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
