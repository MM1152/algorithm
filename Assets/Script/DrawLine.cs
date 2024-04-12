using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private onDrag ondrag;
    private LineRenderer line;
    private Vector2 startPos, endPos;
    public int lineCount;
    // Start is called before the first frame update
    void Start()
    {
        ondrag = GetComponent<onDrag>();
        line = GetComponent<LineRenderer>();
        line.positionCount = lineCount;    
    }

    private void Update()
    {
        endPos = Camera.main.ScreenToWorldPoint(this.ondrag.Child.transform.position);
        startPos = Camera.main.ScreenToWorldPoint(transform.position);
        endPos = Camera.main.ScreenToWorldPoint(this.ondrag.Child.transform.position);
        DrawBezier();
    }
    public Vector3 Bezier(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t)
    {
        Vector3 M0 = Vector3.Lerp(P0, P1, t);
        Vector3 M1 = Vector3.Lerp(P1, P2, t);
        Vector3 M2 = Vector3.Lerp(P2, P3, t);

        Vector3 B0 = Vector3.Lerp(M0, M1, t);
        Vector3 B1 = Vector3.Lerp(M1, M2, t);

        return Vector3.Lerp(B0, B1, t);
    }
    public void DrawBezier()
    {

        for (int i = 0; i < line.positionCount; i++)
        {
            float t;
            if (i == 0)
            {
                t = 0;
            }
            else
            {
                t = (float)i / (line.positionCount - 1);
            }

            Vector3 bezier = Bezier(startPos, startPos + new Vector2(-3f , 0), endPos + new Vector2(-3f, 0), endPos  , t); ;


            line.SetPosition(i, bezier); // 라인을 설정합니다
        }
    }
}




