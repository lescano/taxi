using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador_viaje : MonoBehaviour 
{
  public bool encendido = false;
  public Text Tiempo_restante;
  public int const_tiempo_reset = 320;
  public float timer = 320;

  void Start(){
    Tiempo_restante = GameObject.Find ("Canvas/Tiempo_restante").GetComponent<UnityEngine.UI.Text>();
  }

  void Update(){
     
    if (encendido){
      timer -= Time.deltaTime;
      showStadoTime();
    }
  }

  public void encenderTimer(){
    encendido = true;
  }

  public bool isViaje(){
    return encendido;
  }

  public void apagarTimer(){
    showStadoTime();
    encendido = false;
    timer = const_tiempo_reset;
    mensajeMostrar("--:--");
  }

  public void mensajeMostrar(string msg){
    
    Tiempo_restante.text = msg;
  }

  public void showStadoTime(){
    
    int tiempo_viaje = (int) timer;
    int minutos = tiempo_viaje / 60;
    int segundos = tiempo_viaje - (60 * minutos);
    string m = minutos.ToString();
    string s = segundos.ToString();
    mensajeMostrar(minutos+":"+s);
  }
}
