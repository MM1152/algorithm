using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputBelt : MonoBehaviour
{
    public List<int> boxNum; 

    public GameObject Box;
    private float boxtransY;
    private void Start()
    {
        boxtransY = 0f;
        for (int i = 0; i < boxNum.Count; i++)
        {
            GameObject prefeb = Instantiate(Box, transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + boxNum[i];
            prefeb.transform.position += Vector3.down * boxtransY;
            boxtransY += 1f;   
        }
        
    }
}
