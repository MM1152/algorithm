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
            player.Move(player.valueBox.transform);
        }
        
    }
    public override void checkCode()
    {
        
        value = this.gameObject.transform.Find("Copy Value").Find("ValuesName").GetComponent<Text>().text;
        isTrue = true;
        player.setIsCopy(true);
        player.SetValueBox(values.transform.Find(value.ToString()).gameObject);
    }
    
    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, player.valueBox.transform.position) < 0.2f)
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
    