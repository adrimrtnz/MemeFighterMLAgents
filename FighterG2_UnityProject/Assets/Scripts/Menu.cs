/// @file Menu.cs
/// @brief Controlador del menú principal del juego.
///
/// Este script gestiona la navegación del menú principal, incluyendo la pantalla de carga,
/// la selección de niveles y la opción de salir del juego.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// @class Menu
/// @brief Maneja la lógica del menú principal y la transición entre escenas.
public class Menu : MonoBehaviour
{
    /// @brief Referencia al objeto de la pantalla de carga.
    public GameObject pantallaCarga;
    /// @brief Referencia al fondo del menú.
    public GameObject fondo;
    /// @brief Referencia al contenedor de botones del menú.
    public GameObject botones;

    /// @brief Referencia al botón de "Jugar".
    public GameObject buttonPlay;

    /// @brief Referencia al slider de carga o progreso.
    public GameObject slider;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// @brief Muestra la pantalla de carga y oculta el fondo y botones del menú.
    public void PantallaCarga()
    {
        // Avtivar la pantalla de carga 

        pantallaCarga.gameObject.SetActive(true);

        fondo.gameObject.SetActive(false);

        botones.gameObject.SetActive(false);
    }

    /// @brief Carga la escena del primer nivel del juego.
    public void Jugar()
    {
        SceneManager.LoadScene("Escenario1");
    }

    /// @brief Cierra la aplicación.
    public void Salir() 
    {
        Application.Quit();
    }

    /// @brief Vuelve al menú principal cargando la escena correspondiente.
    public void VolverMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    /// @brief Activa el botón de continuar y oculta el slider.
    public void ActivarBotonContinuar() 
    {
        buttonPlay.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
    }
}
