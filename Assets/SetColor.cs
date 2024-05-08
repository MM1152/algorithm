using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor
{
    private Color[] colors = { Color.red , Color.red , Color.yellow, Color.yellow,  Color.white, Color.white, Color.black, Color.black, Color.green , Color.green };
    private static int count = -1;
    
    public Color setColor()
    {
        count++;
        if (count == colors.Length)
        {
            count = 0;
        }
        return colors[count];
    }
}
