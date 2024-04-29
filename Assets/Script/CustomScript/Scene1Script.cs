using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Scene1Script : MonoBehaviour
{
    private InputFieldController inputFieldController;
    private GameManager gameManager;

    private void Start()
    {
        inputFieldController = FindObjectOfType<InputFieldController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SendListToNextScene()
    {
        // InputFieldController에서 inputnumbersList와 outputnumbersList 가져오기
        List<int> inputnumbersList = inputFieldController.GetInputnumbersList();
        List<int> outputnumbersList = inputFieldController.GetOutputnumbersList();
     
        // GameManager에 리스트들 전달
        gameManager.ProcessLists(inputnumbersList, outputnumbersList);

        // 다음 씬으로 전환
        SceneManager.LoadScene("NewMainScene");
    }
}
