using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private onDrag ondrag;
    private LineRenderer line;
    private Vector2 startPos, endPos;
    public int i;
    // Debug.Log(Camera.main.ScreenToWorldPoint(transform.position)); 써서 좌표 구할 수 있음
    // Start is called before the first frame update
    void Start()
    {
        ondrag = GetComponent<onDrag>();
        line = GetComponent<LineRenderer>();
        startPos = Camera.main.ScreenToWorldPoint(transform.position);
        endPos = Camera.main.ScreenToWorldPoint(this.ondrag.Child.transform.position);
    }



}
