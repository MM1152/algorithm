using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour
{
    public CheckCode check;

    public void Clickstart()
    {
        check.checkCode();
    }
}
