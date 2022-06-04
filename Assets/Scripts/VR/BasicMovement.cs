using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasicMovement : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Transform cam;
    GameObject mainCamera;
    GameObject cameraPortalTaj;
    GameObject cameraPortalGod;
    public GameObject[] portales;
    private int cont;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public Text infoText;
    public Image marcoInfo;

    
    
    new Rigidbody rigidbody;
    new Camera camera;
    public float lateralMove;

    int jumps = 1;
    [SerializeField] float jumpForce = 500;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        //cameraPortalTaj = GameObject.FindWithTag("CameraPortalTaj");
        //cameraPortalGod = GameObject.FindWithTag("CameraPortalGod");
    }

    
    void Update() {
        /*lateralMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * lateralMove * Time.deltaTime * walkSpeed);*/

        Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        transform.position += velocity * Time.deltaTime;

        if (Input.GetButton("Sprint")){
            velocity = camera.transform.forward * Input.GetAxis("Vertical") * runSpeed;
            transform.position += velocity * Time.deltaTime;
        }
        else{
            velocity = camera.transform.forward * Input.GetAxis("Vertical") * walkSpeed;
            transform.position += velocity * Time.deltaTime;
        }

        // transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime); // W S arriba y abajo
        // transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime); // A D alrededor

        // LookMouse();
       
        if(Input.anyKeyDown){
            Debug.Log(Input.inputString);}
                if (Input.GetButtonDown("Jump")) {
                    if (!GameIsPaused)
                    {
                        Jump();
                    }
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("Shoot Portal");
                    Debug.Log("cont = " + cont);
                    throwPortal(portales, cont);

                }
                if (Input.GetButtonDown("Cancel"))
                {
                    infoText.text=" ";
                    marcoInfo.gameObject.SetActive(false);
                
                }
                if (Input.GetButtonDown("Menu")){
                    if (GameIsPaused){
                        Resume();
                    } else{
                        Pause();
                    }
                }
                //cameraPortalTaj.transform.rotation=mainCamera.transform.rotation;
                //cameraPortalGod.transform.rotation=mainCamera.transform.rotation;
    }

    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    void throwPortal(GameObject[] portales, int num)
    {
        Debug.Log("Portal disparado");
        // mainCamera.transform.rotation = new Quaternion(rotx, roty, rotz, rotw);
        portales[num].transform.eulerAngles = mainCamera.transform.eulerAngles;
        //   portales[num].transform.Rotate(mainCamera.transform.eulerAngles.x, portales[num].transform.eulerAngles.y  , mainCamera.transform.eulerAngles.z);
        portales[num].transform.RotateAround(Vector3.up, Mathf.PI);

        //  Debug.Log(rot);
        Debug.Log(portales[num].transform.eulerAngles);
        Debug.Log(mainCamera.transform.eulerAngles);
        portales[num].transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5.0f;
        
    }

    public void Run()
    {
        Debug.Log("Run");
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

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }

    public void PortalTaj(){
        Debug.Log("Elegiste portal de Taj");
        Resume();
        cont = 0;
        throwPortal(portales, cont);
    }
    public void PortalMano(){
        Debug.Log("Elegiste portal de Mano");
        Resume();
        cont = 1;
        throwPortal(portales, cont);
    }
    public void PortalBuque(){
        Debug.Log("Elegiste portal de Buque");
        Resume();
        cont = 2;
        throwPortal(portales, cont);
    }
    public void PortalAvion(){
        Debug.Log("Elegiste portal de avion");
        Resume();
        cont = 3;
        throwPortal(portales, cont);
    }
    public void PortalPirata(){
        Debug.Log("Elegiste portal de Pirata");
        Resume();
        cont = 4;
        throwPortal(portales, cont);
    }
    public void PortalDino(){
        Debug.Log("Elegiste portal de dinosaurio");
        Resume();
        cont = 5;
        throwPortal(portales, cont);
    }
    public void PortalMonumento(){
        Debug.Log("Elegiste portal de Monumento");
        Resume();
        cont = 6;
        throwPortal(portales, cont);
    }
    public void PortalPegaso(){
        Debug.Log("Elegiste portal de Pegaso");
        Resume();
        cont = 7;
        throwPortal(portales, cont);
    }
}