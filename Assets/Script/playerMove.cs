using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class playerMove : MonoBehaviour
{
    private bool isPaste;
    private Vector3 boxPos;
    public Animator ani;
    private SpriteRenderer[] sprite;
    public CheckCode checkcode;
    public int count = 0;
    public float sum = 0.2f;
    public GameObject valueBox;
    private void Start()
    {
        isPaste = false;
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
    public void SetValueBox(GameObject valueBox)
    {
        this.valueBox = valueBox;
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

    private void Update()
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
        else if(checkcode.code.name.Equals("Copy(Clone)") && collision.name.Equals(valueBox.name))
        {
            Copy(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPaste && checkcode.code.name.Equals("take(Clone)") && collision.name.Equals(valueBox.name))   
        {
            isPaste = false;
            Paste(collision);
        }
    }
    public void setIsPaste(bool paste)
    {
        this.isPaste = paste;
    }
    private void SetAnimation()
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            ani.SetBool("IsRun", false);
            ani.SetBool("IsCarry", true);
        }
        else if (!gameObject.transform.Find("Box(Clone)"))
        {
            ani.SetBool("IsCarry", false);
            ani.SetBool("IsRun", true);
        }
    }
    private void BoxPickUP(Collider2D collision)
    {
 
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
        gameObject.transform.GetChild(transform.Find("Box(Clone)").GetSiblingIndex()).transform.SetParent(collision.gameObject.transform);
        collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
        sum += 0.2f;
    }
    private void Copy(Collider2D collision)
    {
        if (collision.transform.Find("Box(Clone)"))
        {
            Destroy(collision.transform.Find("Box(Clone)").gameObject);
        }
        GameObject Box = gameObject.transform.Find("Box(Clone)").gameObject;
        Box.transform.SetParent(valueBox.transform);
        Box.transform.localPosition = Vector3.zero;
    }
    private void Paste(Collider2D collsion)
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            Destroy(gameObject.transform.Find("Box(Clone)").gameObject);
        }
        GameObject BoxPrefeb = Instantiate(collsion.gameObject.transform.Find("Box(Clone)")).gameObject as GameObject;
        BoxPrefeb.name = "Box(Clone)";
        BoxPrefeb.transform.SetParent(this.gameObject.transform);
        BoxPrefeb.transform.localPosition = boxPos;

        
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
