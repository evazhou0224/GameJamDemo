using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelcontrol : MonoBehaviour
{
    //public int index;
    public int levelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }

    }
    // Start is called before the first frame update

}
