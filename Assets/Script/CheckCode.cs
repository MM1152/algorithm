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
    public bool IsPaste;
    public bool Isif;
    public char[] Ifvalue;
    public WaitForSeconds wait;
    public GameObject value;

    public bool IF;
    private void Start()
    {
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
<<<<<<< HEAD
        if (code != null)
=======
        if (IF)
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
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
                        player.Move(Values[0]);
                    }
                }
                if (code.name == "take(Clone)")
                {
                    if (copyValue == 'A')
                    {
                        player.Move(Values[0]);
                    }
                }
<<<<<<< HEAD
                if (code.name.Substring(0,2) == "if" && check.ContainsKey(code.name))
                {
                    if (Ifvalue[1] == 'A')
                    {
                        
                        player.checkIF(Values[0]);  
                    
=======
                if (code.name == "if(Clone)")
                {
                    if (Ifvalue[1] == 'A')
                    {
                        player.Move(Values[0]);
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
                    }
                }
            }
            if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
            {
                player.Move(Values[0].transform);
            }
        }
        else
        {
            wait = new WaitForSeconds(0f);
        }
<<<<<<< HEAD
        

=======
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
    }

    IEnumerator Run()
    {
        for(int i = 0; i < Lay.transform.childCount; i++)
        {
            
            code = list[i];
<<<<<<< HEAD
=======
        
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
            if (code.name == "Pick up(Clone)")
            {
                count++;
            }
            if (code.name == "Copy(Clone)")
            {
                IsCopy = true;
                copyValue = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0];
            }
            if(code.name == "take(Clone)")
            {
                IsPaste = true;
                copyValue = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0];
            }
            
            if (!check.ContainsKey(code.name) && code.name.Substring(0,2) == "if")
            {
                check.Add(code.name, i);
                Ifvalue[0] = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0]; // > , <
                Ifvalue[1] = code.transform.GetChild(2).GetChild(0).GetComponent<Text>().text[0]; // value
                Isif = true;
            }
<<<<<<< HEAD
            else if (check.ContainsKey(code.name))
            {
                
                if (!IF)
                {
                    IF = true;
                }
                check.Remove(code.name);
            }
            else if ( !check.ContainsKey(code.name) && code.name.Substring(0, 4) == "jump") 
=======
            if ( !check.ContainsKey(code.name) && code.name.Substring(0, 4) == "jump") 
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
            {
                check.Add(code.name, i);
                wait = new WaitForSeconds(0f);
            }
            if(check.ContainsKey(code.name))
            {
                if (code.name.Substring(0, 2) == "if")
                {
                    if (!IF)
                    {
                        IF = true;
                    }
                }
                else if (code.name.Substring(0,4) == "jump")
                {
                    i = check[code.name];
                    wait = new WaitForSeconds(0f);
                }

                
            }
            Debug.Log(IF);
            Debug.Log(i);

            yield return wait;
        }
    }
  
}
