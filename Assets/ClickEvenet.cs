using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvenet : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (!transform.GetChild(1).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }else
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
            
        }
    }

}
