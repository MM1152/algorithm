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
public class Data
{
    public ZIP[] results;
}

[Serializable]
public class PlayData
{
    public int id;
    public string input;
    public string output;
    public int boolean;
    public int cccc_id;
    public int value;
}

[Serializable]
public class PlayDatas
{
    public PlayData[] results;
}
