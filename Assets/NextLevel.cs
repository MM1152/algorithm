using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Content;
    public string Level;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Content = GameObject.FindWithTag("Content").gameObject;
        Level = gameManager.Level;
    }
    private void Start()
    {
        if (Level == "1")
        {
            gameManager.Level ="1_1";
        }
        else if (Level == "1_1")
        {
            gameManager.Level = "1_2";
        }
        else if(Level == "1_2")
        {
            gameManager.Level = "1_3";
        }
    }
    public void NextStage()
    {

        Debug.Log(gameManager.Level.Substring(Level.Length - 1));
        for(int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
            
        }
        if(gameManager.Level.Substring(Level.Length - 1) != "3")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else
        {
            SceneManager.LoadScene("StartScene");
        }
        
        
    }
}
