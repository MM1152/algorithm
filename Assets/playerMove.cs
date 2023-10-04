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
<<<<<<< HEAD
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
            Debug.Log(checkcode.Ifvalue[0]);
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
        if(gameObject.transform.childCount > 2)
        {
            ani.SetBool("IsCarry", true);
        }else
        {
            ani.SetBool("IsCarry", false);
        }
=======

        transform.position += (target.position - transform.position).normalized * Time.deltaTime * 5f;

>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "InputBelt")
        {
<<<<<<< HEAD
            if(gameObject.transform.Find("Box(Clone)"))
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
            
=======
            collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0f, 1f, 0f);
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
        }
        if (collision.name == "OutputBelt")
        {
            gameObject.transform.GetChild(0).transform.SetParent(collision.gameObject.transform);
           
            collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
            sum += 0.2f;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "A")
        {
            if (checkcode.IsCopy)
            {
                if (gameObject.transform.childCount != 0)
                {
                    if (collision.transform.childCount > 1)
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
                if (gameObject.transform.childCount != 0)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                }
                collision.transform.GetChild(1).transform.SetParent(gameObject.transform);
<<<<<<< HEAD
                gameObject.transform.GetChild(2).transform.localPosition = Vector3.up;
                checkcode.IsPaste = false;
            }

=======
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
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
        }
    }
}
