using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Codes : MonoBehaviour
{
    public CheckCode check;
    public playerMove player;
    public char value { get; set; }
    public bool isTrue { get; set; }
    public abstract void checkCode();

    public void init()
    {
        check = GameObject.FindWithTag("CheckCode").gameObject.GetComponent<CheckCode>();
        player = GameObject.Find("Player").GetComponent<playerMove>();
    }
    
}
