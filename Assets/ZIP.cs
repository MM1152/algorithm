using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZIP
{ 
        public int id;
        public string title;
        public string created_date;
        public string bbbb_id;
}
[Serializable]
public class CustuomMapData
{
    public int[] Custom_inputData;
    public int[] Custom_outputData;
    public int Custom_value;
    public bool[] Custom_codes;
}
[Serializable]
public class Data
{
    public ZIP[] results;
}
