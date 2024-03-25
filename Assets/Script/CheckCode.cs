using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class CheckCode : MonoBehaviour
{
    List<Codes> codes = new List<Codes>();

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
    public WaitUntil wait; // ������ ������ ������ �ð�.

    public bool IF;
    public Dictionary<string, int> ifJump_NameAndValue;
    public int IfJump_Count;
    public Dictionary<String, GameObject> parentIfJump;
    private void Start()
    {
        codes.Add(new Copy());
        codes.Add(new PickUP());
        parentIfJump = new Dictionary<string, GameObject>();
        ifJump_NameAndValue = new Dictionary<string, int>();
        IfJump_Count = 0;
        if (GameObject.Find("CodePoint").GetComponents<Image>().Length == 1)
        {
            CodePoint = GameObject.Find("CodePoint").gameObject;
        }
        else
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
        setIfJump();

        CodeRunning = true;
        StartCoroutine(Run());

    }
    public void setIfJump()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!ifJump_NameAndValue.ContainsKey(list[i].name) && list[i].name.Substring(0, 2).Equals("IF"))
            {
                ifJump_NameAndValue.Add(list[i].name, int.Parse(list[i].transform.GetChild(1).GetComponent<InputField>().text));
                list[i].transform.GetChild(1).GetComponent<InputField>().text = "0";
            }
        }
    }
    private void LateUpdate()
    {
        
    }
    public void CodeRun(Codes game)
    {
        Debug.Log(game);
        game.checkCode();
    }
    IEnumerator Run()
    {

        for (int i = 0; i < Lay.transform.childCount; i++)
        {


            code = list[i];

            if (IF)
            {
                CodeRun(Lay.transform.GetChild(i).gameObject.GetComponent<Codes>());
                yield return new WaitUntil(() => Lay.transform.GetChild(i).gameObject.GetComponent<Codes>().WaitTime());
            }

        }
        Time.timeScale = 0f;

    }

}
