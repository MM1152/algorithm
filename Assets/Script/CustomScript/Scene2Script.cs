using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Scene2Script : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject objectPrefab1;// 리스트의 각 요소를 보여줄 프리팹
    public GameObject objectPrefab2;

    public Transform parentTransform1; // 생성된 오브젝트들의 부모로 지정할 Transform
    public Transform parentTransform2;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        
        // GameManager로부터 리스트를 받아옵니다.
        List<int> inputList = gameManager.GetInputNumbersList();// 예시로 inputList를 받아왔습니다.
       
        List<int> outputList = gameManager.GetOutputNumbersList(); // 예시로 outputList를 받아왔습니다.

        // 리스트의 각 요소들을 오브젝트로 생성하여 화면에 보여줍니다.
        CreateObjects1(inputList);
        CreateObjects2(outputList);

    }

    private void CreateObjects1(List<int> numbersList)
    {
        foreach (int number in numbersList)
        {
            // 프리팹을 복제하여 씬에 추가합니다.
            GameObject newObj = Instantiate(objectPrefab1, parentTransform1);

            // 새로운 오브젝트에 숫자를 텍스트로 설정합니다.
            Text textComponent = newObj.GetComponentInChildren<Text>();
            if (textComponent != null)
            {
                textComponent.text = number.ToString();
            }

        }
    }

    private void CreateObjects2(List<int> numbersList)
    {
        foreach (int number in numbersList)
        {
            // 프리팹을 복제하여 씬에 추가합니다.
            GameObject newObj = Instantiate(objectPrefab2, parentTransform2);

            // 새로운 오브젝트에 숫자를 텍스트로 설정합니다.
            Text textComponent = newObj.GetComponentInChildren<Text>();
            if (textComponent != null)
            {
                textComponent.text = number.ToString();
            }
        }
    }
    // 리스트의 각 요소를 오브젝트로 생성하는 메서드
}
