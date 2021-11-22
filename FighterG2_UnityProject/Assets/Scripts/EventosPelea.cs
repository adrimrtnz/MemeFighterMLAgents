using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EventosPelea : MonoBehaviour
{
    [Header("Prefabs Players")]
    //Luego en la selección de presonaje será esto lo que cambiemos y seleccionaremos el prefab de cada uno 
    public GameObject PrefP1;
    public GameObject PrefP2;

    [Header("Active Players")]
    public GameObject player1;
    public GameObject player2;

    //El jugador X necesita ser revivido
    private bool player1CanBeRespawned = false, player2CanBeRespawned = false;

    [Header("SpawnPoints")]
    public Vector3 spawnP1, spawnP2;

    [Header("Vidas")]
    public int vidasP1;
    public int vidasP2;

    

    // Victoria de jugador:                     (quien ha ganado?)
    private int victoryPlayer = 0;

    private void Start()
    {
        spawnP1 = player1.transform.position;
        spawnP2 = player2.transform.position;
    }
    private void Update()
    {
        if (player1 == null && player1CanBeRespawned) {
            SpawnPlayer(1);
            player1CanBeRespawned = false;
            vidasP1 -= 1;
        }
        if (player2 == null && player2CanBeRespawned) {
            SpawnPlayer(2);
            player2CanBeRespawned = false;
            vidasP2 -= 1;
        }
    }
    //Cuando un jugador muere llama a esta función
    public void PlayerDead(GameObject player) {
        if (player == player2)
        {
            if (vidasP2 <= 1 && victoryPlayer == 0) 
            {
                // Gana el jugador 1
                victoryPlayer = 1;
                print("Player 1 wins");
                SceneManager.LoadScene("BEscenaVictoria");         //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<      Cargar aquí la escena de victoria (gana jugador 1) Cambiar Menu por el nombre de la escena
            }
            else
            player2CanBeRespawned = true;
        }
        else if (player == player1) 
        {
            if (vidasP1 <= 1 && victoryPlayer == 0) 
            {
                //Gana el jugador 2
                victoryPlayer = 2;
                print("Player 2 wins");
                SceneManager.LoadScene("DEscenaVictoria");         //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<      Cargar aquí la escena de vicoria (gana jugador 2) Cambiar Menu por el nombre de la escena
            }
            else
            player1CanBeRespawned = true;
        }
    }

    //Spawnea un jugador 
    public void SpawnPlayer(int pNum) {
        //Lo hago en un switch por si en un futuro hay más de 2 personajes
        switch (pNum) {
            case 1:
                player1 = Instantiate(PrefP1, spawnP1, new Quaternion(0, 0, 0, 0));
                player1.name = PrefP1.name;
                break;
            case 2:
                player2 = Instantiate(PrefP2, spawnP2, new Quaternion(0, 0, 0, 0));
                player2.name = PrefP2.name;
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
