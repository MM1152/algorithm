using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckCode : MonoBehaviour
{
    public List<GameObject> codes;
    public Transform TargetPosition;
    public GameObject code;
    public GameObject player;
    public GameObject inputBelt;
    public GameObject outBelt;
    WaitForSeconds wait;
    public GameObject a;
    private void Start()
    {
        codes = new List<GameObject>();
        wait = new WaitForSeconds(2f);
        
    }
    public void checkCode()
    {
        code = GameObject.FindWithTag("Codes");
        codes.Add(code);

        
        while (true)
        {
           
            try
            {
                if (code.transform.GetChild(1) != null)
                {
                    code = code.transform.GetChild(1).gameObject;
                    codes.Add(code);
                    
                    
                    
                }else
                {
                    break;
                }
            }
            catch(Exception e)
            {
                break;
            }
        }
        StartCoroutine(Run());
    }

    private void Update()
    {
        if(a != null)
        {
            if(a.name == "Pick up(Clone)")
            {
                player.transform.localPosition += (inputBelt.transform.position - player.transform.position) * Time.deltaTime;
            }
            else if (a.name == "Pick off(Clone)")
            {
                player.transform.localPosition += (outBelt.transform.position - player.transform.position) * Time.deltaTime;   
            }
        }
    }
    IEnumerator Run()
    {
        Debug.Log("asd");
        foreach (var b in codes)
        {
            
            a = b;
            yield return new WaitForSeconds(2f);
        }
    }
}
