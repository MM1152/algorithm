using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject outputBelt;
    public GameObject inputbelt;
    public GameObject canvas;
    public playerMove player;
    public GameObject GameEnd;
    public GameObject values;

    public string Level;
    public bool firstIn;

    public int[] Level1_inputData;
    public int[] Level1_outputData;
    public int Level1_value;
    public bool[] Level1_codes;

    public int[] Level1_1_inputData;
    public int[] Level1_1_outputData;
    public int Level1_1_value;
    public bool[] Level1_1_codes;

    public int[] Level1_2_inputData;
    public int[] Level1_2_outputData;
    public int Level1_2_value;
    public bool[] Level1_2_codes;
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
        values = GameObject.FindWithTag("Value").gameObject;
        inputbelt = GameObject.FindWithTag("InputBelt").gameObject;
        outputBelt = GameObject.FindWithTag("OutputBelt").gameObject;
        canvas = GameObject.FindWithTag("Canvas").gameObject;
        GameEnd = GameObject.FindWithTag("GameEnd").gameObject;
        GameEnd.SetActive(false);
        if(Level == "1")
        {
            Level1_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_outputData);
        }
        else if(Level == "1_1")
        {
            Level1_1_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_1_outputData);
        }
        else if(Level == "1_2")
        {
            Level1_2_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_2_outputData);
        }
       
        
    }
    
    public void Finish()
    {
        GameEnd.SetActive(true);
    }
    public void Level1_Setting()
    {
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        for (int i = 0; i < Level1_value; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < Level1_inputData.Length; i++)
        {
            input.boxNum.Add(Level1_inputData[i]);
        }
        for(int i = 0; i < Level1_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(Level1_codes[i]);
        }
        
    }
    public void Level1_1_Setting()
    {
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        for (int i = 0; i < Level1_1_value; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < Level1_1_inputData.Length; i++)
        {
            input.boxNum.Add(Level1_1_inputData[i]);
        }
        for (int i = 0; i < Level1_1_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(Level1_1_codes[i]);
        }
       
    }
    public void Level1_2_Setting()
    {
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        for (int i = 0; i < Level1_2_value; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < Level1_2_inputData.Length; i++)
        {
            input.boxNum.Add(Level1_2_inputData[i]);
        }
        for (int i = 0; i < Level1_2_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(Level1_2_codes[i]);
        }
        
    }
}
