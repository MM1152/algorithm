using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private GameDataManager gameDataManager;
    private GameObject Content;
    [SerializeField]
    private GameObject titleinput;
    private GameObject wrongText;
    private void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        Content = GameObject.FindWithTag("Content").gameObject;
        wrongText = gameObject.transform.Find("WrongText").gameObject;
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

        }else
        {
            wrongText.SetActive(true);
        }

        return;
    }
}
