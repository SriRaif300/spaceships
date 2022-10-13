using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenrate : MonoBehaviour
{
    private float xLimit = 15.0f, yLimit = 8.0f;
    public GameObject asteroide;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(asteroide, new Vector2(Random.Range(-xLimit, xLimit), Random.Range(-yLimit, yLimit)), Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Asteroid").Length <= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(asteroide, new Vector2(Random.Range(-xLimit, xLimit), Random.Range(-yLimit, yLimit)), Quaternion.identity);
            }
        }
    }
}
