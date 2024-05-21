using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
public class GetGameData : MonoBehaviour
{
    public GameData gamedata;
    public PlayDatas playdata;
    public void GetData()
    {
        StartCoroutine(WebPost());
    }
    IEnumerator WebPost()
    {
        WWWForm form = new WWWForm();
        string id = gameObject.transform.parent.Find("ID").GetComponent<Text>().text;
        Debug.Log(id);
        form.AddField("Id", id);
        
        var url = "http://222.233.117.117:3000/PostData";
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            
            yield return request.SendWebRequest();
            playdata = JsonUtility.FromJson<PlayDatas>(request.downloadHandler.text);
            Debug.Log(request.downloadHandler.text);
            string[] inputdatas = playdata.results[0].input.Split(',');
            string[] outputdatas = playdata.results[0].output.Split(',');
            int value = playdata.results[0].value;
            gamedata.inputData.Clear();
            gamedata.outputData.Clear();
            foreach (var a in inputdatas)
            {
                gamedata.inputData.Add(int.Parse(a));
            }
            foreach(var a in outputdatas)
            {
                gamedata.outputData.Add(int.Parse(a));
            }
            gamedata.valueData = value;
            GameObject.Find("GameDataManager").GetComponent<GameDataManager>().setCustomGameData(gamedata);

            SceneManager.LoadScene("MainScene");
        }
    }
}
