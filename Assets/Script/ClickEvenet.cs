using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.AnimatedValues;
using Unity.Burst.CompilerServices;


public class ClickEvenet : MonoBehaviour, IPointerClickHandler
{
    public GameObject Canvas;
    public GameObject _thisGameObj;
    
    public Vector3 originTransform;
    public MouseDrag mouseDrag;
    public bool isValueCopy;
    public bool valueSelect;
    public static GameObject _this;
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
        valueSelect = false;
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
            else if(gameObject.name == "Copy Value" || gameObject.name == "Take Value" || gameObject.name == "Value1")
            {
                valueSelect = true;
                _this = this.gameObject;
                
            }  
        }
    }
    private void Update()
    {
        
        if (OnMousepointer.selectValue != " ")
            {
                Debug.Log(OnMousepointer.selectValue);
                _this.transform.GetChild(0).GetComponent<Text>().text = OnMousepointer.selectValue;
                valueSelect = false;
                
                //_this = null;
                OnMousepointer.selectValue = " ";
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Index") && !onDrag.isDrag)
        {
            mouseDrag = null;
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
