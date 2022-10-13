using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyFinal : MonoBehaviour
{
    public GameObject levelFinishe;
    GameObject controlador;
    private void Start()
    {
        controlador = GameObject.Find("ControlVida");
    }
    private void Update()
    {
        if (levelFinishe == null)
        {
            Destroy(controlador);
        }
        else if (GameObject.FindGameObjectsWithTag("Asteroid").Length == 0)
        {
            Destroy(controlador);
        }
    }
   
}
