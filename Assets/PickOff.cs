using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PickOff : Codes
{
    private GameObject outBelt;
    private void Awake()
    {
        init();
        outBelt = GameObject.Find("OutputBeltTrans").gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
        outBelt = GameObject.Find("OutputBeltTrans").gameObject;
    }
    private void LateUpdate()
    {
        if (isTrue)
        {
            player.Move(outBelt.transform);
        }

    }
    public override void checkCode()
    {
        isTrue = true;
        player.SetValueBox(outBelt);
    }

    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, outBelt.transform.position) < 0.25f)
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
