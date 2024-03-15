using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour , IDragHandler ,IEndDragHandler , IBeginDragHandler
{
    GameObject copyInputData;
    public GameObject parent;
    public bool isMouseUse = false;

    private void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        copyInputData = Instantiate(this.gameObject, GameObject.FindWithTag("Layout").gameObject.transform) as GameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        copyInputData.transform.position = eventData.position;
        isMouseUse = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isMouseUse = false;
        Destroy(copyInputData);
    }
    

    private void Awake()
    {

    }
    void Update()
    {
        Debug.Log(gameObject.tag);
    }

}
