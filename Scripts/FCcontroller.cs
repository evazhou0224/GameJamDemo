using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCcontroller : MonoBehaviour
{

    public int Currentscene;

	void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex != Currentscene)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


}
