using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deathcontroller : MonoBehaviour
{
    //public int index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            {
            other.gameObject.GetComponent<GameController>().Gameover();
            }

    }
    // Start is called before the first frame update
   
}
