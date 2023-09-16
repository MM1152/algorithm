using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtoinClickEvenet : MonoBehaviour
{
    public CheckCode check;
    public void OnclickEvenet()
    {
        check.checkCode();
    }
}
