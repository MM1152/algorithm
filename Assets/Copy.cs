using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Copy : Codes
{
    private void Awake()
    {
        init();
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
    }
    private void LateUpdate()
    {
        if (isTrue)
        {
            player.Move(check.target);
        }
        
    }
    public override void checkCode()
    {
        value = this.gameObject.transform.Find("Copy Value").transform.Find("ValueName").GetComponent<Text>().text[0];
        isTrue = true;
        player.SetValueBox(GameObject.Find(value.ToString()).gameObject);
    }

    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, player.valueBox.transform.position) < 0.25f)
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
    