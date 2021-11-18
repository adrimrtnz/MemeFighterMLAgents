using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    [Header("Vida")]
    public float maxHP = 100;
    [SerializeField]
    private float hp;

    
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
        hp = maxHP;
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

    //Cuando muere el personaje se llama esta munción (siempre que se destruye el objeto)
    private void OnDestroy()
    {
        controladorGeneral.GetComponent<EventosPelea>().PlayerDead(this.gameObject);
    }
}
