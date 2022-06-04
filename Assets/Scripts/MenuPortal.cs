using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPortal : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Image imagen;
    public Transform Target;
    public GameObject ThePlayer;
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
        if (Input.GetButtonDown("Cancel")){
            Resume();
        }
        
    }

    void Resume(){
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        imagen.gameObject.SetActive(false);
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
        ThePlayer.transform.position=Target.transform.position;
        Resume();
    }
    public void Instrucciones()
    {
        Debug.Log("Instrucciones");
        imagen.gameObject.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliste del juego");
    }
    
}
