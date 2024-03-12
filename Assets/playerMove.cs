using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum PlayerState
{
    Move, 
    Idle,
    PickUp
}

public class playerMove : MonoBehaviour
{

    public Animator ani;
    public inputBelt inputBelt;
    private SpriteRenderer[] sprite;
    public PlayerState playerstate;
    public CheckCode checkcode;
    public int count = 0;
    public float sum = 0.2f;
    public bool BoxPickUp = true;
    public GameObject valueBox;
    private void Start()
    {
        playerstate = PlayerState.Idle;
        ani = GetComponent<Animator>();
        sprite = new SpriteRenderer[3];
        sprite[0] = GetComponent<SpriteRenderer>();
        for(int i = 0; i < 2; i++)
        {
            sprite[i + 1] = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        checkcode = GameObject.FindWithTag("CheckCode").GetComponent<CheckCode>();
    }
    public void SetValueBox(GameObject valueBox)
    {
        this.valueBox = valueBox;
    }
    public void Move(Transform target)
    {
        
        if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            playerstate = PlayerState.Idle;
            ani.SetBool("IsRun", false);
        }
        else
        {
            playerstate = PlayerState.Move;
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
    public void checkIF(string id)
    {
        int a = int.Parse(id);
        int b = int.Parse(gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text);

        if (checkcode.Isif)
        {
            if (checkcode.Ifvalue[0] == '=')
            {
                if (b == a)
                {
                    checkcode.IF = true;
                }
                else
                {
                    checkcode.IF = false;
                }
            }
            else if (checkcode.Ifvalue[0] == '>')
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
    public void checkIF(GameObject valueBox)
    {
        this.valueBox = valueBox;
        int a = int.Parse(valueBox.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text);
        int b = int.Parse(gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text);
        Debug.Log($"ifvalue : {checkcode.Ifvalue[0]} , 박스에 있는 숫자 : {a} , 내손에 있는 숫자 {b}");
        if (checkcode.Isif)
        {
            if(checkcode.Ifvalue[0] == '=')
            {
                if(b == a)
                {
                    checkcode.IF = true;
                }else
                {
                    checkcode.IF = false;
                }
            }
            else if (checkcode.Ifvalue[0] == '>')
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
        
        try
        {
            if (collision.name == "OutputBelt")
            {
                gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).transform.SetParent(collision.gameObject.transform);
                collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
                sum += 0.2f;
                ani.SetBool("IsCarry", false);
            }
            
        }
        catch(Exception e)
        {
            Debug.Log(e);
            Time.timeScale = 0;
        }
        
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(valueBox);
        if (collision.name == "InputBelt")
        {
            if(checkcode.code.name.Equals("Pick up(Clone)") && BoxPickUp){

                BoxPickUp = false;
                if (collision.name == "InputBelt")
                {

                    ani.SetBool("IsRun", false);
                   
                    ani.Play("PlayerPickUp", 0, 0);
                    inputBelt.transform.GetChild(0).gameObject.SetActive(false);
                    if (gameObject.transform.Find("Box(Clone)"))
                    {
                        Destroy(gameObject.transform.Find("Box(Clone)").gameObject);
                        collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
                        gameObject.transform.GetChild(3).transform.localPosition = new Vector3(0f, 0.5f, 0f);
                    }
                    else
                    {
                        collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
                        gameObject.transform.GetChild(2).transform.localPosition = new Vector3(0f, 0.5f, 0f);
                    }
                    StartCoroutine(BoxShow());
                    
                    
                }
            }
        }
        if (valueBox != null && collision.name.Equals(valueBox.name))
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
                //valueBox.transform.Find("Box(Clone)").gameObject.SetActive(false);
                GameObject prefeb = Instantiate(collision.transform.GetChild(1).transform.gameObject, gameObject.transform) as GameObject;
                prefeb.SetActive(false);
                if (valueBox.transform.position.x <= this.gameObject.transform.position.x)
                {
                    ani.Play("PlayerPickUp", 0, 0);
                    StartCoroutine(BoxShow());
                }
                else if (valueBox.transform.position.x > this.gameObject.transform.position.x)
                {
                    ani.Play("PlayerPickUp2", 0, 0);
                    StartCoroutine(Boxshow1());
                }
                
                if (transform.Find("Box(Clone)"))
                {
                    Destroy(gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).gameObject);
                }
                prefeb.name = "Box(Clone)";
                prefeb.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                prefeb.transform.localScale = new Vector3(0.694182277f, 0.805350602f, 1.08090448f);
                //collision.transform.GetChild(1).transform.SetParent(gameObject.transform);


                ani.SetBool("IsCarry", true);   
                checkcode.IsPaste = false;

            }
            if (checkcode.isCal)
            {
                string num1 = valueBox.transform.Find("Box(Clone)").gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                string num = gameObject.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text;
                Debug.Log($"num : {num1} num1 : {num}");
                int sum = 0;
                if (checkcode.calvalue[1] == '+')
                {
                    sum = int.Parse(num) + int.Parse(num1);
                }
                else if (checkcode.calvalue[1] == '-')
                {
                    sum = int.Parse(num) - int.Parse(num1);
                }
                else if (checkcode.calvalue[1] == '*')
                {
                    sum = int.Parse(num) * int.Parse(num1);
                }
                else if (checkcode.calvalue[1] == '/')
                {
                    sum = int.Parse(num) / int.Parse(num1);
                }
                Debug.Log($"sum : {sum}");

                gameObject.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text = sum.ToString();
                checkcode.isCal = false;
            }

        }
        
    }
    IEnumerator BoxShow()
    {
        yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        Debug.Log($"pick up {ani.GetCurrentAnimatorStateInfo(0).normalizedTime}");
        gameObject.transform.Find("Box(Clone)").gameObject.SetActive(true);
    }
    IEnumerator Boxshow1()
    {
        yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp2") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        Debug.Log($"pick up2 {ani.GetCurrentAnimatorStateInfo(0).normalizedTime}");
        gameObject.transform.Find("Box(Clone)").gameObject.SetActive(true);
    }
}
