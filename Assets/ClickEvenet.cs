using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvenet : MonoBehaviour, IPointerClickHandler , IPointerUpHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
