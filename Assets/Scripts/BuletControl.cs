using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletControl : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public float xLimit = 11.0f, yLimit = 6.8f;
    private float xPos, yPos;

    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
