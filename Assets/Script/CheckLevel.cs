using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour
{
    public GameManager gameManager;
    public Text text;

    public string check_Level;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (this.gameObject.activeInHierarchy == true)
        {
            switch (check_Level)
            {
                case "1":
                    text.text = "Chapter1. 박스 옮기기";
                    break;
                case "1_1":
                    text.text = "Chapter1_1. 점프를 통한 반복";
                    break;
                case "1_2":
                    text.text = "Chapter1_2. 최솟값 가져오기";
                    break;
            }
            StartCoroutine(Wait());

        }


    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
