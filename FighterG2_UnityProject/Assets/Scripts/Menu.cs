using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pantallaCarga;
    public GameObject fondo;
    public GameObject botones;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PantallaCarga()
    {
        // Avtivar la pantalla de carga 

        pantallaCarga.gameObject.SetActive(true);

        fondo.gameObject.SetActive(false);

        botones.gameObject.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Escenario1");
    }

    public void Salir() 
    {
        Application.Quit();
    }

    public void VolverMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
