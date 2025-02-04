/// @file PauseMenu.cs
/// @brief Gestiona el menú de pausa del juego.
///
/// Este script permite pausar y reanudar el juego cuando el jugador presiona la tecla "Escape",
/// activando o desactivando la interfaz del menú de pausa. También proporciona una opción
/// para regresar al menú principal.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// @class PauseMenu
/// @brief Controla el sistema de pausa del juego.
public class PauseMenu : MonoBehaviour
{
    /// @brief Indica si el juego está pausado o no.
    public static bool GameIsPaused = false;

    /// @brief Referencia al objeto del menú de pausa en la interfaz.
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

    /// @brief Reanuda el juego desactivando el menú de pausa y restaurando el tiempo.
    public void Resume() 
    {
        //Desactivar pantalla pause y deanudar el tiempo
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// @brief Pausa el juego activando el menú de pausa y deteniendo el tiempo.
    public void Pause()
    {
        //Activar la pantalla de pause y detener el tiempo
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        GameIsPaused = true;
    }

    /// @brief Carga la escena del menú principal y reanuda el tiempo normal del juego.
    public void Buttonmenu()
    {
        //Cargar la pantalla de menú y reanudar el tiempo 
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
