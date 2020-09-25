using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTaxi : MonoBehaviour
{

    private float aceleracion;
    private float velocidad;
    //la dirección se define así:
    //0 = sur
    //1 = este
    //2 = norte
    //3 = oeste
    private int direccion;
    private float anguloRotacion = 0.0f;

    // Esta función se llama cuando comienza el juego
    void Start()
    {
        aceleracion = 5.0f;
        direccion = 0;
    }

    // Esta función se va a llamar una vez por frame
    // Por defecto unity estaría llamando 60 veces por segundo
    void Update()
    {
        Vector3 posicion = transform.position;
        //Vector3 rotacion = transform.Rotation;

        velocidad = Input.GetAxis("Vertical") * aceleracion;
        //transform.Rotate(0,0,-aceleracion);


        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");
 
        //mover auto hacia adelante
        //Input.GetKey("up")
        //transform.position.y <= 4.5f && 
        if (Input.GetKey("w")){
            if(direccion == 0){
                posicion.y -= aceleracion * Time.deltaTime ;
            }
            if(direccion == 1){
                posicion.x += aceleracion * Time.deltaTime;
            }
            if(direccion == 2){
                posicion.y += aceleracion * Time.deltaTime;
            }
            if(direccion == 3){
                posicion.x -= aceleracion * Time.deltaTime;
            }
            //posicion.y += aceleracion * Time.deltaTime;
        }

        //mover auto hacia atras
        //Input.GetKey("down")
        //transform.position.y >= -4.5f &&
        if (Input.GetKey("s")){
            if(direccion == 0){
                posicion.y += aceleracion * Time.deltaTime;
            }
            if(direccion == 1){
                posicion.x -= aceleracion * Time.deltaTime;
            }
            if(direccion == 2){
                posicion.y -= aceleracion * Time.deltaTime;
            }
            if(direccion == 3){
                posicion.x += aceleracion * Time.deltaTime;
            }
            //posicion.y -= aceleracion * Time.deltaTime;
        }

        //mover auto hacia la derecha
        //Input.GetKey("right")
        //
        if (Input.GetKey("d")){
            if (anguloRotacion >= 0.0f && anguloRotacion < 90.0f){
                //anguloRotacion += 0.05f;
                //transform.Rotate(0,0,anguloRotacion);
            }
            if (anguloRotacion <= 180.0f && anguloRotacion >= 90.0f){
                //anguloRotacion -= 0.05f;
                //transform.Rotate(0,0,anguloRotacion);
            }
            posicion.x += aceleracion * Time.deltaTime;
            //posicion.x += aceleracion * Time.deltaTime;
        }

        //mover auto hacia la izquierda
        //Input.GetKey("left")
        //transform.position.x >= -7.5f &&
        if (Input.GetKey("a")){
            if (anguloRotacion <= 0.0f && anguloRotacion >= -90.0f){
                //anguloRotacion -= 0.05f;
                //transform.Rotate(0,0,anguloRotacion);
            }
            if (anguloRotacion >= 180.0f && anguloRotacion < -90.0f){
                //anguloRotacion += 0.05f;
                //transform.Rotate(0,0,anguloRotacion);
            }
            posicion.x -= aceleracion * Time.deltaTime;

            //posicion.x -= aceleracion * Time.deltaTime;
        }

        transform.position = posicion;
    }
}


