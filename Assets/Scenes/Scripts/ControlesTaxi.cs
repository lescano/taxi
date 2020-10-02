using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTaxi : MonoBehaviour
{
    float velMaxima = 10f;// Máxima velocidad que puede alcanzar el auto al acelerar
    float aceleracion = 7f;// Indice que indica cuanto se tiene que mover el auto 
    float velRotacion = 2f; //Velocidad de rotacion 
    
    Rigidbody2D rb;

    float x;// para girar el auto a la derecha o a la izquierda
    float y;// para controlar la velocidad del auto (acelerar o frenar)

    void Start(){
    	rb = GetComponent<Rigidbody2D>();

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

    	//Debug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.green);
    }
}


