using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{
    public List<Animator> BeltAni;
    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            BeltAni.Add(transform.GetChild(i).GetComponent<Animator>());
        }   
    }
    public void BeltMove()
    {
        for(int i = 0; i < BeltAni.Count; i++)
        {
            BeltAni[i].SetBool("IsBeltMove" , true);
        }
    }
    public void BeltStop()
    {
        for (int i = 0; i < BeltAni.Count; i++)
        {
            BeltAni[i].SetBool("IsBeltMove", false);
        }
    }
}
