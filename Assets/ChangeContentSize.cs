using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeContentSize : MonoBehaviour
{
    public RectTransform rect;
    public BoxCollider2D[] up_down;
    public checkUpdown checkupdown;
    
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        up_down = new BoxCollider2D[2];
        up_down = GetComponents<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rect.sizeDelta = new Vector2(0f, gameObject.transform.childCount * 100f);
        if (checkupdown.Up_down() != "false")
        {
            if(checkupdown.Up_down() == "up")
            {
                rect.anchoredPosition += new Vector2(0f, -20f);
            }else if(checkupdown.Up_down() == "down")
            {
                rect.anchoredPosition += new Vector2(0f, +20f);
            }
        }
    }


        
    
}
