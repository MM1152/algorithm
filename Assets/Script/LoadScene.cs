using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity;

public class LoadScene : MonoBehaviour
{
    public GameManager gameManager;
    public Button[] buttons;
    public void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for(int i = 0; i < buttons.Length; i++)
        {
            int temp = i;
            buttons[i].onClick.AddListener(() => OnClick(temp + 1));
        }
    }
    
    void OnClick(int i)
    {
        if (i == 5)
        {
            SceneManager.LoadScene("coustomScene");

        }
        else
        {
            gameManager.Level = i.ToString();
            SceneManager.LoadScene("MainScene");
        }
    }
}
