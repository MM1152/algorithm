using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseVideo : MonoBehaviour
{
    private Text text;
    public GameObject Tutorial;
    public GameObject UGUI;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }
    public void checkword()
    {
        if(text.text == "닫기")
        {
            Tutorial.SetActive(false);   
        }
    }
}
