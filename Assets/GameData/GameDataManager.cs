using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public GameData[] tutorialData;
    [SerializeField]
    private GameData customGameData;
    [SerializeField]
    private GameManager gameManger;
    [SerializeField]
    private int count;
    [SerializeField]
    private int maxCount;
   
    private void Awake()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxCount = tutorialData.Length;
        if(GameObject.FindObjectsOfType<GameDataManager>().Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        count = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            count = 0;
        }

        if(count < maxCount)
        {
            gameManger.setGameData(tutorialData[count]);
            
        }else
        {
            gameManger.setGameData(customGameData);
        }
        
    }
    
    public void setCustomGameData(GameData gameData)
    {
        this.customGameData = gameData;
    }
    public void setCount()
    {
        count++;
        gameManger.first_in = true;
    }
    public int getCount()
    {
        return count;
    }
    public int getMaxCount()
    {
        return maxCount;
    }
}
