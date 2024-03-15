using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickEvenet : MonoBehaviour, IPointerClickHandler
{

    public GameObject Canvas;
    public GameObject _thisGameObj;
    public Vector3 originTransform;

    public MouseDrag mouseDrag;
    public bool isValueCopy;  

    private void Awake()
    {
        isValueCopy = false;
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log(originTransform);
        isValueCopy = false;
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (!transform.GetChild(1).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.SetParent(Canvas.transform);
                
            }else
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.SetParent(_thisGameObj.transform);
                transform.localPosition = originTransform;
            }
            
        }
    }
    private void Update()
    {
        if (onDrag.isDrag)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.SetParent(_thisGameObj.transform);
            transform.localPosition = originTransform;
        }

        if(mouseDrag != null && !mouseDrag.isMouseUse && isValueCopy)
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.GetComponent<InputField>().text;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Index"))
        {
            mouseDrag = collision.GetComponent<MouseDrag>().parent.GetComponent<MouseDrag>();
            isValueCopy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Index") && mouseDrag.isMouseUse)
        {
            isValueCopy = false;
        }
    } 

}
