using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public inputBelt inputbelt;
    public GameObject canvas;

    public string Level;
    public bool firstIn;

    public int[] Level1_inputData;
    public int[] Level1_outputData;
    public bool[] Level1_codes;
    // Start is called before the first frame update
    void Awake()
    {
        firstIn = true;
        if (GameObject.FindGameObjectsWithTag("GameManager").Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && firstIn)
        {
            
            firstIn = false;
        }

    }
    private void OnLevelWasLoaded(int level)
    {
        inputbelt = GameObject.FindWithTag("InputBelt").GetComponent<inputBelt>();
        canvas = GameObject.FindWithTag("Canvas").gameObject;
        if(Level == "1")
        {
            Level1_Setting();
        }
    }
    public void Level1_Setting()
    {
        for(int i = 0; i < Level1_inputData.Length; i++)
        {
            inputbelt.boxNum.Add(Level1_inputData[i]);
        }
        for(int i = 0; i < Level1_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(Level1_codes[i]);
        }
    }
}
