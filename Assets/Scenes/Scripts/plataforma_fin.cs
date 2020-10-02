using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_fin : MonoBehaviour
{
    public GameObject go;
    public Contador_viaje tiempoViaje;
    public Status_jugador status;

    void OnTriggerEnter2D(Collider2D col){

        tiempoViaje = GameObject.Find("Contador").GetComponent<Contador_viaje>();
        status = GameObject.Find("status_jugador").GetComponent<Status_jugador>();
        
        if (col.gameObject.name == "auto rojo" && tiempoViaje.isViaje()){
            tiempoViaje.apagarTimer();
            status.FinViaje(50);
        }
    }
}
