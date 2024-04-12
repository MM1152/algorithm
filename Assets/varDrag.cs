using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class varDrag : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject dragObject;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragObject = Instantiate(gameObject , this.gameObject.transform) as GameObject;
        dragObject.GetComponent<varDrag>().parent = this.gameObject.transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       Destroy(dragObject , 0.05f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
