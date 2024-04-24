using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameDataManager gameDataManager;
    private GameObject Content;
    private void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        Content = GameObject.FindWithTag("Content").gameObject;
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
}
