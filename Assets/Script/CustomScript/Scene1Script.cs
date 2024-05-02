using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    [SerializeField]
    private GameData gamedata;
    private GameDataManager gameDataManager;

    [SerializeField] private GameObject inputData;
    [SerializeField] private GameObject outputData;


    private void Start()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();

    }

    public void setData()
    {
        gamedata.inputData.Clear();
        gamedata.outputData.Clear();
        for (int i = 0; i < inputData.transform.childCount; i++)
        {
            gamedata.inputData.Add(int.Parse(inputData.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<InputField>().text));
        }
        for (int i = 0; i < outputData.transform.childCount; i++)
        {
            gamedata.outputData.Add(int.Parse(outputData.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<InputField>().text));
        }
        gameDataManager.setCustomGameData(gamedata);
        SceneManager.LoadScene("NewMainScene");
    }
}

