using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInCode : MonoBehaviour
{
    public GameObject inside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Codes")
        {
            inside = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            inside = null;
        }
    }
}
