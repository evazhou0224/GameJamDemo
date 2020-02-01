using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroy : MonoBehaviour
{
    public float aliveTime;

    // Awake is called after the object is first created
    void Awake()
    {
        Destroy(gameObject, aliveTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
