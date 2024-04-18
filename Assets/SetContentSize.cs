using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetContentSize : MonoBehaviour
{
    private RectTransform rectTransform;
   
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        float childRect = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < this.gameObject.transform.GetChild(0).childCount; i++) {
            rectTransform.sizeDelta += new Vector2(0f, childRect);
        }
    }
}
