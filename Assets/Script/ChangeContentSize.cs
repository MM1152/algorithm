using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeContentSize : MonoBehaviour
{
    public RectTransform rect;
    public int childcount;
    public int click;
    public Dictionary<int , int> clickCount = new Dictionary<int , int>();
    // Start is called before the first frame update
    void Start()
    {
        childcount = gameObject.transform.childCount;
        rect = GetComponent<RectTransform>();
        
        click = 1;
        clickCount.Add(0, click);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(checkChildYsize());
    }
    public int setClickCount(GameObject sibling)
    {
        int count = 1;
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.layer == 9)
            {
                continue;
            }
            if(sibling == transform.GetChild(i).gameObject)
            { 
                return count;
            }
            count++;
        }
        return 0;
    }
    IEnumerator checkChildYsize()
    {

        yield return new WaitForEndOfFrame();

        if (childcount != transform.childCount)
        {

            rect.sizeDelta = Vector2.zero;
            rect.anchoredPosition = Vector2.zero;
            childcount = gameObject.transform.childCount;

            for (int i = 0; i < childcount; i++)
            {
                rect.sizeDelta += new Vector2(0f, gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height * gameObject.transform.GetChild(i).GetComponent<RectTransform>().localScale.y + 10f);
                rect.anchoredPosition += new Vector2(0f, (gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height * gameObject.transform.GetChild(i).GetComponent<RectTransform>().localScale.y) + 10f);
            }

           
            
            /*if (childcount < transform.childCount)
            {
                clickCount++;
                rect.sizeDelta = Vector2.zero;
                rect.anchoredPosition = Vector2.zero;
                childcount = gameObject.transform.childCount;
                for (int i = 0; i < childcount; i++)
                {
                    rect.sizeDelta += new Vector2(0f, (gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height * gameObject.transform.GetChild(i).GetComponent<RectTransform>().localScale.y) + 10f);
                    rect.anchoredPosition += new Vector2(0f, (gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height * gameObject.transform.GetChild(i).GetComponent<RectTransform>().localScale.y) + 10f);
                }
                
            }
            else if(childcount > transform.childCount)
            {
                clickCount--;
                rect.sizeDelta = Vector2.zero;
                rect.anchoredPosition = Vector2.zero;
                childcount = gameObject.transform.childCount;
                for (int i = 0; i < childcount; i++)
                {
                    rect.sizeDelta += new Vector2(0f, gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height);
                }
            }  */
        }
    }
    
}
