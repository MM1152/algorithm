using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public int count = 0;
    public float sum = 0.2f;
    public void Move(Transform target)
    {

        transform.position += (target.position - transform.position).normalized * Time.deltaTime * 5f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "InputBelt")
        {
            collision.transform.GetChild(0).gameObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        if (collision.name == "OutputBelt")
        {
            gameObject.transform.GetChild(0).transform.SetParent(collision.gameObject.transform);
           
            collision.gameObject.transform.GetChild(count++).transform.localPosition = new Vector3(0f, -0.4f + sum, 0f);
            sum += 0.2f;
        }
    }
}
