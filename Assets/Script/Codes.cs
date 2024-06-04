using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Codes : MonoBehaviour
{
    public CheckCode check;
    public playerMove player;
    public GameObject values;
    public string value;
    public bool isTrue;
    
    public abstract void checkCode();
    public abstract bool WaitTime();
    public void init()
    {
        check = GameObject.FindWithTag("CheckCode").gameObject.GetComponent<CheckCode>();
        player = GameObject.Find("Player").GetComponent<playerMove>();
        values = GameObject.FindWithTag("Value").gameObject;
        isTrue = false;
    }

}
