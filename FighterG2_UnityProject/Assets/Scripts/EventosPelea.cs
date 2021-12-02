using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


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

    [Header("UI")]
    //Vida de los personajes
    public TextMeshProUGUI hpTp1;
    public TextMeshProUGUI hpTp2;

    //Carga especial de los personajes
    public Slider barraEp1;
    public Slider barraEp2;

    public TextMeshProUGUI vidasP1T;
    public TextMeshProUGUI vidasP2T;
    //Simbolo de vida
    public string vidaStr;

    //Tiempos de resurrección
    private float rezTimerMax;
    private float rezT1;
    private float rezT2;


    

    // Victoria de jugador:                     (quien ha ganado?)
    private int victoryPlayer = 0;

    private void Start()
    {
        spawnP1 = player1.transform.position;
        spawnP2 = player2.transform.position;
        hpTp1 = GameObject.Find("HPtextP1").GetComponent<TextMeshProUGUI>();
        hpTp2 = GameObject.Find("HPtextP2").GetComponent<TextMeshProUGUI>();

        rezTimerMax = 2f;
        rezT1 = rezTimerMax;
        rezT2 = rezTimerMax;

        vidasP1T.text = RepresentarVidas(vidasP1);
        vidasP2T.text = RepresentarVidas(vidasP2);
    }
    private void Update()
    {
        if (rezT1 > 0 && player1 == null) rezT1 -= Time.deltaTime;
        if (rezT2 > 0 && player2 == null) rezT2 -= Time.deltaTime;

        if (player1 == null && player1CanBeRespawned && rezT1 <= 0) {
            SpawnPlayer(1);
            player1CanBeRespawned = false;
            rezT1 = rezTimerMax;
        }
        if (player2 == null && player2CanBeRespawned && rezT2 <= 0) {
            SpawnPlayer(2);
            player2CanBeRespawned = false;
            rezT2 = rezTimerMax;
        }
        if (player1 != null)
        {
            hpTp1.text = player1.GetComponent<Atributos>().getHP().ToString() + "%";
            barraEp1.value = (float) player1.GetComponent<Atributos>().getEsp();
        }
        if (player2 != null)
        {
            hpTp2.text = player2.GetComponent<Atributos>().getHP().ToString() + "%";
            barraEp2.value = (float) player2.GetComponent<Atributos>().getEsp();
            

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
            {
                player2 = null;
                vidasP2 -= 1;
                vidasP2T.text = RepresentarVidas(vidasP2);
                player2CanBeRespawned = true;
            }
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
            {
                player1 = null;
                vidasP1 -= 1;
                vidasP1T.text = RepresentarVidas(vidasP1);
                player1CanBeRespawned = true;
            }
        }
    }

    //Spawnea un jugador 
    public void SpawnPlayer(int pNum) {
        //Lo hago en un switch por si en un futuro hay más de 2 personajes
        switch (pNum)
        {
            case 1:
                player1 = Instantiate(PrefP1, new Vector3(Random.Range(spawnP1.x, spawnP2.x), spawnP1.y, 0), new Quaternion(0, 0, 0, 0));
                player1.name = PrefP1.name;
                break;
            case 2:
                player2 = Instantiate(PrefP2, new Vector3(Random.Range(spawnP1.x, spawnP2.x), spawnP2.y, 0), new Quaternion(0, 0, 0, 0));
                player2.name = PrefP2.name;
                break;
            default:
                print("No such a player");
                break;
        }

    }


    public string RepresentarVidas(int n)
    {
        string res = "";
        for (int i = 0; i < n; i++)
        {
            res += vidaStr;
        }
        return res;
    }
    
    

}
