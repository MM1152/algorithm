using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    public string name;
    [SerializeField] private RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        valueSelect = false;
        isValueCopy = false;
        originTransform = this.gameObject.transform.localPosition;
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        rect = GetComponent<RectTransform>();
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
                Debug.Log(gameObject.name);
                
                Values values = gameObject.transform.GetChild(1).GetComponent<Values>();
                int parentSibling = _thisGameObj.transform.GetSiblingIndex();
                int allChildIndex = _thisGameObj.transform.parent.childCount;
                
                if (allChildIndex > 7 && 4 > allChildIndex - parentSibling)
                {
                    values.SetUpdwon(false , gameObject.transform.GetChild(1).childCount , Canvas.transform);
                }else
                {
                    values.SetUpdwon(true , gameObject.transform.GetChild(1).childCount , Canvas.transform);
                }
                gameObject.transform.SetParent(Canvas.transform);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);

            }
            else if((gameObject.name == "Value" || gameObject.name == "cal") && gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                transform.SetParent(_thisGameObj.transform);
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

        if (valueSelect)
        {  
            if (rect.localScale.x < 1.3f) 
                rect.localScale += new Vector3(0.2f, 0.2f);
        }else
        {
            rect.localScale = Vector3.one;
        }
        if (onDrag.isDrag && (gameObject.name == "Value" || gameObject.name == "cal"))  
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
                name = mouseDrag.gameObject.name;
            }
            else
            {
                gameObject.transform.GetChild(0).GetComponent<Text>().text = mouseDrag.parent.GetComponent<InputField>().text;
                name = mouseDrag.gameObject.name;
            }               
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Index") && !onDrag.isDrag && !MouseDrag.isMouseUse)
        {
            mouseDrag = collision.GetComponent<MouseDrag>().parent.GetComponent<MouseDrag>();
            isValueCopy = true;
        }
    }
}
