using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public GameObject PickUp;
    public GameObject PickOff;
    public bool isMouseUse = false;
    public int count;

    private void Awake()
    {
        count = 0;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            isMouseUse = true;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity , LayerMask.GetMask("Boxobj")) ;
            if (Input.GetMouseButton(0) && hit.collider != null)
            {
                Debug.Log(hit.collider.name);
               if(hit.collider.name == "Box Pick Up")
                {
                    GameObject prefeb = Instantiate(PickUp) as GameObject;
                    prefeb.transform.position = hit.collider.transform.position;
                    prefeb.name = "Asd";
                }
                if (hit.collider.name == "Box Pick Off")
                {
                    GameObject prefeb = Instantiate(PickOff) as GameObject;
                    prefeb.transform.position = hit.collider.transform.position;
                    prefeb.name = $"PickOff{count++}";
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseUse = false;
        }
    }
}
