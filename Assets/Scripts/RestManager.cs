using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class RestManager : MonoBehaviour
{
    public static RestManager instance;
    // public string textValue;
    public Text infoText;


void Start(){
// infoText.text="vacio";
    }
    public void trearDatosTajMahal(){
        StartCoroutine(consumirApiTaj());
    }
    public void trearDatosGod(){
        StartCoroutine(consumirApiGod());
    }
    public void traerDatosBuque(){
        StartCoroutine(consumirApiBuque());
    }
    public void traerDatosBarco(){
        StartCoroutine(consumirApiBarco());
    }
    public void traerDatosAvion(){
        StartCoroutine(consumirApiAvion());
    }
     public IEnumerator consumirApiTaj(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[0]["descripcion"]);

    infoText.text=data[0]["descripcion"];
}
public IEnumerator consumirApiGod(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[4]["descripcion"]);

    infoText.text=data[4]["descripcion"];
}
public IEnumerator consumirApiBuque(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[1]["descripcion"]);

    infoText.text=data[1]["descripcion"];
}
public IEnumerator consumirApiBarco(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[2]["descripcion"]);

    infoText.text=data[2]["descripcion"];
}
public IEnumerator consumirApiAvion(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[3]["descripcion"]);

    infoText.text=data[3]["descripcion"];
}
void Update(){
    
}
    // Update is called once per frame
  
}
