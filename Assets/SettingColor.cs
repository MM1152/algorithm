using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingColor : MonoBehaviour
{
    private SetColor setColor = new SetColor();

    private void Awake()
    {
        this.gameObject.GetComponent<Text>().color = setColor.setColor();
    }
}
