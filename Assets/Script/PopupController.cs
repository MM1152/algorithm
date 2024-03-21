using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popup; // 팝업창 게임 오브젝트에 대한 레퍼런스

    void Start()
    {
        // 초기에는 팝업창을 비활성화
        popup.SetActive(false);
    }

    // 버튼 클릭 이벤트 핸들러
    public void OnButtonClick()
    {
        // 팝업창을 활성화
        popup.SetActive(true);
    }

    // 팝업창의 닫기 버튼에 연결될 메서드
    public void ClosePopup()
    {
        // 팝업창을 비활성화
        popup.SetActive(false);
    }
}
