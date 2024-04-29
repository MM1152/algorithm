using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hideBackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!(SceneManager.GetActiveScene().name == "Custom"))
        {
            this.gameObject.SetActive(false);
        }   
    }


}
