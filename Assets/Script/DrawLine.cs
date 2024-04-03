using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private onDrag ondrag;
    private LineRenderer line;
    private Transform startPos, endPos;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        ondrag = GetComponent<onDrag>();
        line = GetComponent<LineRenderer>();
        startPos = this.gameObject.transform;
        endPos = this.ondrag.Child.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("showPosition" , 1f);
        
    }
    public void showPosition()
    {
        Debug.Log($"transform : {this.gameObject.transform.position}");
        Debug.Log($"WorldToScreenPoint : {Camera.main.WorldToScreenPoint(this.gameObject.transform.position)}");
        Debug.Log($"WorldToViewportPoint : {Camera.main.WorldToViewportPoint(this.gameObject.transform.position)}");
        Debug.Log($"ScreenToViewportPoint : {Camera.main.ScreenToViewportPoint(this.gameObject.transform.position)}");
        Debug.Log($"ViewportToScreenPoint : {Camera.main.ViewportToScreenPoint(this.gameObject.transform.position)}");
        Debug.Log($"ViewportToWorldPoint : {Camera.main.ViewportToWorldPoint(this.gameObject.transform.position)}");

    }

}
