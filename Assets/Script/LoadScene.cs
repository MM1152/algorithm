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
            Debug.Log(i);
        }
    }

    void OnClick(int i)
    {
        gameManager.Level = i.ToString();
        SceneManager.LoadScene("MainScene");    
    }
}
