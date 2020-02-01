using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
    //public int index;

    public void load(int levelName)
	{
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

}
