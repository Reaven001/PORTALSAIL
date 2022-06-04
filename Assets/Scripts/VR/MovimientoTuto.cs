using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovimientoTuto : MonoBehaviour {
    public static bool GameIsPaused = false;
    public static bool GameIsPaused2 = false;
    public GameObject pauseMenuUI;
    
    GameObject mainCamera;
    new Rigidbody rigidbody;
    new Camera camera;
    
    public GameObject portal;

    public Vector2 sensibility;

    //new Camera camera;
    
    public float lateralMove;
    int jumps = 1;
    [SerializeField] float jumpForce = 500;

    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;

    private bool movimiento = false, salto = false, disparo = false;
    
    public Image dip1, dip2, dip3;
    private int control = 1, saltos=0;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        
        mainCamera = GameObject.FindWithTag("MainCamera");
        //Pause();
    }

    
    void Update() {
        /*
        Movimiento del jugador con Joystick derecho
        Para el VR no funciona muy bien por el movimiento que posee la camara lo dejo en comentario
        */
        /*float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");
        
        if (hor != 0){
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }
        if (ver != 0){
            //camera.Rotate(Vector3.left * ver * sensibility.y);
            float angle = (camera.localEulerAngles.x + ver * sensibility.y + 360) % 360;
            if (angle >180){
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }
        //Fin movimiento del jugador
        */
        /*Move();
        if (Input.GetButtonDown("Jump"))
        {
            if (!GameIsPaused)
            {
                Jump();
            }
        }*/
        if (control == 1 || control == 3 || control == 5){
            Pause();
        }

        
            if (GameIsPaused)
            {
                Debug.Log("Juego Pausado");
                if (control == 1){
                    //Debug.Log("Control = " + control);
                    dip1.gameObject.SetActive(true);
                    dip2.gameObject.SetActive(false);
                    dip3.gameObject.SetActive(false);
                    
                    if (Input.GetButtonDown("Submit")) {
                        control++;
                    }
                }
                
                if (control == 3)
                {
                    //Debug.Log("Control = " + control);
                    dip1.gameObject.SetActive(false);
                    dip2.gameObject.SetActive(true);
                    dip3.gameObject.SetActive(false);
                    if (Input.GetButtonDown("Submit")) {
                        control++;
                    }
                    
                }
                
                if (control == 5)
                {
                    //Debug.Log("Control = " + control);
                    dip1.gameObject.SetActive(false);
                    dip2.gameObject.SetActive(false);
                    dip3.gameObject.SetActive(true);
                    if (Input.GetButtonDown("Submit")) {
                        control++;
                    }
                }
            }
        
        if (control == 2){
            tutorial1();
            //Debug.Log("Control = " + control);
            dip1.gameObject.SetActive(false);
        }
        if (control == 4)
        {
            //Debug.Log("Control = " + control);
            dip2.gameObject.SetActive(false);
            tutorial2();
        }
        if (control == 6)
        {
            //Debug.Log("Control = " + control);
            dip3.gameObject.SetActive(false);
            tutorial3();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            //Debug.Log("Control = " + control);
            Time.timeScale = 1f;
            SceneManager.LoadScene("VRPark");
        }
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            if (!GameIsPaused && !GameIsPaused2)
            {
                Jump();
            }
        }
        
    }

    void Resume(){
        //Debug.Log("Resume");
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Resume2(){
        //Debug.Log("Resume2");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused2 = false;
    }


    void Pause(){
        //Debug.Log("Pausa");
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void Pause2(){
        Debug.Log("Abrir menu portales");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused2 = true;
    }
    void Move(){
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
        if (transform.position.z != 0){
            movimiento = true;
        }
        
    }

    public void Jump() {
        if(jumps >= 1) {
           rigidbody.AddForce(Vector3.up * jumpForce);
           jumps--;
        }
        saltos++;
        if (saltos == 3){
            salto = true;
        }
    }
    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }

    void tutorial1() {
        Resume();
        Debug.Log("Entraste al tutorial 1");

        if (movimiento && salto){
            //Debug.Log("Te moviste");
            control = 3;
            Pause();
        }
        //control = 3;

    }
    void tutorial2() {
        //Resume();
        Debug.Log("Entraste al tutorial 2");
        if (Input.GetButtonDown("Menu")){
            //Pause();
            if (GameIsPaused2){
                Resume2();
            } else{
                Pause2();
            }
        }
        
        if (disparo){
            control = 5;
        }
    }
    void tutorial3() {
        Resume();
        Debug.Log("Entraste al tutorial 3");
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot Portal");
            throwPortal(portal);
        }
        //control = 7;
    }

    void throwPortal(GameObject portales)
    {
        Debug.Log("Portal disparado");
        // mainCamera.transform.rotation = new Quaternion(rotx, roty, rotz, rotw);
        portales.transform.rotation = mainCamera.transform.rotation;
        //   portales[num].transform.Rotate(mainCamera.transform.eulerAngles.x, portales[num].transform.eulerAngles.y  , mainCamera.transform.eulerAngles.z);
        portales.transform.Rotate(Vector3.up, Mathf.PI);

        //  Debug.Log(rot);
        //Debug.Log(portales[num].transform.eulerAngles);
        //Debug.Log(mainCamera.transform.eulerAngles);
        portales.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5.0f;
        
    }

    public void Portal(){
        Debug.Log("Elegiste un portal!");
        disparo = true;
        Resume2();
        //throwPortal(portal);
    }
}
