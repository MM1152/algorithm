    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onDrag : MonoBehaviour, IDragHandler  , IEndDragHandler , IBeginDragHandler
{
    public CheckCode checkCode;
    public static bool isDrag;
    public List<GameObject> codes;
    public GameObject Collision;
    public GameObject Canvas;
    public GameObject originCanvas;
    public GameObject inside;
    public bool Iscollision;
    public bool Up;
    public int index;
    public GameObject Child;
    public GameObject number;
    private void OnLevelWasLoaded(int level)
    {
        
        checkCode = GameObject.Find("CheckCode").GetComponent<CheckCode>();
        isDrag = false;
        index = -1;
        Canvas = GameObject.FindWithTag("Content").gameObject;
        originCanvas = GameObject.FindWithTag("Canvas").gameObject;
        inside = GameObject.Find("Position").gameObject; // ���� ��ġ�� ���� ������ �ٸ� �������� �ڵ��� �̵��� ��ġ�� �̸� ������
    }
    private void Awake()
    {
        checkCode = GameObject.Find("CheckCode").GetComponent<CheckCode>();
        isDrag = false;
        index = -1;
        Canvas = GameObject.FindWithTag("Content").gameObject;
        originCanvas = GameObject.FindWithTag("Canvas").gameObject;
        inside = GameObject.Find("Position").gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (number != null)
        {
            number.SetActive(false);
        }
        gameObject.tag = "Draging";
        isDrag = true;
        gameObject.transform.position = eventData.position;
        transform.SetParent(originCanvas.transform);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        if(number != null)
        {
            number.SetActive(true);
        }
        
        gameObject.tag = "Codes";
        inside.transform.SetParent(originCanvas.transform);
        if (Iscollision)
        {
            transform.SetParent(Canvas.transform);
        } else
        {
            if (Child != null)
            {
                Destroy(gameObject);
                Destroy(Child);
            } else
            {
                Destroy(gameObject);
            }
            
        }
        if (index != -1)
        {
            transform.SetSiblingIndex(index);
            index = -1;
        }
        
        
    }
    public void SetChild(GameObject child)
    {
        Child = child;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            if(collision.transform.position.y < transform.position.y)
            {
                index = collision.transform.GetSiblingIndex();
                //inside.transform.SetParent(Canvas.transform);
                inside.transform.SetSiblingIndex(index);
            }
            if (collision.transform.position.y > transform.position.y)
            {
                index = collision.transform.GetSiblingIndex() + 1;
                //inside.transform.SetParent(Canvas.transform);
                inside.transform.SetSiblingIndex(index);
            }
        }
        if(collision.tag == "Layout")
        {
            Iscollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Layout")
        {
            index = -1;
            Iscollision = false;
            gameObject.SetActive(true);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        inside.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta * gameObject.GetComponent<RectTransform>().localScale;
        inside.transform.SetParent(Canvas.transform);
        inside.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex());
    }
}
