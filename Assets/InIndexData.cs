using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InIndexData : MonoBehaviour
{
    private ClickEvenet clickEvent;
    public Text text;
    /*
    private void Awake()
    {
        clickEvent = GetComponent<ClickEvenet>();
        text = gameObject.transform.GetChild(0).GetComponent<Text>();
    }
    private void OnLevelWasLoaded(int level)
    {
        clickEvent = GetComponent<ClickEvenet>();
        text = gameObject.transform.GetChild(0).GetComponent<Text>();
    }
    private void Update()
    {
        if(clickEvent.mouseDragparent != null)
        {
            if (!clickEvent.mouseDrag.isMouseUse && clickEvent.inData)
            {
                text.text = clickEvent.mouseDragparent.transform.GetChild(1).GetComponent<InputField>().text;
            }
        }

    }
    */
}
