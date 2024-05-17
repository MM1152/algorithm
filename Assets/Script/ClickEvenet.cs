using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.Burst.CompilerServices; 


public class ClickEvenet : MonoBehaviour, IPointerClickHandler , IPointerEnterHandler
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
        valueSelect = false;
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;

        if (isValueCopy)
        {
            if (mouseDrag.gameObject.name.Equals("InputName"))
            {
                gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.transform.parent.GetComponent<VarData>().getVarValue().ToString();
            }
            else
            {
                gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.GetComponent<InputField>().text;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if((gameObject.name == "Value" || gameObject.name == "cal")  && !gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.SetParent(Canvas.transform);
            }else if((gameObject.name == "Value" || gameObject.name == "cal") && gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if(gameObject.name == "Copy Value" || gameObject.name == "Take Value" || gameObject.name == "Value1" || gameObject.name == "cal Value")
            {
                valueSelect = true;
                _this = this.gameObject;
                isValueCopy = false;
            }
    
            else
            {
                _this = this.gameObject;
            }
        }
    }
    public void setValueText()
    {
        if (gameObject.name != "Image" && gameObject.name != "Value3")
        {

            if (OnMousepointer.selectValue != " ")
            {
                _this.transform.GetChild(0).GetComponent<Text>().text = OnMousepointer.selectValue.ToString();
                //_this = null;
                OnMousepointer.selectValue = " ";
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

            if (mouseDrag != null && !MouseDrag.isMouseUse && isValueCopy)
            {
                if (mouseDrag.gameObject.name.Equals("InputName"))
                {
                    gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.transform.parent.GetComponent<VarData>().getVarValue().ToString();
                }
                else
                {
                    gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.GetComponent<InputField>().text;
                }
               
            }
        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Index") && !onDrag.isDrag && !MouseDrag.isMouseUse)
        {
            Debug.Log($"Collision name : {collision.name}");
            mouseDrag = collision.GetComponent<MouseDrag>().parent.GetComponent<MouseDrag>();
            if (mouseDrag.gameObject.name.Equals("InputName"))
            {
                mouseDrag.gameObject.GetComponent<DrawGizmo>().setConnection(this.gameObject);
            }
            isValueCopy = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("in");
    }
}
