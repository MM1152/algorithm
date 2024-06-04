
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private GameData gameData;
    public GameDataManager gameDataManager;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene("IntroScene");
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        first_in = true;
        Cursor.SetCursor(image, Vector2.zero, CursorMode.Auto);
        Application.targetFrameRate = 120;

        if (GameObject.FindGameObjectsWithTag("GameManager").Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name.Equals("coustomScene"))
        {
            this.gameObject.SetActive(false);
        }
        else
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
        if (first_in && (gameDataManager.getCount() < gameDataManager.getMaxCount()))
        {
            first_in = false;
            Tutorial.SetActive(true);
        }

        this.gameData = gameData;
        mainSecneSetting(this.gameData);
    }
    public GameData getGameData()
    {
        return gameData;
    }
    public void Finish(bool isFail, string worngText)
    {
        if (isFail)
        {
            FailGui.SetActive(true);
            FailGui.transform.GetChild(0).Find("FailText").GetChild(0).GetComponent<Text>().text = worngText;
        }
        else
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
        for (int i = 0; i < gameData.codeData.Length; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(gameData.codeData[i]);
        }
        for(int i = 0; i < gameData.valueData; i++)
        {
            values.transform.GetChild(i).gameObject.SetActive(true);
        }
        _out.SetOutput(gameData.outputData);
        input.SettingBox();
    }

}