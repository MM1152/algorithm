
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private GameData gameData;
    public GameObject outputBelt;
    public GameObject inputbelt;
    public GameObject canvas;
    public playerMove player;
    public GameObject GameEnd;
    public GameObject values;

    public Texture2D image;
    // Start is called before the first frame update
    void Awake()
    {
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
        values = GameObject.FindWithTag("Value").gameObject;
        inputbelt = GameObject.FindWithTag("InputBelt").gameObject;
        outputBelt = GameObject.FindWithTag("OutputBelt").gameObject;
        canvas = GameObject.FindWithTag("Canvas").gameObject;
        GameEnd = GameObject.FindWithTag("GameEnd").gameObject;
        GameEnd.SetActive(false);
        this.gameData = gameData;
        mainSecneSetting(this.gameData);
    }
    public GameData getGameData()
    {
        return gameData;
    }
    public void Finish()
    {
        GameEnd.SetActive(true);
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
}
