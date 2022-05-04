using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RestManager : MonoBehaviour
{
    public static RestManager instance;
    public string textValue;
    public Text infoText;


void Start(){
StartCoroutine(consumirApi());
    }
     public IEnumerator consumirApi(){
    // infoText.text="Cargando...";
    UnityWebRequest url=UnityWebRequest.Get("https://apimocha.com/portalsail/prueba1");
    yield return url.SendWebRequest();
    Debug.Log(url.downloadHandler.text);
    infoText.text=url.downloadHandler.text;
}
void Update(){
    // infoText.text=textValue;
}
    // Update is called once per frame
  
}
