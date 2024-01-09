using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevel : MonoBehaviour
{
    public GameManager gameManager;

    public string check_Level;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        check_Level = gameManager.Level;
    }
    
}
