using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputBelt : MonoBehaviour
{
    public GameObject Box;
    public int rand;
    private float boxtransY;
    public List<int> doubleCheck;
    private void Start()
    {
        doubleCheck = new List<int>();
        boxtransY = 0f;
        for (int i = 0; i < 30; i++)
        {
            
            rand = Random.Range(1, 50);
            if (!doubleCheck.Contains(rand))
            {
                doubleCheck.Add(rand);
                GameObject prefeb = Instantiate(Box, transform) as GameObject;
                prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + rand;
                prefeb.transform.position += Vector3.down * boxtransY;
                boxtransY += 1f;
            }else
            {
                i--;
            }
            
        }
        
    }
}
