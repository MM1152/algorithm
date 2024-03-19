using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupWindow; // 팝업 창 오브젝트를 연결할 변수

    void Start()
    {
        // 버튼 클릭 시 처리할 함수를 연결
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenPopup);
    }

    // 팝업 창을 열기 위한 함수
    void OpenPopup()
    {
        // 팝업 창을 활성화하여 띄웁니다.
        popupWindow.SetActive(true);
    }
}
