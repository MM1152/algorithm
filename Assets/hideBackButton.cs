using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hideBackButton : MonoBehaviour
{
    private GameDataManager gameDataManager;
    // Start is called before the first frame update
    void Start()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        if(gameDataManager.getCount() < gameDataManager.getMaxCount())
        {
            this.gameObject.SetActive(false);
        }   
    }


}
