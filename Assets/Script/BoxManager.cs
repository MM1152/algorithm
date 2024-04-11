using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    public InputField inputField; // 각 박스의 인풋 필드
    public GameManager gameManager; // 해당하는 게임 매니저

    public int index; // 게임 매니저의 변수를 식별하기 위한 인덱스

    private void Start()
    {
        // 인풋 필드에 대한 이벤트 핸들러를 등록합니다.
        inputField.onEndEdit.AddListener(delegate { OnInputFieldValueChanged(); });
    }

    private void OnInputFieldValueChanged()
    {
        // 인풋 필드의 값을 읽어와서 해당하는 게임 매니저의 변수를 변경합니다.
        int newValue = int.Parse(inputField.text);
        gameManager.SetVariable(index, newValue);
    }
}
