using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int firsLevel = 1;

    public void start()
    {
        SceneManager.LoadScene(firsLevel);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
