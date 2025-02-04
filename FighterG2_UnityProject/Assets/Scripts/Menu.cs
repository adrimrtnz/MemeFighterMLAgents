/// @file Menu.cs
/// @brief Controlador del men� principal del juego.
///
/// Este script gestiona la navegaci�n del men� principal, incluyendo la pantalla de carga,
/// la selecci�n de niveles y la opci�n de salir del juego.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// @class Menu
/// @brief Maneja la l�gica del men� principal y la transici�n entre escenas.
public class Menu : MonoBehaviour
{
    /// @brief Referencia al objeto de la pantalla de carga.
    public GameObject pantallaCarga;
    /// @brief Referencia al fondo del men�.
    public GameObject fondo;
    /// @brief Referencia al contenedor de botones del men�.
    public GameObject botones;

    /// @brief Referencia al bot�n de "Jugar".
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

    /// @brief Muestra la pantalla de carga y oculta el fondo y botones del men�.
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

    /// @brief Cierra la aplicaci�n.
    public void Salir() 
    {
        Application.Quit();
    }

    /// @brief Vuelve al men� principal cargando la escena correspondiente.
    public void VolverMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    /// @brief Activa el bot�n de continuar y oculta el slider.
    public void ActivarBotonContinuar() 
    {
        buttonPlay.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
    }
}
