using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject inputDataParent;
    public GameObject outputDataParent;
    public static Vector3 inputPos;
    public static Vector3 outputPos;
    RectTransform rect;
    RectTransform rect2;
    private void Start()
    {
        inputPos = new Vector3(80f, -50f);
        outputPos = new Vector3(65f, -50f);
        rect = inputDataParent.GetComponent<RectTransform>();
        rect2 = outputDataParent.GetComponent<RectTransform>();
    }
    public void InputContentSize()
    {

            rect.sizeDelta += new Vector2(0f, 100f);
        
        
    }
    public void InputContentSizeDelete()
    {
        if (inputDataParent.transform.childCount > 0)
        {
            rect.sizeDelta += new Vector2(0f, -100f);
        }
    }
    public void OutputContentSize()
    {

            rect2.sizeDelta += new Vector2(0f, 100f);
        
    }
    public void OutputContentSizeDelete()
    {
        if (outputDataParent.transform.childCount > 0)
        {
            rect2.sizeDelta += new Vector2(0f, -100f);
        }
    }
    // 버튼을 누를 때 호출되는 함수
    public void inputDataPress()
    {
        GameObject box = Instantiate(boxPrefab, inputDataParent.transform) as GameObject;
        box.transform.position += inputPos;
        box.transform.localScale = new Vector3(75f, 75f);
        inputPos += new Vector3(0, -100f, 0f);
        RearrangeBoxes(inputDataParent.transform);
    }
    public void outputDataPress()
    {
        GameObject box = Instantiate(boxPrefab, outputDataParent.transform) as GameObject;
        box.transform.localPosition += outputPos;
        box.transform.localScale = new Vector3(75f, 75f);
        outputPos += new Vector3(0, -100f, 0f);
        RearrangeBoxes(outputDataParent.transform);
    }

    public void InputdeleteDataPress()
    {
        if (inputDataParent.transform.childCount > 0)
        {
            Destroy(inputDataParent.transform.GetChild(inputDataParent.transform.childCount - 1).gameObject);
            inputPos += new Vector3(0, 100f, 0f); // 이전 위치로 조정

        }
    }

    public void OutputdeleteDataPress()
    {
        if (outputDataParent.transform.childCount > 0)
        {
            Destroy(outputDataParent.transform.GetChild(outputDataParent.transform.childCount - 1).gameObject);
            outputPos += new Vector3(0, 100f, 0f); // 이전 위치로 조정
            RearrangeBoxes(outputDataParent.transform);
        }
    }

    // 박스들을 정렬하는 함수
    private void RearrangeBoxes(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            Vector3 newPosition = new Vector3(child.localPosition.x, child.localPosition.y, child.localPosition.z);
            child.localPosition = newPosition;
        }
    }
}
