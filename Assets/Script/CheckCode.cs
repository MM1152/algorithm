using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCode : MonoBehaviour
{
    List<GameObject> codes;
    private void Start()
    {
        codes = new List<GameObject>();

    }
    public void checkCode()
    {
        Debug.Log("Button");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
