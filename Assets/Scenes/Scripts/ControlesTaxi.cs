using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesTaxi : MonoBehaviour
{
    //Velocidades del auto
    public float velMaxima = 7f;// Máxima velocidad que puede alcanzar el auto al acelerar
    private float aceleracion = 4f;// Indice que indica cuanto se tiene que mover el auto 
    private float velRotacion = 0.5f; //Velocidad de rotacion 

    //Datos habilidad nitro
    public float tiempoNitro = 10.0f; //tiempo que está activado el nitro
    private bool activarNitro = false;
    public Text tiempo_nitro;
    public Text mensaje_nitro;
    public float tiempoEsperaNitro = 30.0f;
    private bool activarTiempoEsperaNitro = false;


    Rigidbody2D rb;

    float x;// para girar el auto a la derecha o a la izquierda
    float y;// para controlar la velocidad del auto (acelerar o frenar)

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        //tiempo_nitro = GameObject.Find("Canvas/Tiempo_nitro2").GetComponent<UnityEngine.UI.Text>();
        //mensaje_nitro = GameObject.Find("Canvas/Tiempo_nitro").GetComponent<UnityEngine.UI.Text>();
    }

    void Update(){

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector2 movimiento = transform.up * (y * aceleracion);
        rb.AddForce(movimiento);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));

        if (aceleracion > 0){
            if(direction > 0){
                rb.rotation -= x * velRotacion * (rb.velocity.magnitude / velMaxima);
            }
            else{
                rb.rotation += x * velRotacion * (rb.velocity.magnitude / velMaxima);
            }
        }

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;

        Vector2 relativeForce = Vector2.right * driftForce;

        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if(rb.velocity.magnitude > velMaxima){
            rb.velocity = rb.velocity.normalized * velMaxima;
        }

        if (Input.GetKey("z")){
            if (!activarNitro && tiempoEsperaNitro==30.0f){
                Nitro();
            }

        }

        if(activarNitro){
            //tiempo_nitro.text = tiempoNitro.ToString("f0");
            tiempoNitro -= Time.deltaTime;
        }
        

        if (activarTiempoEsperaNitro){

            //mensaje_nitro.text = "Nitro en "+tiempoEsperaNitro.ToString("f0");
            //tiempo_nitro.text = "";
            tiempoEsperaNitro -= Time.deltaTime;
        }

        if(activarNitro&&tiempoNitro<= 0.0f){
            
            velMaxima = velMaxima / 2;
            aceleracion = aceleracion / 2;
            velRotacion = velRotacion / 2;

            activarNitro = false;
            tiempoNitro = 10.0f;
            //tiempo_nitro.text = "--";
            activarTiempoEsperaNitro = true;
        }

        if (tiempoEsperaNitro<= 0.0f){
            activarTiempoEsperaNitro = false;
            tiempoEsperaNitro = 30.0f;
            //mensaje_nitro.text = "Nitro:";
            //tiempo_nitro.text = "--";
        }

    }

    public void Nitro(){
        if ( activarNitro == false){
            activarNitro = true;

            velMaxima = velMaxima * 2;
            aceleracion = aceleracion * 2;
            velRotacion = velRotacion * 2;
        }
    }

}


