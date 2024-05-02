using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeContentSize : MonoBehaviour
{
    public RectTransform rect;
    public int childcount;
    // Start is called before the first frame update
    void Start()
    {
        childcount = gameObject.transform.childCount;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        checkChildYsize();
        
    }
    void checkChildYsize()
    {
        if (childcount != transform.childCount)
        {
            if (childcount < transform.childCount)
            {
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
                rect.sizeDelta = Vector2.zero;
                rect.anchoredPosition = Vector2.zero;
                childcount = gameObject.transform.childCount;
                for (int i = 0; i < childcount; i++)
                {
                    rect.sizeDelta += new Vector2(0f, gameObject.transform.GetChild(i).GetComponent<RectTransform>().rect.height);
                }
            }
            
        }

    }
    
    
}
