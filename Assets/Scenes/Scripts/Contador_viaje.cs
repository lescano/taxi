using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador_viaje : MonoBehaviour 
{

  /*------ Tiempo */
  public bool encendido = false;
  public Text Tiempo_restante;
  public int const_tiempo_reset = 320;
  public float timer = 320;

  /*------ Paradas y Destinos */
  public List<GameObject> Destinos = new List<GameObject>();
  public List<GameObject> Inicios = new List<GameObject>();

  public GameObject destino_object = null;
  public GameObject inicio_object = null;

  /*------ Mensajes */
  public  Text msg_iu;
  public float msg_time = 0;

  /*------  status */
  public Status_jugador status;

  void Start(){

    Tiempo_restante = GameObject.Find("Canvas/Tiempo_restante").GetComponent<UnityEngine.UI.Text>();
    msg_iu = GameObject.Find("Canvas/Destino_pasajero").GetComponent<UnityEngine.UI.Text>();
    status = GameObject.Find("status_jugador").GetComponent<Status_jugador>();

    for (int i = 1; i <= 10 ; i++){ // Destinos
      Destinos.Add(GameObject.Find("plataforma_fin_"+i.ToString()));
    }

    for (int i = 1; i <= 5 ; i++){ // Inicios
      Inicios.Add(GameObject.Find("plataforma_ini_"+i.ToString()));
    }

    nuevoInicioViaje();
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

  public void iniciarViaje(){

    if(isViaje()){
      return;
    }
    int id_destino_random = regenrarDestinoRandom();
    destino_object = findDestinoByName("plataforma_fin_"+id_destino_random.ToString());
    destino_object.GetComponent<plataforma_fin>().setMarcadorFin();
    setMessage("Nuevo pasajero",2);
    encendido = true;
  }

  public void finalViaje(){

    destino_object = null;
    inicio_object = null;
    encendido = false;
    timer = const_tiempo_reset;
    mensajeMostrar("--:--");
    setMessage("LLego a destino.",3);
    
    status.FinViaje(100);
    nuevoInicioViaje();
  }

  public void nuevoInicioViaje(){

    int id_ini = regenrarInicioRandom();
    inicio_object = findInicioByName("plataforma_ini_"+id_ini.ToString());
    inicio_object.GetComponent<plataforma_ini>().setMarcadorIni();
  }

  public int regenrarDestinoRandom(){
    return Random.Range(Random.Range(1,5),Random.Range(5,10));
  }

  public int regenrarInicioRandom(){
    return Random.Range(Random.Range(1,3),Random.Range(3,5));
  }

  public bool isDestino(string name_destino_plataforma){

    string nombre = destino_object.name;
    if(nombre.Equals(name_destino_plataforma)) {
      return true; 
    }else{
      return false;
    }
  }

  public bool isInicio(string name_inicio_plataforma){

    string nombre = inicio_object.name;
    if(nombre.Equals(name_inicio_plataforma)) {
      return true; 
    }else{
      return false;
    }
  }

  public bool isViaje(){
    return encendido;
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

  public GameObject findDestinoByName(string name){

    foreach(GameObject objet in Destinos){
      if( objet.name == name){
        return objet;
      }
    }
    return null;
  }

  public GameObject findInicioByName(string name){

    foreach(GameObject objet in Inicios){
      if( objet.name == name){
        return objet;
      }
    }
    return null;
  }

}
