using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputFieldController : MonoBehaviour
{
    public Button saveButton; // 저장 버튼
    public GameObject inputFieldObjectPrefab; // 인풋 필드를 포함한 게임 오브젝트 프리팹

    private List<GameObject> inputFieldObjects = new List<GameObject>(); // 생성된 인풋 필드를 포함한 게임 오브젝트를 저장할 리스트
    private List<int[]> numbersList = new List<int[]>(); // 각각의 인풋 필드에서 입력한 숫자를 저장할 리스트

    private void Start()
    {
        saveButton.onClick.AddListener(SaveToJson); // 저장 버튼에 SaveToJson 메서드를 연결
    }

    // 저장 버튼을 클릭했을 때 호출되는 메서드
    private void SaveToJson()
    {
        // 각각의 인풋 필드에서 입력된 숫자를 배열로 저장하여 리스트에 추가
        foreach (GameObject inputFieldObject in inputFieldObjects)
        {
            InputField inputField = inputFieldObject.GetComponent<InputField>();
            if (inputField != null)
            {
                string[] numberStrings = inputField.text.Split(',');
                List<int> numbers = new List<int>();
                foreach (string str in numberStrings)
                {
                    int number;
                    if (int.TryParse(str, out number))
                    {
                        numbers.Add(number);
                    }
                }
                numbersList.Add(numbers.ToArray());
            }
        }

        // 리스트를 JSON 형식으로 직렬화
        string jsonData = JsonUtility.ToJson(numbersList);

        // 필요한 경우 jsonData를 저장하거나 전송할 수 있습니다.
        Debug.Log("JSON 데이터: " + jsonData);
    }

    // 사용자가 입력한 숫자를 추적하기 위해 각각의 인풋 필드를 추가하는 메서드
    public void AddInputField()
    {
        GameObject newInputFieldObject = Instantiate(inputFieldObjectPrefab, transform);
        inputFieldObjects.Add(newInputFieldObject);
    }
}
