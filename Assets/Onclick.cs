using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Onclick : MonoBehaviour , IPointerClickHandler
{
    public GameObject prefebs;
    GameObject prefeb;
    public int count;
    private void Awake()
    {
        count = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity, LayerMask.GetMask("Boxobj"));
        if (hit.collider != null)
        {
            prefeb = Instantiate(prefebs , transform.parent) as GameObject;
           
        }
    }
}
