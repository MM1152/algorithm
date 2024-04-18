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
        DontDestroyOnLoad(gameObject);
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        count = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
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
    }
    public int getCount()
    {
        return count;
    }
}
