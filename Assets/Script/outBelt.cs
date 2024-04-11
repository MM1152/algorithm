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
    public BeltController beltController;
    private void Start()
    {
        
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        Level = gameManger.Level;
        beltController = gameObject.transform.Find("Belt").GetComponent<BeltController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        ChildCount = gameObject.transform.childCount;
        if(ChildCount > 1)
        {
            BoxCount = int.Parse(gameObject.transform.GetChild(ChildCount - 1).GetChild(0).GetChild(0).GetComponent<Text>().text);
        }
        if (gameObject.transform.childCount > 1 && gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.y >= -6f)
        {
            BoxMove();
        }
        else if (beltController.BeltAni[0].GetBool("IsBeltMove"))
        {
            beltController.BeltStop();
        }
    }
    private void FixedUpdate()
    {
        if (ChildCount != 0 && Level != "4")
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
    private void BoxMove()
    {
        beltController.BeltMove();
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.Translate(new Vector3(0f, -0.05f, 0f));
            
        }
        
    }
}
