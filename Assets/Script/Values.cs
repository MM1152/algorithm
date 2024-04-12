using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Values : MonoBehaviour
{
    private RectTransform rect;
    public GameObject valuesName;
    private void Awake()
    {
        
        rect = GetComponent<RectTransform>();
        if(gameObject.name == "IFvalues")
        {
            char[] calcu = {'=' , '<' , '>' };
            for (int i = 0; i < 3; i++)
            {
                rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
                GameObject prefeb = Instantiate(valuesName, transform) as GameObject;
                prefeb.transform.GetChild(0).GetComponent<Text>().text = "" + calcu[i];
            }
        }
        if (gameObject.name == "Varvalues")
        {
            char[] calcu = {'+' , '-'};
            for (int i = 0; i < 2; i++)
            {
                rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
                GameObject prefeb = Instantiate(valuesName, transform) as GameObject;
                prefeb.transform.GetChild(0).GetComponent<Text>().text = "" + calcu[i];
            }
        }
    }


    
}
