using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosPelea : MonoBehaviour
{

    public GameObject player1, player2;
    
    //Cuando un jugador muere llama a esta función
    public void PlayerDead(GameObject player) {
        if (player == player2)
        {
            //Gana el jugador 1 
            //Cargar aquí la escena de victoria
            print("Player 1 wins");
        }
        else if (player == player1) 
        {
            //Gana el jugador 2
            //Cargar aquí la escena de vicoria
            print("Player 2 wins");
        }
    }
}
