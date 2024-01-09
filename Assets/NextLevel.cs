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
    }
    public void NextStage()
    {
        
        for(int i = 0; i < Content.transform.childCount; i++)
        {
            Debug.Log($"{Content.transform.GetChild(0).gameObject.name}");
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
