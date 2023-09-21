using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
}
