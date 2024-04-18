using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateValueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject varPrefeb;
    [SerializeField]
    private Transform Viewport;
    private void Awake()
    {
        Viewport = GameObject.Find("Layout").transform.Find("Value Scroll").transform.GetChild(0).GetChild(0).GetComponent<Transform>();
    }
    public void CreateBox()
    {
        Instantiate(varPrefeb , Viewport);
    }
}
