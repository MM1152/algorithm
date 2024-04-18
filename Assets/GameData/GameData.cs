using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData" , menuName = "Scriptable Object/Game Data" , order = int.MaxValue)]
public class GameData : ScriptableObject
{
    public int[] inputData;
    public int[] outputData;
    public int valueData;
    public bool[] codeData = new bool[9];
}
