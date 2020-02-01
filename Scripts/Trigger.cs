using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject target;
    public GameObject trigger;

    void FixedUpdate()
    {
        if (trigger.GetComponent<triggerController>().triggered == true)
        {
            target.GetComponent<doorController>().door();
        }   
    }
}