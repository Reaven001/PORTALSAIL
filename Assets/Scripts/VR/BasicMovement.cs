using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {
    public Transform cam;
    public GameObject Portal;
    GameObject mainCamera;
    GameObject cameraPortalTaj;
    GameObject cameraPortalGod;
    public GameObject[] portales;
    private int cont = 0;
    private float speed = 10;
    public Text infoText;

    float vMouse;
    float hMouse;
    float yReal = 0.0f;
    public float horizontalSpeed;
    public float verticalSpeed;
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
        cameraPortalTaj = GameObject.FindWithTag("CameraPortalTaj");
        cameraPortalGod = GameObject.FindWithTag("CameraPortalGod");
    }

    
    void Update() {
        lateralMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * lateralMove * Time.deltaTime * speed);

        Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
        transform.position += velocity * Time.deltaTime;

        // transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime); // W S arriba y abajo
        // transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime); // A D alrededor

        // LookMouse();
       
        if(Input.anyKeyDown){
            Debug.Log(Input.inputString);}
                if (Input.GetButtonDown("Jump")) {
                    Jump();
                        infoText.text=" ";

                }

                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("Shoot Portal");
                    Debug.Log("cont = " + cont);
                    throwPortal(portales, cont);
                        infoText.text=" ";

                }
                if (Input.GetButtonDown("Fire2"))
                {
                        infoText.text=" ";

                    Debug.Log("Cambiaste portal");
                    if(cont<=portales.Length-1){
                        cont += 1;
                    }else{
                        cont =0;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown("j"))
                {
                        infoText.text=" ";

                    Run();
                
                }
                /*if (Input.GetButtonDown("Menu"))
                {
                    Debug.Log("Abriste el menu");
                    
                }*/
                cameraPortalTaj.transform.rotation=mainCamera.transform.rotation;
                cameraPortalGod.transform.rotation=mainCamera.transform.rotation;
    }

    void LookMouse()
    {
        hMouse = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        vMouse = Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;

        yReal -= vMouse;
        yReal = Mathf.Clamp(yReal, -90f, 90f);
        transform.Rotate(0f, hMouse, 0f);
        cam.localRotation = Quaternion.Euler(yReal, 0.0f, 0.0f);
    }

    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    void throwPortal(GameObject[] portales, int num)
    {
        
        Debug.Log("num = " + num);
        portales[num].transform.rotation = mainCamera.transform.rotation;
        portales[num].transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5.0f;
        cont = 0;
    }

    public void Run()
    {
        Debug.Log("Run");
    }

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }

    
    public void PortalAvion(){
        Debug.Log("Elegiste portal de avion");
    }

    public void PortalDino(){
        Debug.Log("Elegiste portal de dinosaurio");
    }

    public void PortaBuque(){
        Debug.Log("Elegiste portal de buque");
    }

    public void PortalPirata(){
        Debug.Log("Elegiste portal de barco pirata");
    }
}