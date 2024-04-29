using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 다음 씬의 이름을 설정
    public string nextSceneName = "StartScene";
    private void Update()
    {
        // 엔터 키를 누르면 다음 씬으로 이동
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            SwitchToNextScene();
        }
    }

    // 다음 씬으로 이동하는 함수
    public void SwitchToNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("다음 씬의 이름이 설정되지 않았습니다.");
        }
    }
}
