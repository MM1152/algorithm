using System.Numerics;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject boxPrefab; // 복사할 박스 프리팹

    public Transform spawnPoint; // 박스를 생성할 위치

    private float boxHeight = 1.0f; // 박스의 높이

    // 버튼을 누를 때 호출되는 함수
    public void OnButtonPress()
    {
        // 이전 박스가 없을 때 spawnPoint의 위치를 기준으로 생성
        UnityEngine.Vector3 spawnPosition = spawnPoint.position;
        if (spawnPoint.childCount > 0)
        {
            // 이전 박스가 있을 경우, 이전 박스의 아래로 생성
            Transform lastBox = spawnPoint.GetChild(spawnPoint.childCount - 1);
            spawnPosition = lastBox.position - new UnityEngine.Vector3(0, boxHeight, 0);
        }

        // 박스 프리팹을 복사하여 새로운 박스를 생성
        GameObject newBox = Instantiate(boxPrefab, spawnPosition, UnityEngine.Quaternion.identity);

        // 새로운 박스를 spawnPoint의 자식으로 설정하여 위치를 정렬
        newBox.transform.parent = spawnPoint;
    }
}
