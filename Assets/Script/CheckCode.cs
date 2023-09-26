using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckCode : MonoBehaviour
{
    public static bool CodeRunning;
    public Transform inputBelt;
    public Transform outBelt;
    public Transform target;

    public Stack<GameObject> stack;
    public GameObject code;
    public GameObject Lay;
    public playerMove player;
    public int count;

    public GameObject value;
    public void checkCode()
    {
        stack = new Stack<GameObject>();
        for (int i = 0; i < Lay.transform.childCount; i++)
        {
            stack.Push(Lay.gameObject.transform.GetChild(i).gameObject);
        }

        CodeRunning = true;
        StartCoroutine(Run());
    }

    private void Update()
    {
        if(code != null)
        {
            if(code.name == "Pick up(Clone)")
            {
                player.Move(inputBelt);
            }
            if (code.name == "Pick off(Clone)")
            {
                player.Move(outBelt);
            }
        }
        

    }

    IEnumerator Run()
    {
        for(int i = 0; i < Lay.transform.childCount; i++)
        {
            code = stack.Pop();
            yield return new WaitForSeconds(2f);
        }
    }
  
}
