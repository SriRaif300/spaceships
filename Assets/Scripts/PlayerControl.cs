using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float ySpeed = 5.0f;
    public float rotSpeed = 210.0f;
    public float xLimit = 11.0f, yLimit = 6.8f;
    private float playerRot;
    private float xPos, yPos;
    public GameObject particules;
    GameObject controlador;
    public Image corazon;
    public Sprite[] hearts;

    void Start()
    {
        //Asignar mi rotacion z actual a playerRot
        playerRot = transform.eulerAngles.z;
        //Asigan el gameobject a la variable
        controlador = GameObject.Find("ControlVida");
        //Comprueba la vida que tienes 
        corazon.GetComponent<Image>().sprite = hearts[controlador.GetComponent<ControlVida>().GetVida()];
    }

    void Update()
    {
        //Rotamos la nave en funcion de rotSpeed y el input de usuario
        playerRot -= rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        //Mover la nave ariba y abajo
        transform.position += transform.up * ySpeed * Time.deltaTime * Input.GetAxis("Vertical");
        //Actualizamos la rotacion de la nave 
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerRot);
        //limites
        LimitsCotrol();
    }
    void LimitsCotrol()
    {
        //Obtenemos xPos e yPos actuales 
        xPos = transform.position.x;
        yPos = transform.position.y;

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

        //Aplicamos de nuevo xPos e yPos a la posicion real
        transform.position = new Vector3(xPos, yPos, 0.0f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Asteroid")
        {
            //Pilla una fucion que sirve para restar la vida inicial 
            controlador.GetComponent<ControlVida>().restarvida();
            //Cambia la imagen de las vidas de la nave 
            corazon.GetComponent<Image>().sprite = hearts[controlador.GetComponent<ControlVida>().GetVida()];
            //Genear las perticulas y muve la nave al centro de la pantalla 
            Instantiate(particules, transform.position, transform.rotation);
            transform.position = new Vector3(0f, 0f, 0f);
            //Cuando la nave se queda sin vidas se destrulle 
            if (controlador.GetComponent<ControlVida>().GetVida() == 0)
            {
                Destroy(gameObject);
                //Tambien se destrulle el objeto que tine las viadas 
                Destroy(GameObject.Find("ControlVida"));
                Destroy(GameObject.Find("Musica"));
            }
        }
    }
}
