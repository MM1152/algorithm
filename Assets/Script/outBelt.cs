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
    public List<int> SetOutputData;
    public BeltController beltController;
    private void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        beltController = gameObject.transform.Find("Belt").GetComponent<BeltController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        ChildCount = gameObject.transform.childCount;
        if(ChildCount > 1)
        {
            BoxCount = int.Parse(gameObject.transform.GetChild(ChildCount - 1).GetChild(0).GetChild(0).GetComponent<Text>().text);
            if(BoxCount != SetOutputData[ChildCount - 2])
            { 
                Time.timeScale = 0f;
                gameManger.Finish(true , "제가 원하는 정답이 아니에요 !");
            }

            else if(ChildCount - 1 == SetOutputDataLength)
            {
                Time.timeScale = 0f;
                gameManger.Finish(false , null);
            }
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
    public void CheckCodeEnd()
    {
        if(ChildCount - 1 == 0  || (ChildCount - 1 >= 1 && SetOutputDataLength > ChildCount - 1))
        {
            gameManger.Finish(true , "원하는 정답이 아니에요!");
        }
        
    }
    public void SetOutput(List<int> outPutData)
    {
        SetOutputData = outPutData;
        SetOutputDataLength = outPutData.Count;
    }
    private void BoxMove()
    {
        beltController.BeltMove();
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.Translate(new Vector3(0f, -0.01f, 0f));
        }
        
    }
}
