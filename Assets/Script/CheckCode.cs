using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class CheckCode : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject CodePoint;

    public outBelt outBelt;
    public List<GameObject> list;
    public GameObject code;
    public GameObject Lay;
    public playerMove player;

    public int Count { get; private set; }
    public int i { get; private set; }
    private void Start()
    {
        outBelt = GameObject.Find("OutputBelt").GetComponent<outBelt>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Lay = GameObject.FindWithTag("Content").gameObject;

    }
    public void checkCode()
    {
        list = new List<GameObject>();
        for (int i = 0; i < Lay.transform.childCount; i++)
        {
            list.Add(Lay.gameObject.transform.GetChild(i).gameObject);
        }
        player.setIsidle(false) ;
        StartCoroutine(Run());

    }
    public void CodeRun(Codes game)
    {
        game.checkCode();
    }
    public void Seti(int i)
    {
        this.i = i;
    }
    public void CountPlus()
    {
        Count++;
    }
    IEnumerator Run()
    {

        for (i = 0; i < Lay.transform.childCount; i++)
        {
            code = list[i];
            CodeRun(code.GetComponent<Codes>());
    
            yield return new WaitUntil(() => Lay.transform.GetChild(i).gameObject.GetComponent<Codes>().WaitTime());
            yield return new WaitForEndOfFrame();    
                
        }
        Debug.Log("asd");
        outBelt.CheckCodeEnd();
    }
    
}
