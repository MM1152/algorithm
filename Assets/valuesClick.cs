using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class valuesClick : MonoBehaviour , IPointerClickHandler 
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("in");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.parent.parent.GetChild(0).GetComponent<Text>().text = transform.GetChild(0).GetComponent<Text>().text;
            transform.parent.gameObject.SetActive(false);
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
