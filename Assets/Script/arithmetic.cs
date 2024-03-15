using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arithmetic : MonoBehaviour
{
    public char[] arithmeticValues;
    
    public GameObject ValueName;
    private RectTransform rect;
    void Awake()
    {
        arithmeticValues = new char[4];
        arithmeticValues[0] = '+';
        arithmeticValues[1] = '-';
        arithmeticValues[2] = '*';
        arithmeticValues[3] = '/';
        rect = GetComponent<RectTransform>();
        for(int i = 0; i < arithmeticValues.Length; i++)
        {
            rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
            GameObject prefeb = Instantiate(ValueName, transform) as GameObject;
            prefeb.transform.GetChild(0).GetComponent<Text>().text = arithmeticValues[i].ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
