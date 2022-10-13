using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{
    public GameObject gamerOver, levelFinishe;
    public GameObject playerShip;
    public int gameOverScene, levelFinicheScene;

    void Start()
    {
        gamerOver.SetActive(false);
        levelFinishe.SetActive(false);
    }

    void Update()
    {
        if (gamerOver == null)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        else if (playerShip == null)
        {
            gamerOver.SetActive(true);
        }
        if (levelFinishe == null)
        {
            SceneManager.LoadScene(levelFinicheScene);
        }
        else if (GameObject.FindGameObjectsWithTag("Asteroid").Length == 0)
        {
            levelFinishe.SetActive(true);
        }
        
    }
}
