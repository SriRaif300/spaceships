using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    public float xSpeed = 5.0f, ySpeed = 5.0f;
    public float xLimit = 11.0f, yLimit = 6.8f;
    private float xPos, yPos;
    public int asteroidLive = 5;
    public int numeroDeAsteroides = 2;
    public int score;
    public bool randomSpeed;
    public bool asteroidBounce;
    public bool duplicarAsteroides;
    public GameObject particules;
    public GameObject asteroid;
    GameObject scoreControl;

    void Start()
    {
        if (randomSpeed)
        {
            xSpeed = Random.Range(-xSpeed, xSpeed);
            ySpeed = Random.Range(-ySpeed, ySpeed);
        }
        //pilla la pocicion del asteroide
        xPos = transform.position.x;
        yPos = transform.position.y;
        scoreControl = GameObject.Find("ControlScore");
    }

    void Update()
    {
        //Cambiamos en cada freme la posición segun xSpeed 
        xPos += xSpeed * Time.deltaTime;
        yPos += ySpeed * Time.deltaTime;
        //Decidimos si queremos rebote o control de limites 
        if (asteroidBounce) 
        {
            BounceControl();
        }
        else
        {
            LimitsCotrol();
        }
        //Aplicamos la nueva posición
        transform.position = new Vector3(xPos, yPos, 0.0f);
    }
    void LimitsCotrol()
    {
        //Control de limites de x e y
        if (xPos > xLimit)
        {
            xPos = -xLimit;
        }
        else if (xPos < -xLimit)
        {
            xPos = xLimit;
        }
        if (yPos > yLimit)
        {
            yPos = -yLimit;
        }
        else if (yPos < -yLimit)
        {
            yPos = yLimit;
        }
    }
    void BounceControl() 
    {
        //El asteroide rebota tanto en x e y
        if (xPos > xLimit) 
        {
            xSpeed = -Mathf.Abs(xSpeed);
        }
        else if(xPos < -xLimit)
        {
            xSpeed = Mathf.Abs(xSpeed);
        }
        if (yPos > yLimit)
        {
            ySpeed = -Mathf.Abs(xSpeed);
        }
        else if (yPos < -yLimit)
        {
            ySpeed = Mathf.Abs(xSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Instantiate(particules, transform.position, transform.rotation);
            if (duplicarAsteroides)
            {
                for(int i = 0; i < numeroDeAsteroides; i++)
                {
                    Instantiate(asteroid, transform.position, transform.rotation);
                }
            }
        }
    }
    private void OnDestroy()
    {
        scoreControl.GetComponent<ScoreControl>().score += score;
    }
}

