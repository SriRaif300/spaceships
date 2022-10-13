using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreControl : MonoBehaviour
{
    public int score = 0;
    public string scoreString = "Score:\n";  
    public Text TextScore;

    void Update()
    {
        //si el texto es igual a nulo agragar el puntaje actual
        if (TextScore != null)
        {
            TextScore.text = scoreString + score.ToString();
        }
    }
}
