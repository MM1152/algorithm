using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject inputDataParent;
    public GameObject outputDataParent;
    public Vector3 position;

    // 버튼을 누를 때 호출되는 함수
    public void inputDataPress()
    {
        GameObject box = Instantiate(boxPrefab, inputDataParent.transform) as GameObject;
        box.transform.localPosition += position;
        position += new Vector3(0, -1f, 0f);
        RearrangeBoxes(inputDataParent.transform);
    }
    public void outputDataPress()
    {
        GameObject box = Instantiate(boxPrefab, outputDataParent.transform) as GameObject;
        box.transform.localPosition += position;
        position += new Vector3(0, -1f, 0f);
        RearrangeBoxes(outputDataParent.transform);
    }

    public void InputdeleteDataPress()
    {
        if (inputDataParent.transform.childCount > 0)
        {
            Destroy(inputDataParent.transform.GetChild(inputDataParent.transform.childCount - 1).gameObject);
            position += new Vector3(0, 1f, 0f); // 이전 위치로 조정
            RearrangeBoxes(inputDataParent.transform);
        }
    }

    public void OutputdeleteDataPress()
    {
        if (outputDataParent.transform.childCount > 0)
        {
            Destroy(outputDataParent.transform.GetChild(outputDataParent.transform.childCount - 1).gameObject);
            position += new Vector3(0, 1f, 0f); // 이전 위치로 조정
            RearrangeBoxes(outputDataParent.transform);
        }
    }

    // 박스들을 정렬하는 함수
    private void RearrangeBoxes(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            Vector3 newPosition = new Vector3(child.localPosition.x, -i, child.localPosition.z);
            child.localPosition = newPosition;
        }
    }
}
