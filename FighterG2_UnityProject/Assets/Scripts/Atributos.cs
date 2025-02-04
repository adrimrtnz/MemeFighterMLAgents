/// @file Atributos.cs
/// @brief Clase para gestionar los atributos de un personaje en combate.
///
/// Esta clase maneja la vida, barra especial y otros atributos como ataque, defensa y velocidad.
/// También controla la muerte del personaje y la interacción con el controlador de pelea.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class Atributos
/// @brief Gestiona los atributos del personaje y su estado en combate.
public class Atributos : MonoBehaviour
{
    private bool imDead = false;    ///< Indica si el personaje ha muerto.

    [Header("Vida")]
    public float maxHP = 100;   ///< Vida máxima del personaje.
    [SerializeField]
    private float hp;   ///< Vida actual del personaje.

    [Header("BarraEspecial")]
    [SerializeField] private float esp; ///< Barra especial del personaje.
    public float generacionEspPasiva;   ///< Cantidad de energía especial generada pasivamente por segundo.


    [Header("Otros Stats")]
    public float atk; ///< Ataque del personaje.
    public float def; ///< Defensa del personaje.
    public float vel; ///< Velocidad del personaje.

    [Header("Controlador general de la pelea")]
    public EventosPelea controladorGeneral; ///< Referencia al controlador de pelea.

    /// @brief Inicializa los valores al inicio del juego.
    private void Start()
    {
        hp = maxHP;
        esp = 0;
        imDead = false;
    }

    /// @brief Actualiza la barra especial y verifica si el personaje ha muerto.
    private void Update()
    {
        changeEsp(generacionEspPasiva * Time.deltaTime);
        if (hp <= 0 && !imDead) Kill();
    }

    /// @brief Reinicia los atributos del personaje.
    public void Reset()
    {
        //Debug.Log("Resetting player " + gameObject.name);
        imDead = false;
        hp = maxHP;
    }

    /// @brief Modifica la vida del personaje.
    /// @param x Cantidad a modificar (positiva o negativa).
    /// @return Devuelve si el personaje ha muerto.
    public bool changeHP(float x) 
    {
        if (hp > 0) hp += x;
        //Si hp <= 0 el personaje muere
        else Kill();

        return imDead;
    }

    /// @brief Devuelve la vida actual del personaje.
    /// @return Vida actual del personaje.
    public float getHP() 
    {
        return hp;
    }

    /// @brief Establece un nuevo valor de vida.
    /// @param x Nueva cantidad de vida.
    public void setHP(float x)
    {
        hp = x;
    }

    /// @brief Modifica la barra especial del personaje.
    /// @param x Cantidad a modificar (positiva o negativa).
    public void changeEsp(float x) 
    {
        esp += x;
    }

    /// @brief Establece un nuevo valor en la barra especial.
    /// @param x Nueva cantidad de barra especial
    public float getEsp() {
        return esp;
    }
    public void setEsp(float x) {
        esp = x;    
    }

    /// @brief Maneja la muerte del personaje.
    public void Kill() {
        if (imDead) return;
        imDead = true;
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
