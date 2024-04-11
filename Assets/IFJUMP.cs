using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IFJUMP : Jump
{
    private Dictionary<string, int> jumps;
    private InputField startInput;
    private InputField endInput;
    private int setJumpCount;
    private int endJumpCount;
    public int count;
    private void Awake()
    {
        init();
        startInput = gameObject.transform.Find("Input").GetComponent<InputField>();
        endInput = gameObject.transform.Find("Input (1)").GetComponent<InputField>();
        jumps = new Dictionary<string, int>();
        setJumpCount = -1;
        endJumpCount = -1;
        count = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
        startInput = gameObject.transform.Find("Input").GetComponent<InputField>();
        endInput = gameObject.transform.Find("Input (1)").GetComponent<InputField>();
        jumps = new Dictionary<string, int>();
        if(setJumpCount != -1 && endJumpCount != -1)
        {
            startInput.text = setJumpCount.ToString();
            endInput.text = endJumpCount.ToString();
            count = setJumpCount;
        }
    }

    
    public override void checkCode()
    {
        
        if (startInput.text != null && endInput.text != null)
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
    public void removejumps()
    {
        jumps.Clear();
    }
    
}
