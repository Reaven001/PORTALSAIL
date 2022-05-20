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
    private int cont;
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

                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown("j"))
                {
                        infoText.text=" ";

                    Run();
                
                }
                cameraPortalTaj.transform.rotation=mainCamera.transform.rotation;
                cameraPortalGod.transform.rotation=mainCamera.transform.rotation;
    }

        public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    void throwPortal(GameObject[] portales, int num)
    {
        //portales[num].transform.rotation = mainCamera.transform.rotation;
        portales[num].transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5.0f;
        
    }

    public void Run()
    {
        Debug.Log("Run");
    }

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }

    public void PortalTaj(){
        Debug.Log("Elegiste portal de Taj");
        cont = 0;
    }
    public void PortalMano(){
        Debug.Log("Elegiste portal de Mano");
        cont = 1;
    }
    public void PortalBuque(){
        Debug.Log("Elegiste portal de Buque");
        cont = 2;
    }
    public void PortalAvion(){
        Debug.Log("Elegiste portal de avion");
        cont = 3;
    }
    public void PortalPirata(){
        Debug.Log("Elegiste portal de Pirata");
        cont = 4;
    }
    public void PortalDino(){
        Debug.Log("Elegiste portal de dinosaurio");
        cont = 5;
    }
    public void PortalMonumento(){
        Debug.Log("Elegiste portal de Monumento");
        cont = 6;
    }
    public void PortalPegaso(){
        Debug.Log("Elegiste portal de Pegaso");
        cont = 7;
    }
}