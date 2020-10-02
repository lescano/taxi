using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_ini : MonoBehaviour
{
    public GameObject go;
    public Contador_viaje tiempoViaje;

    void start(){
        /*
        print("Hola2: ");
        Debug.Log("Inicio Timer2222");
        GameObject go = GameObject.Find("auto rojo");
        print("Hola: " + go);
        */
    }

    void OnTriggerEnter2D(Collider2D col){

        tiempoViaje = GameObject.Find("Contador").GetComponent<Contador_viaje>();
        
        if (col.gameObject.name == "auto rojo"){
            tiempoViaje.encenderTimer();
        }
    }
}
