using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasInCode : MonoBehaviour
{
    
    public GameObject inside;
    public GameObject _this;
    private void Awake()
    {
        var obj = FindObjectsOfType<CanvasInCode>();

        if(obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

    }
    private void OnLevelWasLoaded(int level)
    {
        
        if (!SceneManager.GetActiveScene().name.Equals("MainScene") && !SceneManager.GetActiveScene().name.Equals("NewMainScene"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Codes")
        {
            inside = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Codes")
        {
            inside = null;
        }
    }
}
