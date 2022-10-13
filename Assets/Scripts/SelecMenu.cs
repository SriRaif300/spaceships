using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecMenu : MonoBehaviour
{
    public void StarInfinite()
    {
        SceneManager.LoadScene("Infinito");
    }
    public void StartNivel()
    {
        SceneManager.LoadScene("Level1");
    }
}
