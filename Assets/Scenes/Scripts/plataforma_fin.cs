using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_fin : MonoBehaviour
{
    public Contador_viaje tiempoViaje;
    public GameObject marcador_fin;

    void Start()
    {
        marcador_fin = GameObject.Find("destinoMarker");
        tiempoViaje = GameObject.Find("Contador").GetComponent<Contador_viaje>();
    }

    void OnTriggerEnter2D(Collider2D col){
        
        if (col.gameObject.name == "auto rojo" && tiempoViaje.isViaje() && tiempoViaje.isDestino(this.gameObject.name)){
            print("Llego..");
            tiempoViaje.finalViaje();
            resetMarcadorFin();
        }
    }

    public void setMarcadorFin(){
        marcador_fin.transform.position = this.gameObject.transform.position;
    }

    public void resetMarcadorFin(){
        marcador_fin.transform.position =  new Vector3(-24, 17, -1);
    }
}
