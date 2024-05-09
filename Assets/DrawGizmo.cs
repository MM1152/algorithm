using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private GameObject connection;
    [SerializeField]
    private GameObject mouseDragObj;
    private MouseDrag mouseDrag;
    private List<Vector3> pointList = new List<Vector3>();
    public int setPosition;

    public Vector3 startPoint;
    public Vector3 middlePoint_A;


    public Vector3 middlePoint_B;
    public Vector3 endPoint;

    public float vertexCount = 12;
    public void Start()
    {
        mouseDrag = GetComponent<MouseDrag>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    public void setConnection(GameObject connection)
    {
        this.connection = connection; 
    }
    public void Update()
    {
        if(connection != null && !MouseDrag.isMouseUse)
        {
            endPoint = Camera.main.ScreenToWorldPoint(connection.transform.position) + Vector3.back * -10f;
            DrawLine();
        } 
        else if(connection == null)
        {
            lineRenderer.positionCount = 0;
        }

        if (MouseDrag.isMouseUse &&  mouseDragObj == null)
        {
            mouseDragObj = GetComponent<MouseDrag>().copyValue.gameObject;
        }
        if (!MouseDrag.isMouseUse && mouseDragObj != null)
        {
            mouseDragObj = null;
        }

        startPoint = Camera.main.ScreenToWorldPoint(this.gameObject.transform.position) + Vector3.back * -10f;
        middlePoint_A = startPoint + Vector3.right * 2f;

        middlePoint_B = endPoint + Vector3.left * 2f;


        Vector3 middlePoint = Vector3.Lerp(middlePoint_A, middlePoint_B, 0.5f);



        for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
        {
            var tangent1 = Vector3.Lerp(startPoint, middlePoint_A, ratio);
            var tangent2 = Vector3.Lerp(middlePoint_A, middlePoint, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);

            pointList.Add(curve);
        }

        pointList.RemoveAt(pointList.Count - 1);

        for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
        {
            var tangent1 = Vector3.Lerp(middlePoint, middlePoint_B, ratio);
            var tangent2 = Vector3.Lerp(middlePoint_B, endPoint, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);

            pointList.Add(curve);
        }

        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());


    }
    void DrawLine()
    {

    }
}

