using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armposition : MonoBehaviour
{
    public Transform armPos;
    void Start()
    {
        armPos = gameObject.transform;
    }
    
    public void SetArmPos()
    {
        gameObject.transform.position = armPos.position;
    }
}
