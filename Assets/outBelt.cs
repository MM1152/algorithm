using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class outBelt : MonoBehaviour
{
    public GameManager gameManger;
    public GameObject Sussecs;
    private void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount != 0)
        {
            if (int.Parse(gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetChild(0).GetChild(0).GetComponent<Text>().text) != gameManger.Level1_outputData[gameObject.transform.childCount - 1])
            {
                Time.timeScale = 0;
            }
        }
    }

    public void Finish()
    {
        Sussecs.SetActive(true);
    }
}
