using UnityEngine;
using UnityEngine.UI;

public class BoxNumberChanger : MonoBehaviour
{
    private GameObject selectedBox; // 선택된 박스
    private Text textBox; // 박스에 표시된 숫자를 나타내는 Text UI


    void Start()
    {
        textBox = GetComponentInChildren<Text>(); // 박스의 Text UI 가져오기
    }

    void Update()
    {
        // 사용자가 마우스 왼쪽 버튼을 클릭하면 박스를 선택합니다.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Box"))
                {
                    selectedBox = hit.collider.gameObject;
                    textBox = selectedBox.GetComponentInChildren<Text>(); // 박스의 Text UI 가져오기
                }
            }
        }

        // 선택된 박스가 있고, 사용자가 키보드를 입력하면 해당 숫자로 변경합니다.
        if (selectedBox != null)
        {
            // 사용자가 키보드를 입력하면 텍스트를 해당 숫자로 변경합니다.
            if (Input.inputString.Length > 0)
            {
                char inputChar = Input.inputString[0];
                if (char.IsDigit(inputChar))
                {
                    textBox.text = inputChar.ToString();
                }
            }
        }


    }

    public void ChangeNumber(int number)
    {
        textBox.text = number.ToString();
    }
}
