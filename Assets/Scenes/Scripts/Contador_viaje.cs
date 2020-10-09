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
  public int id_destino;
  public GameObject destino_object;
  public  Text msg_iu;
  public float msg_time = 0;

  void Start(){
    Tiempo_restante = GameObject.Find ("Canvas/Tiempo_restante").GetComponent<UnityEngine.UI.Text>();
    msg_iu = GameObject.Find ("Canvas/Destino_pasajero").GetComponent<UnityEngine.UI.Text>();
    destino_object = null;
  }

  void Update(){
     
    if (encendido){
      timer -= Time.deltaTime;
      showStadoTime();
    }
    if(msg_time > 0){
      msg_time -= Time.deltaTime;
      if(msg_time < 1){
        setMessage("",0);
      }
    }
  }

  public void encenderTimer(){

    if(isViaje()){
      return;
    }
    id_destino = Random.Range(Random.Range(1,5),Random.Range(5,10));
    destino_object = GameObject.Find("plataforma_fin_"+id_destino.ToString());
    destino_object.GetComponent<plataforma_fin>().serMarcador();
    setMessage("Nuevo pasajero",2);
    encendido = true;
  }

  public bool isDestino(string name_destino_plataforma){
    string text = destino_object.name;
    if(text.Equals(name_destino_plataforma)) {
      return true; 
    }else{
      return false;
    }
  }

  public bool isViaje(){
    return encendido;
  }

  public void apagarTimer(){

    showStadoTime();
    encendido = false;
    timer = const_tiempo_reset;
    mensajeMostrar("--:--");
    setMessage("LLego a destino.",5);
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

  public void setMessage(string msg, float time){
    msg_time = time;
    msg_iu.text = msg;
  }
}
