using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Take : Codes
{

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
        player.setIsPaste(true);
        value = this.gameObject.transform.Find("Take Value").Find("ValuesName").GetComponent<Text>().text;
        isTrue = true;
        player.SetValueBox(values.transform.Find(value.ToString()).gameObject);
    }

    public override bool WaitTime()
    {
        if (Vector3.Distance(player.transform.position, player.valueBox.transform.position) < 10f && (player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp") || player.ani.GetCurrentAnimatorStateInfo(0).IsName("PlayerPickUp2")) && player.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            isTrue = false;
            return true;
        }
        else
        {
            return false;
        }
    }


}
