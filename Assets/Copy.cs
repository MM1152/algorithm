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
    public override void checkCode()
    {
        value = this.gameObject.transform.Find("Copy Value").transform.Find("ValueName").GetComponent<Text>().text[0];
        isTrue = true;
        player.SetValueBox(GameObject.Find(value.ToString()).gameObject);
        player.Move(check.target);
    }

    public T getComponent<T>()
    {
        
    }
}
    