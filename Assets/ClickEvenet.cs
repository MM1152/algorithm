using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvenet : MonoBehaviour, IPointerClickHandler
{
    public GameObject Canvas;
    public GameObject _thisGameObj;
    private void Awake()
    {
        Canvas = GameObject.FindWithTag("Canvas").gameObject;
        _thisGameObj = transform.parent.gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
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
            }
            
        }
    }

}
