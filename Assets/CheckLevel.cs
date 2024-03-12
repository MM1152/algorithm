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
        check_Level = gameManager.Level;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (this.gameObject.activeInHierarchy == true)
        {
            switch (check_Level)
            {
                case "1":
                    text.text = "Chapter1. �ڽ� �ű��";
                    break;
                case "1_1":
                    text.text = "Chapter1_1. ������ ���� �ݺ�";
                    break;
                case "1_2":
                    text.text = "Chapter1_2. �ּڰ� ��������";
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
