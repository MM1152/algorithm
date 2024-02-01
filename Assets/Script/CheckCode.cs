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
    public bool isCal;
    public char[] Ifvalue;
    public char[] calvalue;
    public GameObject value;

    public bool FinAction = false;
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
        calvalue = new char[2];
        IsCopy = false;
        IsPaste = false;
        Isif = false;
        isCal = false;
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
       
        if (Time.unscaledDeltaTime != 0)
        {
            if (code != null)
            {
                Console.Write($"target { target } ");
                if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
                {
                    player.checkIF(GameObject.Find(Ifvalue[1].ToString()).gameObject);
                    /*
                    if (Ifvalue[1] == 'A')
                    {
                        player.checkIF(Values[0]);
                    }
                    else if (Ifvalue[1] == 'B')
                    {
                        player.checkIF(Values[1]);
                    }
                    */
                }
                else
                {
                    if (code.name == "Pick up(Clone)")
                    {
                        target = inputBelttrans;
                        player.Move(inputBelttrans);
                        
                    }
                    if (code.name == "Pick off(Clone)")
                    {
                        target = outBelttrans;
                        player.Move(outBelttrans);
                    }
                    if (code.name == "Copy(Clone)")
                    {
                        target = GameObject.Find(copyValue.ToString()).transform;
                        player.SetValueBox(target.gameObject);
                        player.Move(target);
                    }
                    if (code.name == "take(Clone)")
                    {
                        
                        /*
                        if (copyValue == 'A')
                        {
                            target = Values[0].transform;
                            player.Move(Values[0].transform);
                        }
                        else if (copyValue == 'B')
                        {
                            target = Values[1].transform;
                            player.Move(Values[1].transform);
                        }
                        */
                        target = GameObject.Find(copyValue.ToString()).transform;
                        player.SetValueBox(target.gameObject);
                        player.Move(target);
                    }
                    if (code.name.Substring(0, 2) == "if" && check.ContainsKey(code.name))
                    {
                        target = GameObject.Find(Ifvalue[1].ToString()).transform;
                        player.SetValueBox(target.gameObject);
                        player.Move(target);

                    }
                    if(code.name == "cal(Clone)")
                    {
                        target = GameObject.Find(calvalue[0].ToString()).transform;
                        player.SetValueBox(target.gameObject);
                        player.Move(target);
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
                
                if(code.name.Substring(0,2) == "ca")
                {
                    calvalue[1] = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0]; // + , - , * , /
                    calvalue[0] = code.transform.GetChild(2).GetChild(0).GetComponent<Text>().text[0]; // value
                    isCal = true;
                    
                }

                if (!check.ContainsKey(code.name) && code.name.Substring(0, 2) == "if")
                {
                    check.Add(code.name, i);
                    Ifvalue[1] = code.transform.GetChild(1).GetChild(0).GetComponent<Text>().text[0]; // value
                    Ifvalue[0] = code.transform.GetChild(2).GetChild(0).GetComponent<Text>().text[0]; // < , > 
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
            else if (code.name.Equals("take(Clone)"))
            {
                yield return new WaitForSeconds(0.01f);
                yield return new WaitUntil(() => (player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") || player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp2"))  && player.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

                player.ani.SetBool("IsPickUp", false);
                player.ani.SetBool("IsPickUp2", false);
                armPos.SetArmPos();

            }
            /*if (IF)
             {
                 if (code.name.Equals("take(Clone)"))
                 {
                     yield return new WaitForSeconds(0.01f);
                     yield return new WaitUntil(() => player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") && player.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

                     player.ani.SetBool("IsPickUp", false);
                     armPos.SetArmPos();

                 }
             }*/
            if(code.name.Substring(0, 2) == "ju" || code.name.Substring(0, 2) == "if")
            {
                yield return new WaitForSeconds(0f);
            }
            else if (code.name == "cal(Clone)")
            {
                yield return new WaitUntil(() => Vector3.Distance(player.transform.position, target.position) < 0.25f);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                yield return new WaitUntil(() => Vector3.Distance(player.transform.position , target.position) < 0.25f);
                
            }
        }
        
    }

}
