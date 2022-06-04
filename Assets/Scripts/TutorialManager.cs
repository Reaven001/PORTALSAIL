using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    new Rigidbody rigidbody;
    new Camera camera;

    public Vector2 sensibility;

    //new Camera camera;
    
    public float lateralMove;
    int jumps = 1;
    [SerializeField] float jumpForce = 500;

    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;

    private bool movimiento = false, salto = false, disparo = false, tuto1 = false;
    
    public Image dip1, dip2, dip3;
    private int control = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        //Pause();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Submit")) {
            if (GameIsPaused)
            {
                control++;
                if (control == 1){
                    Debug.Log("Control = " + control);
                    dip1.gameObject.SetActive(true);
                    dip2.gameObject.SetActive(false);
                    dip3.gameObject.SetActive(false);
                }
                if (control == 2){

                    Debug.Log("Control = " + control);
                    dip1.gameObject.SetActive(false);
                    tutorial1();
                }
                if (control == 3)
                {
                    Debug.Log("Control = " + control);
                    Time.timeScale = 0f;
                    dip1.gameObject.SetActive(false);
                    dip2.gameObject.SetActive(true);
                    dip3.gameObject.SetActive(false);
                }
                if (control == 4)
                {
                    Debug.Log("Control = " + control);
                    dip2.gameObject.SetActive(false);
                    tutorial2();
                }
                if (control == 5)
                {
                    Debug.Log("Control = " + control);
                    Time.timeScale = 0f;
                    dip1.gameObject.SetActive(false);
                    dip2.gameObject.SetActive(false);
                    dip3.gameObject.SetActive(true);
                }
                if (control == 6)
                {
                    Debug.Log("Control = " + control);
                    dip3.gameObject.SetActive(false);
                    tutorial3();
                }
                if (control == 7)
                {
                    Debug.Log("Control = " + control);
                    Time.timeScale = 1f;
                    SceneManager.LoadScene("VRPark");
                }
                if (Input.GetButtonDown("Cancel"))
                {
                    Debug.Log("Control = " + control);
                    Time.timeScale = 1f;
                    SceneManager.LoadScene("VRPark");
                }
            }
        }*/
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            if (!GameIsPaused)
            {
                Jump();
            }
        }
    }

    

    void Move(){
        /*lateralMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * lateralMove * Time.deltaTime * walkSpeed);*/

        Vector3 velocity = GetComponent<Camera>().transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        transform.position += velocity * Time.deltaTime;

        if (Input.GetButton("Sprint")){
            velocity = GetComponent<Camera>().transform.forward * Input.GetAxis("Vertical") * runSpeed;
            transform.position += velocity * Time.deltaTime;
        }
        else{
            velocity = GetComponent<Camera>().transform.forward * Input.GetAxis("Vertical") * walkSpeed;
            transform.position += velocity * Time.deltaTime;
        }
        movimiento = true;
    }
    void Resume(){
        Debug.Log("Resume");
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        Debug.Log("Pausa");
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Jump() {
        if(jumps >= 1) {
           GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
           jumps--;
        }
        salto = true;
    }
    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }

    void tutorial1() {
        Resume();
        Debug.Log("Entraste al tutorial 1");
        Move();
        Jump();
        if (movimiento && salto){
            control = 3;
        }
    }
    void tutorial2() {
        Resume();
        Debug.Log("Entraste al tutorial 2");
    }
    void tutorial3() {
        Resume();
        Debug.Log("Entraste al tutorial 3");
    }
}
