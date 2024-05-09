using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class calcu : Codes
{
    public char operate;
    private void Awake()
    {
        init();
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
    }
    private void LateUpdate()
    {
        if (isTrue)
        {
            player.Move(player.valueBox.transform);
        }

    }
    public override void checkCode()
    {
        value = this.gameObject.transform.Find("cal Value").Find("ValuesName").GetComponent<Text>().text[0];
        operate = this.gameObject.transform.GetChild(2).Find("ValuesName").GetComponent<Text>().text[0];
        isTrue = true;
        player.setIsCal(true);
        player.SetValueBox(values.transform.Find(value.ToString()).gameObject);

    }
    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, player.valueBox.transform.position) < 0.2f)
        {
            isTrue = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public int calu(int count)
    { 
        switch (operate)
        {
            case '+':
                count += int.Parse(player.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text);
                break;
            case '-':
                count -= int.Parse(player.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text);
                break;
            case '*':
                count *= int.Parse(player.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text);
                break;
            case '/':
                count /= int.Parse(player.transform.Find("Box(Clone)").GetChild(0).GetChild(0).GetComponent<Text>().text);
                break;
        }
        return count;
    }
}
