using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer line;
    public Transform startPos, endPos;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.positionCount = i;
        Debug.DrawRay(Vector3.zero , new Vector3(-240 , -45) , Color.red);
        for(int i = 0; i < line.positionCount; i++)
        {
            Vector3 point = Vector3.Slerp(startPos.position, endPos.position, i / (float)(line.positionCount - 1));
            line.SetPosition(i, point);
        }
    }

}
