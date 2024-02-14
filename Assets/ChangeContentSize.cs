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
        rect.sizeDelta = new Vector2(0f, gameObject.transform.childCount * 100f);
        SetPos();   
    }

    void SetPos()
    {
        if(childcount != transform.childCount)
        {
            if(childcount > transform.childCount)
            {
                childcount = transform.childCount;
            }
            else if(childcount < transform.childCount)
            {
                rect.anchoredPosition += new Vector2(0f, 200f);
                childcount = transform.childCount;
            }   
            
        }
        
    }

        
    
}
