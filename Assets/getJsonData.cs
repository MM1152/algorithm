using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
public class getJsonData : MonoBehaviour
{
    private Data zipData;
    public GameObject scenePrefeb;
    public Transform Canvas;
    public SetContentSize content;
    private void Awake()
    {

        StartCoroutine(GetRequest("http://222.233.117.117:3000/cccc"));
    }
    IEnumerator GetRequest(string url)
    {
        
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success && request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);
                zipData = JsonUtility.FromJson<Data>(request.downloadHandler.text);
                

                for(int i = 0; i < zipData.results.Length; i++)
                {
                    GameObject prefeb = Instantiate(scenePrefeb, Canvas) as GameObject;
                    Debug.Log(zipData.results[i].created_date);
                    prefeb.transform.Find("CreateDay").GetComponent<Text>().text = zipData.results[i].created_date;
                    prefeb.transform.Find("Title").GetComponent<Text>().text = zipData.results[i].title;
                    prefeb.transform.Find("ID").GetComponent<Text>().text = zipData.results[i].id.ToString();
                }
                content.SettingBackGround();
            }
            else
            {
                StartCoroutine(GetRequest("http://222.233.117.117:3000/cccc"));
            }
            
        }
    }
}
