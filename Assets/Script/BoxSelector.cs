using UnityEngine;

public class BoxSelector : MonoBehaviour
{
    private GameObject selectedBox; // 선택된 박스
    private BoxNumberChanger boxNumberChanger; // BoxNumberChanger 스크립트에 대한 참조

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
                    boxNumberChanger = selectedBox.GetComponent<BoxNumberChanger>(); // 선택된 박스의 BoxNumberChanger 스크립트 가져오기
                }
            }
        }

        // 선택된 박스가 있고, 사용자가 숫자를 입력하면 숫자를 변경합니다.
        if (selectedBox != null && boxNumberChanger != null)
        {
            // 사용자가 키보드를 입력하면 해당 숫자로 변경합니다.
            if (Input.inputString.Length > 0)
            {
                char inputChar = Input.inputString[0];
                if (char.IsDigit(inputChar))
                {
                    int number = int.Parse(inputChar.ToString());
                    boxNumberChanger.ChangeNumber(number);
                }
            }
        }
    }
}
