using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class playerMove : MonoBehaviour
{
    public bool isPaste;
    public bool isCopy;
    public bool isCal;
    private Vector3 boxPos;
    public Animator ani;
    private SpriteRenderer[] sprite;
    public CheckCode checkcode;
    public int count = 0;
    public float sum = 0.2f;
    public GameObject valueBox;
    public Rigidbody2D rg;
    private GameManager gameManager;
    private bool isIdle;
    private void Start()
    {
        isIdle = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isPaste = false;
        rg = GetComponent<Rigidbody2D>();
        boxPos = new Vector3(0f, 0.6f);
        ani = GetComponent<Animator>();
        sprite = new SpriteRenderer[3];
        sprite[0] = GetComponent<SpriteRenderer>();
        for(int i = 0; i < 2; i++)
        {
            sprite[i + 1] = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        checkcode = GameObject.FindWithTag("CheckCode").GetComponent<CheckCode>();
    }
    public void setIsCal(bool value)
    {
        this.isCal = value;
    }
    public void setIsidle(bool value)
    {
        this.isIdle = value;
    }
    public void SetValueBox(GameObject valueBox)
    {
        if (valueBox.activeSelf)
        {
            this.valueBox = valueBox;
        }else
        {
            gameManager.Finish(true, "그 번호의 변수는 존재하지 않아요!");
        }
        
    }
    public void Move(Transform target)
    {
        if (Vector2.Distance(transform.position, target.position) >= 0.2)
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
    void SetAnimation()
    {
        if (this.gameObject.transform.Find("Box(Clone)") && !isIdle)
        {
            ani.SetBool("IsCarry", true);
            ani.SetBool("IsRun", false);
        }else if(!this.gameObject.transform.Find("Box(Clone)") && !isIdle)
        {
            ani.SetBool("IsCarry", false);
            ani.SetBool("IsRun", true);
        }
    }
    private void FixedUpdate()
    {
        SetAnimation();
        //Debug.Log($"게임오브젝트 x좌표 : {gameObject.transform.position.x}  valueBox x좌표 : {valueBox.transform.position.x}");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (checkcode.code.name.Equals("Pick off(Clone)") && collision.name == "OutputBelt")
        {
            BoxPickOff(collision);
        }
        else if (checkcode.code.name.Equals("Pick up(Clone)") && collision.name.Equals("InputBelt"))
        {
            ani.Play("PlayerPickUp", 0 , 0);
            BoxPickUP(collision);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPaste && checkcode.code.name.Equals("take(Clone)") && collision.name.Equals(valueBox.name))   
        {
            isPaste = false;
            Paste(collision);
        }
        else if (isCopy && checkcode.code.name.Equals("Copy(Clone)") && collision.name.Equals(valueBox.name))
        {
            
            isCopy = false;
            Copy(collision);
        }
        else if(isCal && checkcode.code.name.Equals("cal(Clone)") && collision.name.Equals(valueBox.name))
        {
            isCal = false;
            Calcu(collision);
        }
    }
    public void setIsPaste(bool paste)
    {
        this.isPaste = paste;
    }
    public void setIsCopy(bool copy)
    {
        this.isCopy = copy;
    }

    private void BoxPickUP(Collider2D collision)
    {
        if (!collision.transform.Find("Box(Clone)"))
        {
            gameManager.Finish(true, "아무것도 없는 상태에선\n 박스를 집을수 없어요!");
        }
        if (gameObject.transform.Find("Box(Clone)"))
        {
            Destroy(gameObject.transform.Find("Box(Clone)").gameObject);
        }

        GameObject Box = collision.transform.Find("Box(Clone)").gameObject;
        collision.transform.Find("Box(Clone)").gameObject.transform.SetParent(gameObject.transform);
        Box.transform.localPosition = boxPos;
        StartCoroutine(BoxShow("PlayerPickUp"));
    }
    private void BoxPickOff(Collider2D collision)
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).transform.SetParent(collision.gameObject.transform);
            collision.gameObject.transform.GetChild(++count).transform.localPosition = new Vector3(0f, 0.4f, 0f);
            sum += 0.2f;
        }
        else {
            gameManager.Finish(true, "아무것도 들지 않은 상태에선\n 박스를 내려놓을 수 없어요!"); 
        }
        
    }
    private void Calcu(Collider2D collsion)
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            
            if (collsion.transform.Find("Box(Clone)"))
            {
                int count = checkcode.code.GetComponent<calcu>().calu(int.Parse(collsion.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text));
                collsion.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text = count.ToString();
                Destroy(this.gameObject.transform.Find("Box(Clone)").gameObject);
                
            }

            
        }else
        {
            gameManager.Finish(true, "아무것도 들지 않고\n 사칙연산을 할 수 없어요 !");
        }
    }
    private void Copy(Collider2D collision)
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            if (collision.transform.Find("Box(Clone)"))
            {
                Destroy(collision.transform.Find("Box(Clone)").gameObject);
            }
            GameObject Box = gameObject.transform.Find("Box(Clone)").gameObject;
            Box.transform.SetParent(valueBox.transform);
            Box.transform.localPosition = Vector3.zero;
        } else
        {
            gameManager.Finish(true, "아무것도 들지 않고\n 복사하기를 할 수 없어요 !");
        }

    }
    private void Paste(Collider2D collsion)
    {
        if (collsion.transform.Find("Box(Clone)")) {
            if (gameObject.transform.Find("Box(Clone)"))
            {
                Destroy(gameObject.transform.Find("Box(Clone)").gameObject);
            }
            GameObject BoxPrefeb = Instantiate(collsion.gameObject.transform.Find("Box(Clone)")).gameObject as GameObject;
            BoxPrefeb.name = "Box(Clone)";
            BoxPrefeb.transform.SetParent(this.gameObject.transform , false);
            BoxPrefeb.transform.localScale = new Vector3(0.7f, 0.7f, 0f);
            BoxPrefeb.transform.localPosition = boxPos;
        } else
        {
            gameManager.Finish(true, "아무것도 없는 곳에서\n 변수집기는 불가능해요 !");
        }
        

        
        if(gameObject.transform.position.x > collsion.transform.position.x)
        {
            ani.Play("PlayerPickUp" ,0 , 0);
            BoxShow("PlayerPickUp");
        }else
        {
            ani.Play("PlayerPickUp2", 0 , 0);
            BoxShow("PlayerPickUp2");
        }
        
    }
    
    IEnumerator BoxShow(string animationName)
    {
        Debug.Log(animationName);
        gameObject.transform.Find("Box(Clone)").gameObject.SetActive(false);
        yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).IsName(animationName) && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        gameObject.transform.Find("Box(Clone)").gameObject.SetActive(true);
        isPaste = true;
    }
}
