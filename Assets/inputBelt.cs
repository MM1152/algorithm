using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputBelt : MonoBehaviour
{
    public List<int> boxNum; 
   

    public GameObject Box;


    private float boxinitPos;
    private float boxtransY;
    private void Start()
    {
        boxtransY = 0f;
        boxinitPos = 0.4f;
        for (int i = 0; i < boxNum.Count; i++)
        {
            GameObject prefeb = Instantiate(Box, transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + boxNum[i];
            prefeb.transform.position += Vector3.down * boxtransY;
            boxtransY += 1f;   
        }
        
    }
    private void Update()
    {
        if (gameObject.transform.childCount != 0 && gameObject.transform.GetChild(0).transform.position.y <= 0.3f)
        {
            BoxMove();
        }
           
    }

    private void BoxMove()
    {
        
        
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).transform.Translate(new Vector3(0f , 0.005f , 0f));
              

            }
       
         
    }
}
