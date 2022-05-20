using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPortal : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu")){
            if (GameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    void Resume(){
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        Debug.Log("Pausa");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PortalAvion(){
        Debug.Log("Elegiste portal de avion");
        Resume();
    }

    public void PortalDino(){
        Debug.Log("Elegiste portal de dinosaurio");
        Resume();
    }

    public void PortaBuque(){
        Debug.Log("Elegiste portal de buque");
        Resume();
    }

    public void PortalPirata(){
        Debug.Log("Elegiste portal de barco pirata");
        Resume();
    }
}
