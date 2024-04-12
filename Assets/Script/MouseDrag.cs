using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour , IDragHandler , IEndDragHandler , IBeginDragHandler
{
    public static bool isMouseUse = false;
    public bool isValueIn = false;
    
    public GameObject copyValue;
    public GameObject parent;

    [SerializeField]
    private ClickEvenet clickEvenet;
    private bool inTrigger;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(gameObject.GetComponent<InputField>().text != "")
        {
            parent = gameObject;
            copyValue = Instantiate(gameObject, GameObject.FindWithTag("Layout").gameObject.transform);
            copyValue.GetComponent<MouseDrag>().parent = parent;
        }
        
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