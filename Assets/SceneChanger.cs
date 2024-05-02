using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private GameDataManager gameDataManager;
    private GameObject Content;
    [SerializeField] private GameObject titleinput;
    [SerializeField] private GameObject wrongText;
    private void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        Content = GameObject.FindWithTag("Content").gameObject;
        wrongText = gameObject.transform.Find("WorngText").gameObject;
        if(wrongText != null)
        {
            wrongText.SetActive(false);
        }
    }
    public void ChangeScene()
    {

        for (int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }

        gameDataManager.setCount();
        if (gameDataManager.getCount() >= gameDataManager.getMaxCount())
        {
            SceneManager.LoadScene("Custom");
            
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void PostData()
    {
        if (!titleinput.GetComponent<InputField>().text.Equals(""))
        {
            Debug.Log("����ƴ�");
            StartCoroutine(SaveData());
        }else
        {
            Debug.Log("����");
            wrongText.SetActive(true);
        }

        return;
    }
    IEnumerator SaveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("title", titleinput.GetComponent<InputField>().text);
        Debug.Log(gameData.inputData[0]);
        string input = "";
        for(int i = 0; i < gameData.inputData.Count; i++)
        {
            input += gameData.inputData[i].ToString();
            if (!(i == gameData.inputData.Count - 1))
            {
                 input += " ";
            }
            
        }
        form.AddField("input", input);
        input = "";
        for (int i = 0; i < gameData.outputData.Count; i++)
        {
            input += gameData.outputData[i].ToString();
            if (!(i == gameData.outputData.Count - 1))
            {
                input += " ";
            }
        }
        form.AddField("output", input);
        var url = "http://172.18.4.31:3000/insert";
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            SceneManager.LoadScene("Custom");
        }
    }
}
