using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class outBelt : MonoBehaviour
{
    public GameManager gameManger;
    public string Level;
    public int ChildCount;
    public int BoxCount;
    public int SetOutputDataLength;
    public int[] SetOutputData;
 
    private void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        Level = gameManger.Level;
    }
    
    // Update is called once per frame
    void Update()
    {
        ChildCount = gameObject.transform.childCount;
        if(ChildCount != 0)
        {
            BoxCount = int.Parse(gameObject.transform.GetChild(ChildCount - 1).GetChild(0).GetChild(0).GetComponent<Text>().text);
        }
        
        
    }
    private void FixedUpdate()
    {
        if (ChildCount != 0)
        {
        
                if (BoxCount != gameManger.Level1_outputData[ChildCount - 1])
                {
                    Time.timeScale = 0;
                }
                else if (ChildCount == SetOutputDataLength)
                {
                    gameManger.Finish();
                }



        }
    }
    public void SetOutput(int[] outPutData)
    {
        SetOutputData = outPutData;
        SetOutputDataLength = outPutData.Length;
    }
}
