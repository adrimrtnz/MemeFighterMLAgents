using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    public void Resume() 
    {
        //Desactivar pantalla pause y deanudar el tiempo
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        //Activar la pantalla de pause y detener el tiempo
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        GameIsPaused = true;
    }


    public void Buttonmenu()
    {
        //Cargar la pantalla de menú y reanudar el tiempo 
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
