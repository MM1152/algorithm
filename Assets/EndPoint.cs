using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : Codes
{
    private inputBelt inputbelt;
    private Jump jumps;
    private GameObject parent;
    private void Awake()
    {
        inputbelt = GameObject.Find("InputBelt").GetComponent<inputBelt>();
        parent = GameObject.Find(this.gameObject.name);
        jumps = parent.GetComponent<Jump>();
        init(); 
    }
    private void OnLevelWasLoaded(int level)
    {
        inputbelt = GameObject.Find("InputBelt").GetComponent<inputBelt>();
        parent = GameObject.Find(this.gameObject.name);
        jumps = parent.GetComponent<Jump>();
        init();
    }

    public override void checkCode()
    {
        if(check.Count < inputbelt.boxNum.Count) 
        {
            check.Seti(jumps.getData());
        }

    }

    public override bool WaitTime()
    {
        return true;
    }



}
