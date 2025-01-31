using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    private bool imDead = false;

    [Header("Vida")]
    public float maxHP = 100;
    [SerializeField]
    private float hp;

    [Header("BarraEspecial")]
    [SerializeField] private float esp;
    //Cuanto se le rellena la barra por segundo pasivamente
    public float generacionEspPasiva;

    
    [Header("Otros Stats")]
    //Poner aqu� otros atributos como puede ser ataque, defensa, velocidad....
    //Actualmente no sirven para nada
    public float atk;       //Ataque
    public float def;       //Defensa
    public float vel;       //Velocidad

    [Header("Controlador general de la pelea")]
    public EventosPelea controladorGeneral; 

    private void Start()
    {
        hp = maxHP;
        esp = 0;
        imDead = false;
    }

    private void Update()
    {
        changeEsp(generacionEspPasiva * Time.deltaTime);
        if (hp <= 0 && !imDead) Kill();
    }

    public void Reset()
    {
        Debug.Log("Resetting player " + gameObject.name);
        imDead = false;
        hp = maxHP;
    }

    //La vida solo es accesible mediante funciones para controlar cuando se modifica
    //Modifica la vida del personaje
    public bool changeHP(float x) {
        if (hp > 0) hp += x;
        //Si hp <= 0 el personaje muere
        else Kill();

        return imDead;
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
    //Cuando muere el personaje se llama esta munci�n (siempre que se destruye el objeto)
    // private void OnDestroy()
    // {
    //     if (controladorGeneral != null) controladorGeneral.GetComponent<EventosPelea>().PlayerDead(this.gameObject);
    // }

    public void Kill() {
        if (imDead) return;
        imDead = true;
        Debug.Log("Player DEADDDD " + gameObject.name);
        hp = 0;
        if (controladorGeneral != null) controladorGeneral.PlayerDead(this.gameObject);

        if (GetComponent<Bunny_Agent>() != null) {
            GetComponent<Bunny_Agent>().HandleDeadPenalty();
        }       
        else if (GetComponent<Doge_Agent>() != null) {
            GetComponent<Doge_Agent>().HandleDeadPenalty();
        }
    }
}
