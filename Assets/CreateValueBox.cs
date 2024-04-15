using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateValueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject varPrefeb;
    [SerializeField]
    private Transform Viewport;

    public void CreateBox()
    {
        Instantiate(varPrefeb , Viewport);
    }
}
