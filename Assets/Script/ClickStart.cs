using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClickStart : MonoBehaviour
{
    public CheckCode check;
    public GameObject answer;
    public void StartButton()
    {
        check.checkCode(); 
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlusButton()
    {
        answer.SetActive(!answer.activeSelf);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Custom");
    }
    public void BackCustomMap()
    {
        SceneManager.LoadScene("NewCustom");
    }

}
