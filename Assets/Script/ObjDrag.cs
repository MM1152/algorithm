using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ObjDrag : MonoBehaviour ,IDragHandler , IBeginDragHandler
{    
    float distance = 10;
    public bool Des;
    public MouseDrag mouse;
    public bool IsCollision;
    public Vector3 CollisionTrans;
    public Vector3 CollisionTransY;
    Vector3 ObjPosition;
    // Start is called before the first frame update

    private void OnMouseUp()
    {
        if (IsCollision)
        {
            transform.position = CollisionTrans + CollisionTransY;
        }
    }
    /*public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, distance);
        ObjPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = ObjPosition;
    }
    */
    private void Awake()
    {
        mouse = GameObject.Find("GameManager").GetComponent<MouseDrag>();
    }
    void Update()
    {
       
        if (!mouse.isMouseUse && Des && gameObject.name != "Box Pick up" && gameObject.name != "Box Pick Off")
        {
            Debug.Log("Destory");
            Destroy(gameObject);
        }
    }

  
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("in");
        if(collision.tag == "CheckCode")
        {
            Des = false;
        }

        if (collision.tag == "Codes")
        {
            Debug.Log("Codes On Trigger");
            if (gameObject.transform.position.y < collision.transform.position.y)
            {
                IsCollision = true;
                CollisionTrans = collision.transform.position;
                CollisionTransY = Vector3.down;
      
            }
            if (gameObject.transform.position.y > collision.transform.position.y)
            {
                IsCollision = true;
                CollisionTrans = collision.transform.position;
                CollisionTransY = Vector3.up;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out");
        if (collision.tag == "CheckCode")
        {
            Des = true;
        }
        if (collision.tag == "Codes")
        {
            IsCollision = false;
        }
    }



    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag0");
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("statr");
    }
}
