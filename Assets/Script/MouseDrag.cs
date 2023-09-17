using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public GameObject PickUp;
    public GameObject PickOff;
    public bool isMouseUse = false;

    private void Awake()
    {
        

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            isMouseUse = true;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity , LayerMask.GetMask("Boxobj")) ;
            if (Input.GetMouseButton(0) && hit.collider != null)
            {
               if(hit.collider.name == "Box Pick Up")
                {
                    GameObject prefeb = Instantiate(PickUp);
                    prefeb.transform.position = hit.collider.transform.position;
                }
                if (hit.collider.name == "Box Pick Off")
                {
                    GameObject prefeb = Instantiate(PickOff);
                    prefeb.transform.position = hit.collider.transform.position;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseUse = false;
        }
    }
}
