
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private GameData gameData;
    public GameObject outputBelt;
    public GameObject inputbelt;
    public GameObject canvas;
    public playerMove player;
    public GameObject GameEnd;
    public GameObject values;
    [SerializeField]
    private GameObject FailGui;
    private GameObject Tutorial;
    [SerializeField]
    public bool first_in;

    public Texture2D image;

    // Start is called before the first frame update
    void Awake()
    {
        first_in = true;
        Cursor.SetCursor(image, Vector2.zero , CursorMode.Auto);
        Application.targetFrameRate = 120;

        if (GameObject.FindGameObjectsWithTag("GameManager").Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name.Equals("coustomScene"))
        {
            this.gameObject.SetActive(false);
        }else
        {
            this.gameObject.SetActive(true);
        }
    }
    public void setGameData(GameData gameData)
    {
        
        FailGui = GameObject.FindWithTag("FailGui").gameObject;
        Tutorial = GameObject.FindWithTag("Tutorial").gameObject;
        values = GameObject.FindWithTag("Value").gameObject;
        inputbelt = GameObject.FindWithTag("InputBelt").gameObject;
        outputBelt = GameObject.FindWithTag("OutputBelt").gameObject;
        canvas = GameObject.FindWithTag("Canvas").gameObject;
        GameEnd = GameObject.FindWithTag("GameEnd").gameObject;
        Tutorial.SetActive(false);
        GameEnd.SetActive(false);
        FailGui.SetActive(false);
        if (first_in)
        {
            first_in = false;
            Tutorial.SetActive(true);
        }
        
        this.gameData = gameData;
        mainSecneSetting(this.gameData);
        ProcessLists(gameData.inputData, gameData.outputData);
    }
    public GameData getGameData()
    {
        return gameData;
    }
    public void Finish(bool isFail , string worngText)
    {
        if (isFail)
        {
            FailGui.SetActive(true);
            FailGui.transform.GetChild(0).Find("FailText").GetChild(0).GetComponent<Text>().text = worngText;
        } else
        {
            GameEnd.SetActive(true);
        }
         Time.timeScale = 0;
    }
    public void mainSecneSetting(GameData gameData)
    { 
        inputBelt input = inputbelt.GetComponent<inputBelt>();
        outBelt _out = outputBelt.GetComponent<outBelt>();
        for (int i = 0; i < gameData.inputData.Count; i++)
        {
            input.boxNum.Add(gameData.inputData[i]);
        }
        for(int i = 0; i < gameData.codeData.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(gameData.codeData[i]);
        }
        _out.SetOutput(gameData.outputData);
        input.SettingBox();
    }

    public void ProcessLists(List<int> inputList, List<int> outputList)
    {
        // Scene2에서 받아온 리스트들을 처리하는 작업을 여기에 추가하면 됩니다.
        // 예를 들어, 리스트의 각 요소들을 콘솔에 출력하거나 다른 오브젝트에 추가하는 등의 작업을 할 수 있습니다.
        Debug.Log("Received input list:");
        foreach (int number in inputList)
        {
            Debug.Log(number);
            // gameData에 inputList의 요소를 추가
            gameData.inputData.Add(number);
        }

        Debug.Log("Received output list:");
        foreach (int number in outputList)
        {
            Debug.Log(number);
            // gameData에 outputList의 요소를 추가
            gameData.outputData.Add(number);
        }

        // 여기에는 받아온 리스트들을 오브젝트에 추가하는 등의 작업을 추가할 수 있습니다.
    }

    public List<int> GetInputNumbersList()
    {
        if (gameData != null)
        {
            return gameData.inputData;
        }
        else
        {
            return new List<int>();
        }
    }

    public List<int> GetOutputNumbersList()
    {
        if (gameData != null)
        {
            return gameData.outputData;
        }
        else
        {
            return new List<int>();
        }
    }
}
