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
        if(gameObject.name == "values")
        {
            for (int i = 0; i < GameObject.FindWithTag("Value").transform.childCount; i++)
            {
                if(GameObject.FindWithTag("Value").transform.GetChild(i).gameObject.activeInHierarchy == true)
                {
                    rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
                    valuse.Add(GameObject.FindWithTag("Value").transform.GetChild(i).gameObject);
                    GameObject prefeb = Instantiate(valuesName, transform) as GameObject;
                    prefeb.transform.GetChild(0).GetComponent<Text>().text = valuse[i].name;
                }
                
            }
        }
        if(gameObject.name == "IFvalues")
        {
            char[] calcu = {'<' , '>' };
            for (int i = 0; i < 2; i++)
            {
                rect.sizeDelta = new Vector3(rect.rect.width, rect.rect.height + 65f, 0f);
                GameObject prefeb = Instantiate(valuesName, transform) as GameObject;
                prefeb.transform.GetChild(0).GetComponent<Text>().text = "" + calcu[i];
            }
        }
        
    }


    
}
