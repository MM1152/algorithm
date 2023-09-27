using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class CheckCode : MonoBehaviour
{
    Dictionary<string, int> check;
    
    public static bool CodeRunning;
    public Transform inputBelt;
    public Transform outBelt;
    public Transform[] Values;
    public Transform target;

    public List<GameObject> list;
    public GameObject code;
    public GameObject Lay;
    public playerMove player;
    public int count;
    public char copyValue;
    public bool IsCopy;

    public WaitForSeconds wait;
    public GameObject value;
    private void Start()
    {
        IsCopy = false;
    }
    public void checkCode()
    {
        wait = new WaitForSeconds(2f);
        check = new Dictionary<string, int>();
        list = new List<GameObject>();
        for (int i = 0; i < Lay.transform.childCount; i++)
        {
            list.Add(Lay.gameObject.transform.GetChild(i).gameObject);
        }
        list.Reverse();
        CodeRunning = true;
        StartCoroutine(Run());
    }

    private void Update()
    {
        if(code != null)
        {
            wait = new WaitForSeconds(2f);
            if (code.name == "Pick up(Clone)")
            {
                player.Move(inputBelt);
                
            }
            if (code.name == "Pick off(Clone)")
            {
                player.Move(outBelt);
            }
            if(code.name == "Copy(Clone)")
            {
                IsCopy = true;
                if (copyValue == 'A')
                {
                    player.Move(Values[0]);
                }
            }
        }

    }

    IEnumerator Run()
    {
        for(int i = 0; i < Lay.transform.childCount; i++)
        {

            code = list[i];
            if(code.name == "Pick up(Clone)")
            {
                count++;
            }
            if (code.name == "Copy(Clone)")
            {
                copyValue = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0];
            }
            if (code.name.Substring(0,4) == "jump" && !check.ContainsKey(code.name)) 
            {
                check.Add(code.name, i);
                wait = new WaitForSeconds(0f);
            }
            if(check.ContainsKey(code.name))
            {
                i = check[code.name];
                wait = new WaitForSeconds(0f);
            }
            
            yield return wait;
        }
    }
  
}
