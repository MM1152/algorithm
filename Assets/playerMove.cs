using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    private Animator ani;
    private SpriteRenderer[] sprite;
    public CheckCode checkcode;
    public int count = 0;
    public float sum = 0.2f;
    private void Start()
    {
        ani = GetComponent<Animator>();
        sprite = new SpriteRenderer[3];
        sprite[0] = GetComponent<SpriteRenderer>();
        for(int i = 0; i < 2; i++)
        {
            sprite[i + 1] = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        checkcode = GameObject.FindWithTag("CheckCode").GetComponent<CheckCode>();
    }
    public void Move(Transform target)
    {
        ani.SetBool("IsRun", true);
        if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            ani.SetBool("IsRun", false);
        }else
        {
            transform.position += (target.position - transform.position).normalized * Time.deltaTime * 5f;
        }
        
        
        if(transform.position.x - target.position.x < 0)
        {
            sprite[0].flipX = false; // 个烹
            sprite[1].flipX = false; // 赣府
            sprite[2].flipX = false; // 颊
        }
        else
        {
            sprite[0].flipX = true; // 个烹
            sprite[1].flipX = true; // 赣府
            sprite[2].flipX = true; // 颊
        }
    }
    public void checkIF(GameObject valueBox)
    {
        int a = int.Parse(valueBox.transform.GetChild(1).GetComponent<Text>().text[0].ToString());
        int b = int.Parse(gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text[0].ToString());
        Debug.Log($"{a} , {b}");
        if (checkcode.Isif)
        {
            Debug.Log($"asd");
            if (gameObject.transform.childCount != 0)
            {

                Debug.Log($"{a} , {b}");
                if (checkcode.Ifvalue[1] == '>')
                {
                    if (b > a)
                    {
                        checkcode.IF = true;
                    }
                    else
                    {
                        checkcode.IF = false;
                    }
                }
                if (checkcode.Ifvalue[1] == '<')
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
        if(gameObject.transform.childCount > 2)
        {
            ani.SetBool("IsCarry", true);
        }else
        {
            ani.SetBool("IsCarry", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "InputBelt")
        {
            collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(2).transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        if (collision.name == "OutputBelt")
        {
            gameObject.transform.GetChild(2).transform.SetParent(collision.gameObject.transform);
           
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
                        gameObject.transform.GetChild(2).SetParent(collision.transform);
                        collision.transform.GetChild(2).transform.localPosition = Vector3.zero;
                        checkcode.IsCopy = false;
                    }
                    else
                    {
                        gameObject.transform.GetChild(2).SetParent(collision.transform);
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
                gameObject.transform.GetChild(2).transform.localPosition = Vector3.up;
                checkcode.IsPaste = false;  
            }
           
        }
    }
}
