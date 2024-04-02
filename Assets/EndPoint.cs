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
        Debug.Log($"{jumps.GetComponent<IFJUMP>().count} {jumps.GetComponent<IFJUMP>().getEndJumpCount()}");
        if (check.code.name.Substring(0, 2).Equals("ju") && check.Count < inputbelt.boxNum.Count)
        {
            check.Seti(jumps.getData());
        }if(check.code.name.Substring(0, 2).Equals("IF") && (jumps.GetComponent<IFJUMP>().count < jumps.GetComponent<IFJUMP>().getEndJumpCount()))
        {
           //($"{jumps.GetComponent<IFJUMP>().count} À±Áö¼ö ¹Ùº¸");
            IFJUMP ifJump = jumps.GetComponent<IFJUMP>();
            ifJump.count++;
            ifJump.transform.Find("Input").GetComponent<InputField>().text = ifJump.count.ToString();
            check.Seti(jumps.GetComponent<IFJUMP>().getData());
        }else
        {
            IFJUMP ifJump = jumps.GetComponent<IFJUMP>();
            ifJump.count = ifJump.getSetJumpCount();
        }
        
    }

    public override bool WaitTime()
    {
        return true;
    }



}
