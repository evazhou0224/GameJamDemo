﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyMe()
    {
        GameObject t = FindObjectOfType<AudioManager>().gameObject;
        Destroy(t);
    }

}
