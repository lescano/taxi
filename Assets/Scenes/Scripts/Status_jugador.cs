using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_jugador : MonoBehaviour
{
    
    /* datos del jugo */
    int dia;
    int dinero_necesario;
    int cant_pasajeros_total_dia;
    int cant_pasajeros_dia;

    /* jugador */
    int dinero;

    /* viaje */
    int monto_viaje;

    /* Mensajes */
    public Text msg_dinero_necesario;
    public Text msg_dia_numero;
    public Text msg_dinero;
    public Text msg_info;

    public float msg_info_time = 0;


    void Start()
    {
        msg_dinero_necesario = GameObject.Find ("Canvas/Monto_dia").GetComponent<UnityEngine.UI.Text>();
        msg_dia_numero = GameObject.Find ("Canvas/Nro_Dia").GetComponent<UnityEngine.UI.Text>();
        msg_dinero = GameObject.Find ("Canvas/Dinero").GetComponent<UnityEngine.UI.Text>();
        msg_info = GameObject.Find ("Canvas/Mensaje_info").GetComponent<UnityEngine.UI.Text>();
        ResetDatos();
    }

    void Update(){
        if(msg_info_time > 0){
            msg_info_time -= Time.deltaTime;
            if(msg_info_time < 1){
                setMessageInfo("",0);
            }
        }
    }

    /*--------------------------------------------------------*/
    public void ResetDatos(){

        print("RESET GAME");
        dia = 1;
        dinero_necesario = 200;
        cant_pasajeros_total_dia = 2;
        cant_pasajeros_dia = 0;
        dinero = 0;
        monto_viaje = 0;
        msg_info_time = 0;

        setMensajeDia(dia.ToString());
        setMensajeDinero(dinero.ToString());
        setMensajeMonto(dinero_necesario.ToString());
    }

    public void setMensajeMonto(string msg){
        msg_dinero_necesario.text = "Dinero necesario: "+msg;
    }

    public void setMensajeDia(string msg){
        msg_dia_numero.text = "Dia nro: "+msg;
    }

    public void setMensajeDinero(string msg){
        msg_dinero.text = "Dinero: "+msg;
    }

    /*--------------------------------------------------------*/

    public void SumarPaga(int paga){
        dinero = dinero + paga;
        setMessageInfo("Se ha recibido la paga: "+paga.ToString(),2);
        setMensajeDinero(dinero.ToString()); // Actualiza el msg en pantalla
        
    }
    
    public void SumarPasajeroAlDia(){
        cant_pasajeros_dia = cant_pasajeros_dia +1;
    }

    public void FinViaje(int paga){
        SumarPaga(paga);
        SumarPasajeroAlDia();
        if (cant_pasajeros_dia == cant_pasajeros_total_dia){
            CheckMonto();
        }
    }

    public void CheckMonto(){
        if(dinero_necesario <= dinero){
            SumarDia();
        }
    }

    public void SumarDia(){
        dia = dia + 1;
        dinero_necesario = dinero_necesario + 200;
        cant_pasajeros_total_dia = cant_pasajeros_total_dia + 2;
        cant_pasajeros_dia = 0;
        dinero = 0;

        setMensajeDia(dia.ToString());
        setMensajeDinero(dinero.ToString());
        setMensajeMonto(dinero_necesario.ToString());
        setMessageInfo("A pasado al dia :"+dia.ToString(),2);
    }

    public void setMessageInfo(string msg, float time){
        msg_info_time = time;
        msg_info.text = msg;
  }
}
