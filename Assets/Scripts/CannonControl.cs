using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public GameObject theBullet;
    private float fireRate;

    void Update()
    {
        //Si el usuario pulsa el boton creara una bala 
        fireRate += Time.deltaTime;
        if (Input.GetButton("Fire1") && fireRate > 0.2f)
        {
            fireRate = 0;
            GameObject newBullet = Instantiate(theBullet, transform.position, transform.rotation);
        }
    }
}
