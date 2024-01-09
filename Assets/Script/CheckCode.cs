using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class CheckCode : MonoBehaviour
{
    public Armposition armPos;
    Dictionary<string, int> check;
    public inputBelt inputBelt;
    public outBelt outBelt;
    
    public GameManager gameManager;
    public GameObject CodePoint;
    public static bool CodeRunning;
    public Transform inputBelttrans;
    public Transform outBelttrans;
    public List<GameObject> Values;
    
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
    public GameObject value;

    public WaitUntil wait; // 지정된 동작이 끝나는 시간.

    public bool IF;
    private void Start()
    {
        
        if(GameObject.Find("CodePoint").GetComponents<Image>().Length == 1)
        {
            CodePoint = GameObject.Find("CodePoint").gameObject;
        }else
        {
            Destroy(CodePoint);
        }
        for (int i = 0; i < value.transform.childCount; i++)
        {
            Values.Add(value.transform.GetChild(i).gameObject);
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Lay = GameObject.FindWithTag("Content").gameObject;
        count = 0;
        IF = true;
        Ifvalue = new char[2];
        IsCopy = false;
        IsPaste = false;
        Isif = false;
       
    }
    public void checkCode()
    { 
        
        check = new Dictionary<string, int>();
        list = new List<GameObject>();
        for (int i = 0; i < Lay.transform.childCount; i++)
        {
            list.Add(Lay.gameObject.transform.GetChild(i).gameObject);
        }
        CodeRunning = true;
        StartCoroutine(Run());
    }

    private void Update()
    {
        if(Time.unscaledDeltaTime != 0)
        {
            if (code != null)
            {


                if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))

                {
                    if (Ifvalue[1] == 'A')
                    {
                        player.checkIF(Values[0]);
                    }
                    else if (Ifvalue[1] == 'B')
                    {
                        player.checkIF(Values[1]);
                    }
                }
                Console.WriteLine($"IF : {IF}");
                if (IF)
                {
                    if (code.name == "Pick up(Clone)")
                    {
                        player.Move(inputBelttrans);
                    }
                    if (code.name == "Pick off(Clone)")
                    {
                        player.Move(outBelttrans);
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
                            player.Move(Values[0].transform);
                        }
                        else if (Ifvalue[1] == 'B')
                        {
                            player.Move(Values[1].transform);
                        }

                    }
                }
               
                

            }
        }
        
    }

    IEnumerator Run()
    {
        
        for (int i = 0; i < Lay.transform.childCount; i++)
         {
            try
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
                else
                {
                    
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
                    
                    check.Remove(code.name);
                }

                if (!check.ContainsKey(code.name) && code.name.Substring(0, 2) == "ju")
                {
                    check.Add(code.name, i);
                    
                }
                else if (code.name.Substring(0, 2) == "ju" && check.ContainsKey(code.name))
                {
                    
                    if (inputBelt.boxNum.Count > count)
                    {
                        i = check[code.name];
                    }
                    
                }
                CodePoint.transform.SetParent(code.transform);
                CodePoint.transform.localPosition = new Vector3(-150f, 0f, 0f);
                
            } catch(Exception e)
            {
                Debug.Log(e);
            }
            if(code.name.Equals("Pick up(Clone)"))
            {
                yield return new WaitForSeconds(0.01f);
                yield return new WaitUntil(() => player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") && player.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
                
                player.ani.SetBool("IsPickUp", false);
                armPos.SetArmPos();
                
            }
            if (IF)
            {
                if (code.name.Equals("take(Clone)"))
                {
                    yield return new WaitForSeconds(0.01f);
                    yield return new WaitUntil(() => player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") && player.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

                    player.ani.SetBool("IsPickUp", false);
                    armPos.SetArmPos();

                }
            }
            else if(code.name.Substring(0, 2) == "ju" || code.name.Substring(0, 2) == "if")
            {
                yield return new WaitForSeconds(0f);
            }else
            {
                yield return new WaitForSeconds(2f);
            }
        }
        
    }

}
