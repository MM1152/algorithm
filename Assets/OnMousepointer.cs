using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OnMousepointer : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerClickHandler
{
    public List<GameObject> SelectBox;
    public static string selectValue;
    public ClickEvenet clickEvent;
    RaycastHit2D hit;
    private void Start()
    {
        selectValue = " ";
        SelectBox = new List<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            SelectBox.Add(gameObject.transform.GetChild(i + 1).gameObject);
            SelectBox[i].SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

            if (ClickEvenet._this.GetComponent<ClickEvenet>().valueSelect)
            {
                for (int i = 0; i < SelectBox.Count; i++)
                {
                    SelectBox[i].SetActive(true);
                }
            }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

            if (ClickEvenet._this.GetComponent<ClickEvenet>().valueSelect)
            {
                for (int i = 0; i < SelectBox.Count; i++)
                {
                    SelectBox[i].SetActive(false);
                }
            }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity, LayerMask.GetMask("Value"));
       
        if(hit.collider != null && ClickEvenet._this.GetComponent<ClickEvenet>().valueSelect)  
        {
            selectValue = hit.collider.gameObject.name;
            ClickEvenet._this.GetComponent<ClickEvenet>().valueSelect = false;
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(false);
            }
            ClickEvenet._this.GetComponent<ClickEvenet>().setValueText();
        }
        else
        {
            ClickEvenet._this.GetComponent<ClickEvenet>().valueSelect = false;
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(false);
            }

        }

    }
}
