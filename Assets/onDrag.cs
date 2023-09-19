using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onDrag : MonoBehaviour, IDragHandler  , IEndDragHandler
{
    public List<GameObject> codes;
    Vector3 collsionTrans;
    Vector3 CollisionTransform;
    public GameObject Collision;
    public GameObject Canvas;
    public bool Iscollision;
    public bool Up;
    private void Awake()
    {
        codes = new List<GameObject>();
        Canvas = transform.parent.gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Iscollision)
        {
            if (Up)
            {
                transform.SetParent(Collision.gameObject.transform);
                transform.localPosition = Vector2.down * 40f;
            } else
            {
                Collision.transform.SetParent(gameObject.transform);
                Collision.transform.localPosition = Vector2.down * 40f;
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            Collision = collision.gameObject;
            Iscollision = true;
            CollisionTransform = collision.transform.position;
            if (collision.transform.position.y > gameObject.transform.position.y)
            {
                Up = true;
            }
            else if (collision.transform.position.y < gameObject.transform.position.y)
            {
                Up = false;
            }
 
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == transform.parent.gameObject)
        {
            transform.parent.GetComponent<onDrag>().Iscollision= false;
            Iscollision = false;
            codes.RemoveAll(i => true);
            transform.SetParent(Canvas.transform);
        }
    }


}
