using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {
    public Transform cam;
    public GameObject Portal;
    GameObject mainCamera;
    public GameObject[] portales;
    private int cont = 0;

    float vMouse;
    float hMouse;
    float yReal = 0.0f;
    public float horizontalSpeed;
    public float verticalSpeed;
    new Rigidbody rigidbody;
    new Camera camera;

    int jumps = 1;
    [SerializeField] float speed = 6, jumpForce = 500;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    
    void Update() {
        float horizontal = Input.GetAxis("Horizontal"); // A D alrededor
        float vertical = Input.GetAxis("Vertical"); // W S arriba y abajo

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime); // W S arriba y abajo
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime); // A D alrededor

        LookMouse();
        //Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
        //transform.position += velocity * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot Portal");
            throwPortal(portales, cont);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Cambiaste portal");
            cont += 1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown("j"))
        {
            Run();
        }
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
}