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
        GameObject box = Instantiate(boxPrefab , inputDataParent.transform) as GameObject;
        box.transform.localPosition += position;
        position += new Vector3(0, -1f, 0f);
    }
    public void outputDataPress()
    {
        GameObject box = Instantiate(boxPrefab, outputDataParent.transform) as GameObject;
        box.transform.localPosition += position;
        position += new Vector3(0, -1f, 0f);
    }
}
