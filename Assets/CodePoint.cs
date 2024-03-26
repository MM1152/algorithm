using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodePoint : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    private CheckCode checkcode;
    private void Awake()
    {
        checkcode = GameObject.Find("CheckCode").GetComponent<CheckCode>();
    }
    private void OnLevelWasLoaded(int level)
    {
        if(GameObject.FindGameObjectsWithTag("CodePoint").Length >= 2)
        {
            Destroy(GameObject.FindGameObjectsWithTag("CodePoint")[0].gameObject);
        }
        parent = GameObject.Find("Main").gameObject;
        checkcode = GameObject.Find("CheckCode").GetComponent<CheckCode>();
        this.gameObject.transform.SetParent(parent.transform);
        
    }
    private void Update()
    {
        if (checkcode.code != null)
        {
            this.gameObject.transform.SetParent(checkcode.code.transform);
            this.gameObject.transform.localPosition = new Vector3(-150f, 0f);
        }
    }
}
