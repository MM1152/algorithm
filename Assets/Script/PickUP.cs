using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : Codes
{
    private GameObject inputBelt;
    private bool animationEnd;
    private void Awake()
    {
        init();
        animationEnd = false;
        inputBelt = GameObject.Find("InputBeltTrans").gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
        animationEnd = false;
        inputBelt = GameObject.Find("InputBeltTrans").gameObject;
    }
    private void LateUpdate()
    {
        if (isTrue)
        {
            player.Move(inputBelt.transform);
        }
    }
    public override void checkCode()
    {
        isTrue = true;
        player.SetValueBox(inputBelt);
    }
    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, inputBelt.transform.position) < 0.25f)
        {
            isTrue = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
