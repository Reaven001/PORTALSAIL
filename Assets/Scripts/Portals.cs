using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{

    public Transform Target;
    public GameObject ThePlayer;
    public GameObject portal; 
    private Vector3 initPortal;
    private void OnTriggerEnter(Collider other){
        ThePlayer.transform.position=Target.transform.position;
        ThePlayer.transform.rotation=Target.transform.rotation;
        //ortales[num].transform.Rotate(mainCamera.transform.eulerAngles.x, portales[num].transform.eulerAngles.y  , mainCamera.transform.eulerAngles.z);
        //ThePlayer.transform.Rotate(ThePlayer.transform.eulerAngles.x, Target.transform.eulerAngles.y, ThePlayer.transform.eulerAngles.x );
        portal.transform.position = initPortal;
    }
    // Start is called before the first frame update
    void Start()
    {
        initPortal = portal.transform.position;
        //Debug.Log("Posicion inicial portal " + initPortal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
