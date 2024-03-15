using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ClickEvenet : MonoBehaviour, IPointerClickHandler
{
    public GameObject Canvas;
    public GameObject _thisGameObj;
    
    public Vector3 originTransform;


    public MouseDrag mouseDrag;
    public bool isValueCopy;
    public static bool valueSelect;
    private void Awake()
    {
        valueSelect = false;
        isValueCopy = false;
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log(originTransform);
        isValueCopy = false;
        valueSelect = false;0
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(gameObject.name == "Value" && !gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.SetParent(Canvas.transform);
            }else if(gameObject.name == "Value" && gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                valueSelect = true;
            }
        }
    }
    private void Update()
    {
        if (OnMousepointer.selectValue != " ")
        {
            transform.GetChild(0).GetComponent<Text>().text = OnMousepointer.selectValue;
            OnMousepointer.selectValue = " ";
            valueSelect = false;
        }

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
        if (collision.tag.Equals("Index") && !onDrag.isDrag)  
        {
            mouseDrag = collision.GetComponent<MouseDrag>().parent.GetComponent<MouseDrag>();
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Index") && !onDrag.isDrag && !mouseDrag.isMouseUse)
        {
            isValueCopy = true;
        }
    }

}
