/// @file PauseMenu.cs
/// @brief Gestiona el men� de pausa del juego.
///
/// Este script permite pausar y reanudar el juego cuando el jugador presiona la tecla "Escape",
/// activando o desactivando la interfaz del men� de pausa. Tambi�n proporciona una opci�n
/// para regresar al men� principal.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// @class PauseMenu
/// @brief Controla el sistema de pausa del juego.
public class PauseMenu : MonoBehaviour
{
    /// @brief Indica si el juego est� pausado o no.
    public static bool GameIsPaused = false;

    /// @brief Referencia al objeto del men� de pausa en la interfaz.
    public GameObject pauseMenu;

    void Start(){}

    /// @brief Detecta si el jugador presiona la tecla "Escape" para alternar el estado de pausa.
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            // Si no esta pausado pausarlo 
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    /// @brief Reanuda el juego desactivando el men� de pausa y restaurando el tiempo.
    public void Resume() 
    {
        //Desactivar pantalla pause y deanudar el tiempo
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// @brief Pausa el juego activando el men� de pausa y deteniendo el tiempo.
    public void Pause()
    {
        //Activar la pantalla de pause y detener el tiempo
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        GameIsPaused = true;
    }

    /// @brief Carga la escena del men� principal y reanuda el tiempo normal del juego.
    public void Buttonmenu()
    {
        //Cargar la pantalla de men� y reanudar el tiempo 
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
