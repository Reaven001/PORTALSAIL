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
    public Image marcoInfo;


void Start(){
     marcoInfo.gameObject.SetActive(false);

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
    UnityWebRequest url=UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/6287323e09c70885c1c4e77c");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data["descripcion"]);

    infoText.text=data["descripcion"];
                           marcoInfo.gameObject.SetActive(true);
}
public IEnumerator consumirApiGod(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[4]["descripcion"]);

    infoText.text=data[4]["descripcion"];
    marcoInfo.gameObject.SetActive(true);
}
public IEnumerator consumirApiBuque(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[1]["descripcion"]);

    infoText.text=data[1]["descripcion"];
    marcoInfo.gameObject.SetActive(true);
}
public IEnumerator consumirApiBarco(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[2]["descripcion"]);

    infoText.text=data[2]["descripcion"];
    marcoInfo.gameObject.SetActive(true);
}
public IEnumerator consumirApiAvion(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/lugares");
    yield return url.SendWebRequest();
    // Debug.Log(url.downloadHandler.text);
    JSONNode data=JSON.Parse(url.downloadHandler.text);
    Debug.Log(data[3]["descripcion"]);
marcoInfo.gameObject.SetActive(true);
    infoText.text=data[3]["descripcion"];
    marcoInfo.gameObject.SetActive(true);
    
}
void Update(){
    
    
    
}
    // Update is called once per frame
  
}
