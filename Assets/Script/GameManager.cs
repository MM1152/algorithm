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

    public int[] TEST_inputData;
    public int[] TEST_outputData;
    public int TEST_value;
    public bool[] TEST_codes;

    public int[] Custom_inputData;
    public int[] Custom_outputData;
    public int Custom_value;
    public bool[] Custom_codes;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
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

        if (SceneManager.GetActiveScene().name == "CustomScene" && firstIn)
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
        if (Level == "1")
        {
            Level1_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_outputData);
        }
        else if (Level == "1_1")
        {
            Level1_1_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_1_outputData);
        }
        else if (Level == "1_2")
        {
            Level1_2_Setting();
            outputBelt.GetComponent<outBelt>().SetOutput(Level1_2_outputData);
        }
        else if (Level == "4")
        {
            TESTSetting();
        }
        else if (Level == "5")
        {
            CustomSetting();
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
    public void TESTSetting()
    {
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        for (int i = 0; i < TEST_value; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < TEST_inputData.Length; i++)
        {
            input.boxNum.Add(TEST_inputData[i]);
        }
        for (int i = 0; i < TEST_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(TEST_codes[i]);
        }
    }
    
    public void CustomSetting()
    {
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        for(int i = 0; i < Custom_value; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i = 0; i < Custom_inputData.Length; i++)
        {
            input.boxNum.Add(Custom_inputData[i]);
        }
        for(int i = 0; i < Custom_codes.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(Custom_codes[i]);
        }
    }

    
    public void SetVariable(int index, int newValue)
    {
        // 배열에서 해당 인덱스의 변수를 변경합니다.
        Custom_inputData[index] = newValue;

        // 변경된 값을 확인하기 위해 콘솔에 출력합니다.
        Debug.Log("게임 매니저의 변수가 변경되었습니다. 인덱스: " + index + ", 새 값: " + newValue);
    }
}
