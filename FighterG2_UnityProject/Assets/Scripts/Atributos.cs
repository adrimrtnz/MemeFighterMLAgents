using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    [Header("Vida")]
    public float maxHP = 100;
    [SerializeField]
    private float hp;

    [Header("BarraEspecial")]
    [SerializeField] private float esp;
    //Cuanto se le rellena la barra por segundo pasivamente
    public float generacionEspPasiva;

    
    [Header("Otros Stats")]
    //Poner aquí otros atributos como puede ser ataque, defensa, velocidad....
    //Actualmente no sirven para nada
    public float atk;       //Ataque
    public float def;       //Defensa
    public float vel;       //Velocidad

    [Header("Controlador general de la pelea")]
    public GameObject controladorGeneral; 

    private void Start()
    {
        controladorGeneral = GameObject.Find("ControladorEventos");
        hp = maxHP;
        esp = 0;
    }

    private void Update()
    {
        changeEsp(generacionEspPasiva * Time.deltaTime);
    }

    //La vida solo es accesible mediante funciones para controlar cuando se modifica
    //Modifica la vida del personaje
    public void changeHP(float x) {
        if (hp > 0) hp += x;
        //Si hp <= 0 el personaje muere
        else Destroy(this.gameObject);
    }
    //Devuelve la vida
    public float getHP() {
        return hp;
    }
    public void setHP(float x) {
        hp = x;
    }

    //Protejemos la barra especial por el mismo motivo que antes
    public void changeEsp(float x) {
        esp += x;
    }

    public float getEsp() {
        return esp;
    }
    public void setEsp(float x) {
        esp = x;    
    }
    //Cuando muere el personaje se llama esta munción (siempre que se destruye el objeto)
    private void OnDestroy()
    {
        if (controladorGeneral != null) controladorGeneral.GetComponent<EventosPelea>().PlayerDead(this.gameObject);
    }
}
