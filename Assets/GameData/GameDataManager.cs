using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public GameData[] gameData;
    [SerializeField]
    private GameManager gameManger;
    [SerializeField]
    private int count;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        count = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
        gameManger.setGameData(gameData[count]);
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
