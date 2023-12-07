using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CustomClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] prefebs;
    public GameObject Canvas;

    GameObject prefeb;
    public int count;
    private void Awake()
    {
        Canvas = GameObject.FindWithTag("Code").gameObject;
        count = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity, LayerMask.GetMask("Boxobj"));
        if (hit.collider != null)
        {
            prefeb = Instantiate(prefebs[0], Canvas.transform) as GameObject;

            gameObject.SetActive(false);

            if (hit.collider.name == "Jump")
            {
                prefeb.name = "jump" + count;
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
                prefeb.name = "jump" + count++;
                prefeb.GetComponent<Image>().color = new Color(1f, 0f, 0, 1f);
            }
            if (hit.collider.name == "IF")
            {
                prefeb.name = "if" + count;
                prefeb = Instantiate(prefebs[1], Canvas.transform) as GameObject;
                prefeb.name = "if" + count++;
                prefeb.GetComponent<Image>().color = new Color(0.7f, 0.3f, 1, 1);
            }


        }
    }
}
