using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SetCodeSiblingText : MonoBehaviour
{
    public int parentSibling;
    public Text CodeSibling;
    public GameObject parent;

    public ChangeContentSize changeContentSize;
    private void Awake()
    {
        setParent();
    }
    private void OnLevelWasLoaded(int level)
    {
        setParent();
    }
    private void Update()
    {
        if(parent.tag == "Draging")
        {
            CodeSibling.text = "";
        }
        parentSibling = parent.transform.GetSiblingIndex();
        if(changeContentSize != null)
        {
            CodeSibling.text = changeContentSize.setClickCount(parent).ToString();
            
        }
    }
    
    private void setParent()
    {
        parent = gameObject.transform.parent.gameObject;
        changeContentSize = parent.transform.parent.GetComponent<ChangeContentSize>();
    }
}
