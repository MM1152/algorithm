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
        
    }

}
