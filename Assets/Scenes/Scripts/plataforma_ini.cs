using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_ini : MonoBehaviour
{
    public Contador_viaje tiempoViaje;
    public GameObject marcador_ini;

    void Start(){
        marcador_ini = GameObject.Find("inicioMarker");   
    }

    void OnTriggerEnter2D(Collider2D col){
        
        tiempoViaje = GameObject.Find("Contador").GetComponent<Contador_viaje>();
        if (col.gameObject.name == "auto rojo" && tiempoViaje.isInicio(this.gameObject.name)){    
            tiempoViaje.iniciarViaje();
            resetMarcadorIni();
        }
    }

    public void setMarcadorIni(){
        marcador_ini.transform.position = this.gameObject.transform.position;
    }

    public void resetMarcadorIni(){
        marcador_ini.transform.position =  new Vector3(-24, 17, -1);
    }
}
