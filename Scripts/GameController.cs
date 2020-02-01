using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject menu;
    public GameObject Conflict;

    void Start()
    {
        menu.SetActive(false);
    }

    public void Gameover()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        Conflict.SetActive(false);
    }
}