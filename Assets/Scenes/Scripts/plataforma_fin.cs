using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_fin : MonoBehaviour
{
    public GameObject go;
    public Contador_viaje tiempoViaje;
    public Status_jugador status;
    public GameObject marcador;

    void Start()
    {
        marcador = GameObject.Find("destinoMarker");
        tiempoViaje = GameObject.Find("Contador").GetComponent<Contador_viaje>();
        status = GameObject.Find("status_jugador").GetComponent<Status_jugador>();
    }

    void OnTriggerEnter2D(Collider2D col){
        
        if (col.gameObject.name == "auto rojo" && tiempoViaje.isViaje() && tiempoViaje.isDestino(this.gameObject.name)){
            print("FIN..");
            tiempoViaje.apagarTimer();
            status.FinViaje(100);
            resetMarcador();
        }
    }

    public void serMarcador(){
        marcador.transform.position = this.gameObject.transform.position;
    }

    public void resetMarcador(){
        marcador.transform.position =  new Vector3(-24, 17, -1);
    }
/*
    public int getId(){

        //char id = this.gameObject.name.Split("_")[2];
        print(this.gameObject.name); 
        return 1;
    }
*/
}
