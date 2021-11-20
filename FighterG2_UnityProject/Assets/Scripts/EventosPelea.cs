using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosPelea : MonoBehaviour
{
    [Header("Prefabs Players")]
    //Luego en la selección de presonaje será esto lo que cambiemos y seleccionaremos el prefab de cada uno 
    public GameObject PrefP1;
    public GameObject PrefP2;

    [Header("Active Players")]
    public GameObject player1;
    public GameObject player2;

    [Header("SpawnPoints")]
    public Vector3 spawnP1, spawnP2;

    [Header("Vidas")]
    public int vidasP1;
    public int vidasP2;

    private void Start()
    {
        spawnP1 = player1.transform.position;
        spawnP2 = player2.transform.position;
    }
    //Cuando un jugador muere llama a esta función
    public void PlayerDead(GameObject player) {
        if (player == player2)
        {
            vidasP2 -= 1;
            if (vidasP2 > 0) SpawnPlayer(2);
            else
            {
                //Gana el jugador 1 
                //Cargar aquí la escena de victoria
                print("Player 1 wins");
            }
        }
        else if (player == player1) 
        {
            vidasP1 -= 1;
            if (vidasP1 > 0) SpawnPlayer(1);
            else
            {
                //Gana el jugador 2
                //Cargar aquí la escena de vicoria
                print("Player 2 wins");
            }
        }
    }

    //Spawnea un jugador 
    public void SpawnPlayer(int pNum) {
        //Lo hago en un switch por si en un futuro hay más de 2 personajes
        switch (pNum) {
            case 1:
                player1 = Instantiate(PrefP1, spawnP1, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                player2 = Instantiate(PrefP2, spawnP2, new Quaternion(0, 0, 0, 0));
                break;
            default:
                print("No such a player");
                break;
        }
    }

    //Limpieza de la escena para evitar errores
    private void limpiar()
    {
        vidasP1 = -1;
        vidasP2 = -1;
        Destroy(player1);
        Destroy(player2);
    }

    private void OnDestroy()
    {
        limpiar();
    }

}
