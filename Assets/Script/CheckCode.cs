using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class CheckCode : MonoBehaviour
{
    Dictionary<string, int> check;

    public GameObject CodePoint;
    public static bool CodeRunning;
    public Transform inputBelt;
    public Transform outBelt;
    public GameObject[] Values;
    public Transform target;

    public List<GameObject> list;
    public GameObject code;
    public GameObject Lay;
    public playerMove player;
    public int count;
    public char copyValue;
    public bool IsCopy;
    public bool IsPaste;
    public bool Isif;
    public char[] Ifvalue;
    public WaitForSeconds wait;
    public GameObject value;

    public bool IF;
    private void Start()
    {
        count = 1;
        IF = true;
        Ifvalue = new char[2];
        IsCopy = false;
        IsPaste = false;
        Isif = false;
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
        if (code != null)
        {
            if (IF)
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
                if (code.name == "Copy(Clone)")
                {
                    if (copyValue == 'A')
                    {
                        player.Move(Values[0].transform);
                    }
                    else if (copyValue == 'B')
                    {
                        player.Move(Values[1].transform);
                    }
                }
                if (code.name == "take(Clone)")
                {
                    if (copyValue == 'A')
                    {
                        player.Move(Values[0].transform);
                    }
                    else if (copyValue == 'B')
                    {
                        player.Move(Values[1].transform);
                    }
                }
                if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
                {
                    if (Ifvalue[1] == 'A')
                    {
                        player.checkIF(Values[0]);
                    }
                    else if(Ifvalue[1] == 'B')
                    {
                        player.checkIF(Values[1]);
                    }
                }
                Debug.Log(code.name);
            }
            if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
            {
                if (Ifvalue[1] == 'A')
                {
                    player.Move(Values[0].transform);
                }
                else if (Ifvalue[1] == 'B')
                {
                    player.Move(Values[1].transform);
                }
               
            }

        }

        else
        {
            wait = new WaitForSeconds(0f);
        }


    }

    IEnumerator Run()
    {
        
        for (int i = 0; i < Lay.transform.childCount; i++)
         {
          
            code = list[i];
            if (IF)
            {
                if (code.name == "Pick up(Clone)")
                {
                    count++;
                }
                if (code.name == "Copy(Clone)")
                {
                    IsCopy = true;
                    copyValue = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0];
                }
                if (code.name == "take(Clone)")
                {
                    IsPaste = true;
                    copyValue = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0];
                }

            }

            if (!check.ContainsKey(code.name) && code.name.Substring(0, 2) == "if")
            {
                check.Add(code.name, i);
                Ifvalue[0] = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0]; // > , <
                Ifvalue[1] = code.transform.GetChild(2).GetChild(0).GetComponent<Text>().text[0]; // value
                Isif = true;
            }
            else if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
            {

                if (!IF)
                {
                    IF = true;
                }
                wait = new WaitForSeconds(0f);
                check.Remove(code.name);
            }

            if (!check.ContainsKey(code.name) && code.name.Substring(0, 2) == "ju")
            {
                check.Add(code.name, i);
                wait = new WaitForSeconds(0f);
            }
            else if (code.name.Substring(0, 2) == "ju" && check.ContainsKey(code.name))
            {
                
                if(count < 6)
                {
                    i = check[code.name];
                }
                wait = new WaitForSeconds(0f);
            }
            CodePoint.transform.SetParent(code.transform);
            CodePoint.transform.localPosition = new Vector3(-150f, 0f, 0f);
            yield return wait;
        }
    }

}
