using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IF : Codes
{
    private char Operator;
    [SerializeField]
    private GameObject child; // if EndPoint
    public bool canCodeRun;
    private void Awake()
    {
        init();
    }
    private void OnLevelWasLoaded(int level)
    {
        init();
    }
    
    private void FixedUpdate()
    {
        if (isTrue)
        {
            player.Move(player.valueBox.transform);
        }
    }
    
    
    public override void checkCode()
    {
        value = this.gameObject.transform.Find("Value1").Find("calcu").GetComponent<Text>().text;
        Operator = this.gameObject.transform.Find("Value").Find("calcu").GetComponent<Text>().text[0];
        isTrue = true;
        player.SetValueBox(values.transform.Find(value.ToString()).gameObject);
    }
    public override bool WaitTime()
    {
        if(Vector3.Distance(player.transform.position, player.valueBox.transform.position) < 0.4f)
        {
            if(!checkIF(values.transform.Find(value.ToString()).gameObject, int.Parse(player.transform.Find("Box(Clone)").Find("Canvas").Find("Text (Legacy)").GetComponent<Text>().text), Operator))
            {
                int sbling = child.transform.GetSiblingIndex();
                check.Seti(sbling);
            }

            isTrue = false;
            return true;
        }else
        {
            return false;   
        }
        
    }
    public void setChild(GameObject child)
    {
        this.child = child;
    }
    private bool checkIF(GameObject value , int values , char Operator)
    {
        Debug.Log($"{value} {values} {Operator}");
        if(Operator == '>')
        {
            
            if (value.transform.Find("Box(Clone)") && (values > int.Parse(value.transform.Find("Box(Clone)").transform.Find("Canvas").transform.Find("Text (Legacy)").GetComponent<Text>().text)))
            {
                Debug.Log("IN");
                return true;
            }
        }
        else if (Operator == '<')
        {
            if (value.transform.Find("Box(Clone)") && (values < int.Parse(value.transform.Find("Box(Clone)").transform.Find("Canvas").transform.Find("Text (Legacy)").GetComponent<Text>().text)))
            {
                return true;
            }
        }
        else if (Operator == '=')
        {
            if (value.transform.Find("Box(Clone)") && (values == int.Parse(value.transform.Find("Box(Clone)").transform.Find("Canvas").transform.Find("Text (Legacy)").GetComponent<Text>().text)))
            {
                return true;
            }
        }

        return false;
    }
    IEnumerator Wait()
    {
        canCodeRun = false;
        yield return new WaitForSeconds(0.08f);
        canCodeRun = true;
    }
}
