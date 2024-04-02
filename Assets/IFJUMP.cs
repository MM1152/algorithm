using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IFJUMP : Jump
{
    private Dictionary<string, int> jumps;
    private int setJumpCount;
    private int endJumpCount;
    public int count;
    private void Awake()
    {
        init();
        jumps = new Dictionary<string, int>();
        setJumpCount = -1;
        endJumpCount = -1;
        count = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
    
        jumps = new Dictionary<string, int>();
        if(setJumpCount != -1 && endJumpCount != -1)
        {
            gameObject.transform.Find("Input").GetComponent<InputField>().text = setJumpCount.ToString();
            gameObject.transform.Find("Input (1)").GetComponent<InputField>().text = endJumpCount.ToString();
            count = setJumpCount;
        }
    }

    
    public override void checkCode()
    {
        
        if (setJumpCount == -1 && endJumpCount == -1)
        {
            setJumpCount = int.Parse(gameObject.transform.Find("Input").GetComponent<InputField>().text);
            endJumpCount = int.Parse(gameObject.transform.Find("Input (1)").GetComponent<InputField>().text);
            if(count == 0)
            {
                count = setJumpCount;
            }
        }

        jumps.Add(this.gameObject.name, check.i);
    }

    public override bool WaitTime()
    {
        
        return true; 
    }
    public new int getData()
    {
        return jumps[this.gameObject.name];
    }
    public int getSetJumpCount()
    {
        return setJumpCount;
    }
    public int getEndJumpCount()
    {
        return endJumpCount;
    }
    
}
