using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Onclick : MonoBehaviour , IPointerClickHandler
{
    public GameObject[] prefebs; 
    public GameObject Canvas;

    GameObject prefeb;
    public int count;
    private void Awake()
    {
        Canvas = GameObject.FindWithTag("Layout").gameObject;
        count = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity, LayerMask.GetMask("Boxobj"));
        if (hit.collider != null)
        {
            prefeb = Instantiate(prefebs[0] , Canvas.transform) as GameObject;
            if(hit.collider.name == "Jump")
            {
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
            }
            
        }
    }
}
