using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Codes
{
    private Dictionary<string, int> jumps;

    private void Awake()
    {
        init();
        jumps = new Dictionary<string, int>();

    }
    private void OnLevelWasLoaded(int level)
    {
        init();
        jumps = new Dictionary<string, int>();

    }
    public override void checkCode()
    {
        jumps.Add(this.gameObject.name, check.i);
    }
    public override bool WaitTime()
    {
        return true;
    }
    public int getData()
    {
        return jumps[this.gameObject.name];
    }
}
