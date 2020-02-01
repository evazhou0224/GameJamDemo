using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool isPaused;
    public GameObject menu;

    void Start()
    {
        isPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update(){
        if (Input.GetKeyDown("escape"))
        {
            this.pauseGame();
        }

       }

    public void pauseGame()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            menu.SetActive(false);
        }
    }
}
