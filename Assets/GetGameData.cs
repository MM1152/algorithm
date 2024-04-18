using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;
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
        form.AddField("Id", 1);
        var url = "http://172.18.4.31:3000/PostData";
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            
            yield return request.SendWebRequest();
            playdata = JsonUtility.FromJson<PlayDatas>(request.downloadHandler.text);
            string[] inputdatas = playdata.results[0].input.Split(',');
            string[] outputdatas = playdata.results[0].output.Split(',');
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
            GameObject.Find("GameDataManager").GetComponent<GameDataManager>().setCustomGameData(gamedata);

            SceneManager.LoadScene("MainScene");
        }
    }
}
