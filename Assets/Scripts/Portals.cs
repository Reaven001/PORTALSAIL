using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{

    public Transform Target;
    public GameObject ThePlayer;

    private void OnTriggerEnter(Collider other){
        ThePlayer.transform.position=Target.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
