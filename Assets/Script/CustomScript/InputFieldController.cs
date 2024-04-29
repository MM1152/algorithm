using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputFieldController : MonoBehaviour
{
    private GameObject InputPosition;
    private GameObject OutputPosition;

    public Button saveButton; // 저장 버튼

    public GameObject inputFieldObjectPrefab; // 인풋 필드를 포함한 게임 오브젝트 프리팹
    public GameObject outputFieldObjectPrefab;

    private List<InputField> inputFields = new List<InputField>(); // 생성된 인풋 필드를 저장할 리스트
    private List<InputField> outputFields = new List<InputField>(); // 정답숫자를 입력할 인풋 필드를 저장할 리스트

    private void Start()
    {
        InputPosition = GameObject.Find("InputPosition");
        OutputPosition = GameObject.Find("OutputPosition");

        saveButton.onClick.AddListener(SaveToArray); // 저장 버튼에 SaveToArray 메서드를 연결
    }

    public List<int> GetInputnumbersList()
    {
        List<int> inputnumbersList = new List<int>();
        foreach (InputField inputField in inputFields)
        {
            inputnumbersList.Add(int.Parse(inputField.text));
        }
        return inputnumbersList;
    }

    public List<int> GetOutputnumbersList()
    {
        List<int> outputnumbersList = new List<int>();
        foreach (InputField outputField in outputFields)
        {
            outputnumbersList.Add(int.Parse(outputField.text));
        }
        return outputnumbersList;
    }

    // 저장 버튼을 클릭했을 때 호출되는 메서드
    public void SaveToArray()
    {
        for (int i = 0; i < InputPosition.transform.childCount; i++)
        {
            inputFields.Add(InputPosition.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<InputField>());
        }

        for (int i = 0; i < OutputPosition.transform.childCount; i++)
        {
            outputFields.Add(OutputPosition.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<InputField>());
        }
        // 각각의 인풋 필드에서 입력된 숫자를 배열로 저장하여 리스트에 추가

        List<int> inputnumbersList = new List<int>();

        List<int> outputnumbersList = new List<int>();

        foreach (InputField inputField in inputFields)
        {
            inputnumbersList.Add(int.Parse(inputField.text));
        
        }

        foreach (InputField outputField in outputFields)
        {
            outputnumbersList.Add(int.Parse(outputField.text));
        }

        // 배열 형식으로 저장된 숫자 리스트를 출력
        foreach (var number1 in inputnumbersList)
        {
            
            Debug.Log("저장한 입력 배열: " + number1);
        }

        foreach (var number2 in outputnumbersList)
        {
            Debug.Log("저장한 정답 배열 : " + number2);
        }
    }

    // 사용자가 입력한 숫자를 추적하기 위해 각각의 인풋 필드를 추가하는 메서드
    public void AddInputField()
    {
        GameObject newInputFieldObject = Instantiate(inputFieldObjectPrefab, transform);

        GameObject newOutputFieldObject = Instantiate(outputFieldObjectPrefab, transform);

        InputField newInputField = newInputFieldObject.GetComponentInChildren<InputField>();

        InputField newOutputField = newOutputFieldObject.GetComponentInChildren<InputField>();

        inputFields.Add(newInputField);

        inputFields.Add(newOutputField);
    }
}
