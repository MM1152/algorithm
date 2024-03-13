    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onDrag : MonoBehaviour, IDragHandler  , IEndDragHandler
{
    public static bool isDrag;
    public List<GameObject> codes;
    public GameObject Collision;
    public GameObject Canvas;
    public GameObject originCanvas;
    public GameObject inside;
    public bool Iscollision;
    public bool Up;
    public int index;
    private void OnLevelWasLoaded(int level)
    {
        isDrag = false;
        index = -1;
        codes = new List<GameObject>();
        Canvas = GameObject.FindWithTag("Content").gameObject;
        originCanvas = GameObject.FindWithTag("Canvas").gameObject;
        inside = GameObject.Find("Position").gameObject; // ���� ��ġ�� ���� ������ �ٸ� �������� �ڵ��� �̵��� ��ġ�� �̸� ������
    }
    private void Awake()
    {
        isDrag = false;
        index = -1;
        codes = new List<GameObject>();
        Canvas = GameObject.FindWithTag("Content").gameObject;
        originCanvas = GameObject.FindWithTag("Canvas").gameObject;
        inside = GameObject.Find("Position").gameObject;

    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.tag = "Draging";
        isDrag = true;
        gameObject.transform.position = eventData.position;
        transform.SetParent(originCanvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        gameObject.tag = "Codes";
        inside.transform.SetParent(originCanvas.transform);
        if (Iscollision)
        {
            transform.SetParent(Canvas.transform);
        } else
        {
            Destroy(gameObject);
        }
        if (index != -1)
        {
            transform.SetSiblingIndex(index);
            index = -1;
        }
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            if(collision.transform.position.y < transform.position.y)
            {
                index = collision.transform.GetSiblingIndex();
                inside.transform.SetParent(Canvas.transform);
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


}
