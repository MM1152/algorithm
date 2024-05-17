using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValue : MonoBehaviour
{
    public GameObject button;
    public int count = 0;
    public void addValue()
    {
        transform.GetChild(count).gameObject.SetActive(true);
        count++;
        if (count < transform.childCount) button.transform.position = Camera.main.WorldToScreenPoint(transform.GetChild(count).transform.position);
        else
        {
            button.SetActive(false);
        }
    }
}
