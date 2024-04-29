using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showAnswer : MonoBehaviour
{
    [SerializeField]
    private outBelt answer;
    [SerializeField]
    private GameObject box;
   
    void Start()
    {
        answer = GameObject.Find("Main").transform.Find("OutputBelt").GetComponent<outBelt>();
        while (answer.SetOutputData.Count == 0) ;
        
        for(int i = 0; i < answer.SetOutputDataLength; i++)
        {
            GameObject prefeb = Instantiate(box , this.gameObject.transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = answer.SetOutputData[i].ToString();
            prefeb.transform.localPosition = new Vector3(0, -i);
            prefeb.transform.localScale = new Vector3(0.7f, 0.7f);
            prefeb.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0.7f);
        }

        this.gameObject.SetActive(false);
    }
    
}
