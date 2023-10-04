using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public CheckCode checkcode;
    public int count = 0;
    public float sum = 0.2f;
    private void Start()
    {
        checkcode = GameObject.FindWithTag("CheckCode").GetComponent<CheckCode>();
    }
    public void Move(Transform target)
    {

        transform.position += (target.position - transform.position).normalized * Time.deltaTime * 5f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "InputBelt")
        {
            collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        if (collision.name == "OutputBelt")
        {
            gameObject.transform.GetChild(0).transform.SetParent(collision.gameObject.transform);
           
            collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
            sum += 0.2f;
        }
        if(collision.name == "A")
        {
            if (checkcode.IsCopy)
            {
                if (gameObject.transform.childCount != 0)
                {
                    if(collision.transform.childCount > 1)
                    {
                        Destroy(collision.transform.GetChild(1).gameObject);
                        gameObject.transform.GetChild(0).SetParent(collision.transform);
                        collision.transform.GetChild(2).transform.localPosition = Vector3.zero;
                        checkcode.IsCopy = false;
                    }
                    else
                    {
                        gameObject.transform.GetChild(0).SetParent(collision.transform);
                        collision.transform.GetChild(1).transform.localPosition = Vector3.zero;
                        checkcode.IsCopy = false;
                    }
                }
            }
            if (checkcode.IsPaste)
            {
                if(gameObject.transform.childCount != 0)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                }
                collision.transform.GetChild(1).transform.SetParent(gameObject.transform);
                gameObject.transform.GetChild(1).transform.localPosition = Vector3.up;
                checkcode.IsPaste = false;  
            }
            if (checkcode.Isif)
            {
                if( gameObject.transform.childCount != 0)
                {
                    int a = int.Parse(collision.gameObject.transform.GetChild(1).GetComponent<Text>().text[0].ToString());
                    int b = int.Parse(gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text[0].ToString());
                    if (checkcode.Ifvalue[1] == '>')
                    {
                        if(b > a)
                        {
                            checkcode.IF = true;
                        }else
                        {
                            checkcode.IF = false;
                        }
                    }
                    if(checkcode.Ifvalue[1] == '<')
                    {
                        if (b < a)
                        {
                            checkcode.IF = true;
                        }
                        else
                        {
                            checkcode.IF = false;
                        }
                    }
                    checkcode.Isif = false;
                }
            }
        }
    }
}
