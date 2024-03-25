using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public GameObject inputFieldPrefab; // 인풋 필드 프리팹
    public Transform contentPanel; // 인풋 필드를 추가할 팝업 창의 컨텐트 패널
    public float inputFieldXPosition = -49.8f; // 인풋 필드의 x 위치
    public float initialInputFieldYPosition = 52.0f; // 첫 번째 인풋 필드의 y 위치
    public float verticalSpacing = 20.0f; // 인풋 필드 간의 수직 간격

    private float lastInputFieldYPosition; // 이전 인풋 필드의 y 위치

    // 초기화
    void Start()
    {
        lastInputFieldYPosition = initialInputFieldYPosition;
    }

    // 버튼 클릭 이벤트 핸들러
    public void OnButtonClick()
    {
        // 인풋 필드 생성
        GameObject newInputField = Instantiate(inputFieldPrefab, contentPanel);
        RectTransform newInputFieldRectTransform = newInputField.GetComponent<RectTransform>();

        // 새로운 인풋 필드의 위치 설정
        float newInputFieldYPosition = lastInputFieldYPosition - verticalSpacing;
        newInputFieldRectTransform.anchoredPosition = new Vector2(inputFieldXPosition, newInputFieldYPosition);

        // 이전 인풋 필드의 위치 업데이트
        lastInputFieldYPosition = newInputFieldYPosition;
    }
}
