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
    public void traerDatosPegaso()
    {
        StartCoroutine(consumirApiMonumentoPegaso());
    }
    public void traerDatosMonumentoNacional()
    {
        StartCoroutine(consumirApiMonumentoNacional());
    }
    public void traerDatosDinosaurios()
    {
        StartCoroutine(consumirApiDinosaurios());
    }
    public void traerDatosHivernadero()
    {
        StartCoroutine(consumirApiHivernadero());
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
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/6287328909c70885c1c4e780");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);
    }
public IEnumerator consumirApiBuque(){
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a4dd6196b10eacb6e43af");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);
    }
public IEnumerator consumirApiBarco(){
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a4f4e196b10eacb6e43b3");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);
    }
public IEnumerator consumirApiAvion(){
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/6287331609c70885c1c4e784");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);

    }
    public IEnumerator consumirApiMonumentoNacional()
    {
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a5053196b10eacb6e43b7");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);

    }
    public IEnumerator consumirApiMonumentoPegaso()
    {
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a50ec196b10eacb6e43bb");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);

    }
    public IEnumerator consumirApiDinosaurios()
    {
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a514e196b10eacb6e43bf");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);

    }
    public IEnumerator consumirApiHivernadero()
    {
        // infoText.text="Cargando...";
        UnityWebRequest url = UnityWebRequest.Get("https://restserver-portalsail.herokuapp.com/api/lugares/629a51a3196b10eacb6e43c3");
        yield return url.SendWebRequest();
        // Debug.Log(url.downloadHandler.text);
        JSONNode data = JSON.Parse(url.downloadHandler.text);
        Debug.Log(data["descripcion"]);

        infoText.text = data["descripcion"];
        marcoInfo.gameObject.SetActive(true);

    }
    void Update(){
    
    
    
}
    // Update is called once per frame
  
}
