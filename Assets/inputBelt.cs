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
        for (int i = 0; i < 30; i++)
        {
<<<<<<< HEAD
            
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
            
=======
            rand = Random.Range(1, 8);
            GameObject prefeb = Instantiate(Box, transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + rand;
            prefeb.transform.position += Vector3.down * boxtransY;
            boxtransY += 1f;
>>>>>>> 587c4af01ff763055f98b3ec6e59f411ef7c4aa7
        }
        
    }
}
