using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputBelt : MonoBehaviour
{
    public GameObject Box;
    public int rand;
    private float boxtransY;
    private void Start()
    {
        boxtransY = 0f;
        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(1, 8);
            GameObject prefeb = Instantiate(Box, transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + rand;
            prefeb.transform.position += Vector3.down * boxtransY;
            boxtransY += 1f;
        }
        
    }
}
