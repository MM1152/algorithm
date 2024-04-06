using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class EndPoint : Codes
{
    private inputBelt inputbelt;
    [SerializeField]
    private Jump jumps;

    private Component component;
    private GameObject parent;
    private void Awake()
    {
        inputbelt = GameObject.Find("InputBelt").GetComponent<inputBelt>();
        init(); 
    }
    private void OnLevelWasLoaded(int level)
    {
        inputbelt = GameObject.Find("InputBelt").GetComponent<inputBelt>();
        init();
        Debug.Log(this.GetType());
    }
    public void SetParent(GameObject code , Type type)
    {
        jumps = code.GetComponent(type) as Jump;
    }
    public override void checkCode()
    {
        if (check.code.name.Substring(0, 2).Equals("ju") && check.Count < inputbelt.boxNum.Count)
        {
            check.Seti(jumps.getData());
        }
        if(check.code.name.Substring(0, 2).Equals("IF") && (jumps.GetComponent<IFJUMP>().count < jumps.GetComponent<IFJUMP>().getEndJumpCount()))
        {
            IFJUMP ifJump = jumps.GetComponent<IFJUMP>();
            ifJump.count++;
            ifJump.transform.Find("Input").GetComponent<InputField>().text = ifJump.count.ToString();
            check.Seti(jumps.GetComponent<IFJUMP>().getData());
        }else if(check.code.name.Substring(0, 2).Equals("IF"))
        {
            IFJUMP ifJump = jumps.GetComponent<IFJUMP>();
            ifJump.count = ifJump.getSetJumpCount();
            ifJump.transform.Find("Input").GetComponent<InputField>().text = ifJump.count.ToString();
            ifJump.removejumps();
        }
        
    }

    public override bool WaitTime()
    {
        return true;
    }



}
