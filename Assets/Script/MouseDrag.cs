using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour , IDragHandler , IEndDragHandler , IBeginDragHandler
{
    public bool isMouseUse = false;
    public bool isValueIn = false;
    public GameObject copyValue;
    public GameObject parent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = gameObject;
        copyValue = Instantiate(gameObject, GameObject.FindWithTag("Layout").gameObject.transform);
        copyValue.GetComponent<MouseDrag>().parent = parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        copyValue.transform.position = eventData.position;
        isMouseUse = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isMouseUse = false;
        StartCoroutine(WaitFrame());
        
    }

    IEnumerator WaitFrame()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(copyValue);
    }
}