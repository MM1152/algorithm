using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public MouseDrag mouse;
    public GameObject PickUp;
    public GameObject PickOff;
    public bool isMouseUse = false;
    public int count;

    private void Awake()
    {
        count = 0;

    }
    void Update()
    {

    }

    
}
