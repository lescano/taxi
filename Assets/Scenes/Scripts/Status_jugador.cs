using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_jugador : MonoBehaviour
{
    
    /* datos del jugo */
    int dia;
    int dia_monto;
    int cant_pasajeros_dia;

    /* jugador */
    int dinero;

    /* viaje */
    int monto_viaje;

    /* Mensajes */
    public Text msg_dia_monto;
    public Text msg_dia_numero;
    public Text msg_dinero;

    void Start()
    {
        msg_dia_monto = GameObject.Find ("Canvas/Monto_dia").GetComponent<UnityEngine.UI.Text>();
        msg_dia_numero = GameObject.Find ("Canvas/Nro_Dia").GetComponent<UnityEngine.UI.Text>();
        msg_dinero = GameObject.Find ("Canvas/Dinero").GetComponent<UnityEngine.UI.Text>();
        ResetDatos();
    }

    void Update(){

    }

    /*--------------------------------------------------------*/
    public void ResetDatos(){

        print("RESET GAME");
        dia = 1;
        dia_monto = 150;
        cant_pasajeros_dia = 0;
        dinero = 0;
        monto_viaje = 0;

        setMensajeDia(dia.ToString());
        setMensajeDinero(dinero.ToString());
        setMensajeMonto(dia_monto.ToString());
    }

    public void setMensajeMonto(string msg){
        msg_dia_monto.text = "Dinero necesario: "+msg;
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
        setMensajeDinero(dinero.ToString()); // Actualiza el msg en pantalla
    }
    
    public void SumerPasajeroAlDia(){
        cant_pasajeros_dia = cant_pasajeros_dia +1;
    }

    public void FinViaje(int paga){
        SumarPaga(paga);
        SumerPasajeroAlDia();
        if (cant_pasajeros_dia == 3){
            CheckMonto();
        }
    }

    public void CheckMonto(){
        if(dia_monto <= dinero){
            SumarDia();
        }
    }

    public void SumarDia(){
        dia = dia + 1;
        dia_monto = dia_monto + 1;
        cant_pasajeros_dia = 0;
        dinero = 0;

        setMensajeDia(dia.ToString());
        setMensajeDinero(dinero.ToString());
        setMensajeMonto(dia_monto.ToString());
    }
}
