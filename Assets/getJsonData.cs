using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class getJsonData : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(GetRequest("http://222.233.117.117:3000/data.json"));
    }
    IEnumerator GetRequest(string url)
    {
        
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success && request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);
                ZIP zip = JsonUtility.FromJson<ZIP>(request.downloadHandler.text);
                Debug.Log(zip.NAME);
            }
            else
            {
                Debug.Log(request.error);
            }
            
        }
    }
}
