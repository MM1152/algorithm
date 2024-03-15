using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OnMousepointer : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerClickHandler
{
    public List<GameObject> SelectBox;
    public static string selectValue;
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
        if (ClickEvenet.valueSelect)
        {
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(true);
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ClickEvenet.valueSelect)
        {
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(false);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity, LayerMask.GetMask("Value"));

        if(hit.collider != null)
        {
            selectValue = hit.collider.gameObject.name;
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(false);
            }
        }
        else
        {
            ClickEvenet.valueSelect = false;
            for (int i = 0; i < SelectBox.Count; i++)
            {
                SelectBox[i].SetActive(false);
            }
        }
    }
}
