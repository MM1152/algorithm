using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onDrag : MonoBehaviour, IDragHandler  , IEndDragHandler
{
    Vector3 collsionTrans;
    Vector3 CollisionTransform;
    public bool Iscollision;
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("MOuseUp");
        if (Iscollision)
        {
            Debug.Log("asd");
            gameObject.transform.position = CollisionTransform + collsionTrans;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            Debug.Log(collision.name);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {

            Iscollision = true;
            CollisionTransform = collision.transform.position;
            if (collision.transform.position.y > gameObject.transform.position.y)
            {
                
                collsionTrans = Vector3.down * 40f;
            }
            if (collision.transform.position.y < gameObject.transform.position.y)
            {
                collsionTrans = Vector3.up * 40f;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            Iscollision = false;
        }
    }


}
