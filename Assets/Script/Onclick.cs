using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Onclick : MonoBehaviour , IPointerClickHandler
{
    public GameObject[] prefebs; 
    public GameObject Canvas;
    public onDrag onDrag;
    public GameObject prefeb;
    public int count;
    public GameObject Draw;
    private void Awake()
    {
        Canvas = GameObject.FindWithTag("Content").gameObject;
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
                Draw = prefeb;
                prefeb.name = "jump" + count;
                onDrag = prefeb.GetComponent<onDrag>();
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
                prefeb.name = "jump" + count++;
                onDrag.SetChild(prefeb);
                prefeb.GetComponent<EndPoint>().SetParent(Draw , Draw.GetComponent<Jump>().GetType());
                prefeb.GetComponent<Image>().color = new Color(1f, 0f, 0, 1f);
            }
            if (hit.collider.name == "IF")
            {
                prefeb.name = "if" + count;
                GameObject parentGameObj = prefeb;
                onDrag = prefeb.GetComponent<onDrag>();
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
                parentGameObj.GetComponent<IF>().setChild(prefeb);
                prefeb.name = "if" + count++;
                onDrag.SetChild(prefeb);
                
                prefeb.GetComponent<Image>().color = new Color(0.7f, 0.3f, 1, 1); 
            }
            if(hit.collider.name == "IFJump")
            {
                Draw = prefeb;
                prefeb.name = "IFJump" + count;
                onDrag = prefeb.GetComponent<onDrag>();
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
                prefeb.name = "IFJump" + count++;
                onDrag.SetChild(prefeb);
                prefeb.GetComponent<EndPoint>().SetParent(Draw, Draw.GetComponent<IFJUMP>().GetType());
                prefeb.GetComponent<Image>().color = new Color(1f, 0f, 0, 1f);
            }
            
            
        }
    }
}
