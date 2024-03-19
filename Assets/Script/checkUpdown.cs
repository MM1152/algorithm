using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkUpdown : MonoBehaviour
{
    public bool up;
    public bool down;
    public BoxCollider2D[] box;
    private void Start()
    {
        up = false;
        down = false;
        box = GetComponents<BoxCollider2D>();
    }
    public string Up_down()
    {
        if (up)
        {
            return "up";
        }else if (down)
        {
            return "down";
        }
        return "false";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Draging")
        {
            if(collision.transform.position.y > 0)
            {
                up = true;
            }else
            {
                down = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Draging")
        {
            up = false;
            down = false;
        }
    }
}
