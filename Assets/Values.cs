using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Values : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> valuse;
    private RectTransform rect;
    public GameObject valuesName;
    private void Awake()
    {
        
        rect = GetComponent<RectTransform>();
        
        for (int i = 0; i < GameObject.FindWithTag("Value").transform.childCount; i++)
        {
            rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
            valuse.Add(GameObject.FindWithTag("Value").transform.GetChild(i).gameObject);
            GameObject prefeb = Instantiate(valuesName, transform) as GameObject;
            prefeb.transform.GetChild(0).GetComponent<Text>().text = valuse[i].name;
        }
    }


    
}
