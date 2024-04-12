using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VarData : MonoBehaviour
{
    private Dictionary<string , int> varValue;

    private InputField name;
    private Text value;
    private Text calcu;
    private InputField count;
    // Start is called before the first frame update
    void Start()
    {
        varValue = new Dictionary<string , int>();
        name = gameObject.transform.Find("InputName").GetComponent<InputField>();
        value = gameObject.transform.Find("Image").Find("num").GetComponent<Text>();
        calcu = gameObject.transform.Find("Value").Find("calcu").GetComponent<Text>();
        count = gameObject.transform.Find("plus").GetComponent<InputField>();
    }


    void Update()
    {
        
        Setting();
    }

    void Setting()
    {
        if(varValue.Count >= 1)
        {
            if (varValue.ContainsKey(name.text))
            {

                if (calcu.text[0].Equals('+'))
                {
                    if (!count.text.Equals(""))
                    {
                        varValue[name.text] = int.Parse(value.text) + int.Parse(count.text);
                    }
                    else
                    {
                        varValue[name.text] = int.Parse(value.text);
                    }

                }
                else if (calcu.text[0].Equals('-'))
                {
                    if (!count.text.Equals(""))
                    {
                        varValue[name.text] = int.Parse(value.text) - int.Parse(count.text);
                    }
                    else
                    {
                        varValue[name.text] = int.Parse(value.text);
                    }
                }

            }
            else if (!varValue.ContainsKey(name.text))
            {
                varValue.Clear();
            }
        }

        if (name.text != null && varValue.Count == 0)
        {
            if (calcu.text[0].Equals('+'))
            {
                if(!count.text.Equals(""))
                {
                    varValue.Add(name.text.ToString(), int.Parse(value.text) + int.Parse(count.text));
                }   
            }
            else if (calcu.text[0].Equals('-'))
            {
                if (!count.text.Equals(""))
                {
                    varValue.Add(name.text, int.Parse(value.text) - int.Parse(count.text));
                }
                else
                {
                    varValue.Add(name.text, int.Parse(value.text));
                }
            }
            else
            {
                varValue.Add(name.text, int.Parse(value.text));
            }

        }
        Debug.Log($"varValue : {varValue[name.text]}");
    }
    public int getVarValue()
    {
        return varValue[name.text];
    }
}
