using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onDrag : MonoBehaviour, IDragHandler  , IEndDragHandler
{
    public List<GameObject> codes;
    public GameObject Collision;
    public GameObject Canvas;
    public GameObject originCanvas;
    public bool Iscollision;
    public bool Up;
    public int index;
    private void Awake()
    {
        index = -1;
        codes = new List<GameObject>();
        Canvas = GameObject.FindWithTag("Layout").gameObject;
        originCanvas = GameObject.FindWithTag("Canvas").gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        transform.SetParent(originCanvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Iscollision)
        {
            transform.SetParent(Canvas.transform);
        } else
        {
            Destroy(gameObject);
        }
        if (index != -1)
        {
            Debug.Log(index);
            transform.SetSiblingIndex(index + 1);
            index = -1;
        }
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            if(collision.transform.position.y > transform.position.y)
            {
                
                index = collision.transform.GetSiblingIndex();
            }
        }
        if(collision.tag == "Layout")
        {
            Debug.Log("Collision");
            Iscollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Layout")
        {
            Iscollision = false;
        }
    }


}
