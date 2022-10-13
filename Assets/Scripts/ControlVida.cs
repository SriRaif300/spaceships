using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVida : MonoBehaviour
{
    //La vida que tendra la nave
    public int vida = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    //funciones que se utliza en el script de Player controle
    public void restarvida()
    {
        vida--;
    }
    
    public int GetVida()
    {
        return vida;
    }
}
