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
        
        if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            ani.SetBool("IsRun", false);
        }
        else
        {
            ani.SetBool("IsRun", true);
            transform.position += (target.position - transform.position).normalized * Time.deltaTime * 5f;
        }
        
        
        if(transform.position.x - target.position.x < 0)
        {
            sprite[0].flipX = false; // ����
            sprite[1].flipX = false; // �Ӹ�
            sprite[2].flipX = false; // ��
        }
        else
        {
            sprite[0].flipX = true; // ����
            sprite[1].flipX = true; // �Ӹ�
            sprite[2].flipX = true; // ��
        }
        
    }
    public void checkIF(GameObject valueBox)
    {   
        int a = int.Parse(valueBox.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text);
        int b = int.Parse(gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text);
        if (checkcode.Isif)
        {
                if (checkcode.Ifvalue[0] == '>')
                {
                    if (b > a)
                    {
                        checkcode.IF = true;
                        Debug.Log("IF TRUE");
                    }
                    else
                    {
                        checkcode.IF = false;
                        Debug.Log("IF FALSE");
                    }
                }
                else if (checkcode.Ifvalue[0] == '<')
                {
                    if (b < a)
                    {
                        checkcode.IF = true;
                        Debug.Log("IF TRUE");
                    }
                    else
                    {
                        checkcode.IF = false;
                        Debug.Log("IF FALSE");
                    }
                }
                checkcode.Isif = false;
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "InputBelt")
        {
            ani.SetBool("IsRun", false);
            ani.SetBool("IsCarry", true);
            if (gameObject.transform.Find("Box(Clone)"))
            {
                Destroy(gameObject.transform.Find("Box(Clone)").gameObject);
                collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
                gameObject.transform.GetChild(3).transform.localPosition = new Vector3(0f, 1f, 0f);
            }
            else
            {
                collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
                gameObject.transform.GetChild(2).transform.localPosition = new Vector3(0f, 1f, 0f);
            }
            
        }
        if (collision.name == "OutputBelt")
        {
            gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).transform.SetParent(collision.gameObject.transform);
           
            collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
            sum += 0.2f;
            ani.SetBool("IsCarry", false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "A" || collision.name == "B")
        {
            if (checkcode.IsCopy)
            {
                if (gameObject.transform.childCount != 0)
                {
                    if (collision.transform.Find("Box(Clone)"))
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
                ani.SetBool("IsCarry", false);
            }
            if (checkcode.IsPaste)
            {
                if (transform.Find("Box(Clone)"))
                {
                    Destroy(gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).gameObject);
                }
                collision.transform.GetChild(1).transform.SetParent(gameObject.transform);
                gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).transform.localPosition = Vector3.up;
                
                ani.SetBool("IsCarry", true);
                checkcode.IsPaste = false;

            }

        }
    }
}
