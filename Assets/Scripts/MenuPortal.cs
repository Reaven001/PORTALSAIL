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
        if (Input.GetButtonDown("Pause")){
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

    public void Inicio()
    {
        Debug.Log("Te vas al inicio");
    }
    public void Instrucciones()
    {
        Debug.Log("Te vas a las instrucciones");
    }
    public void Salir()
    {
        Debug.Log("Saliste del juego");
    }
    
}
