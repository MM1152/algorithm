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

}