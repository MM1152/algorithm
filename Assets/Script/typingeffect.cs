using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingeffect : MonoBehaviour
{

    public Text tx;
    private string m_text = "\n본 게임은 협성대학교 졸업작품으로 \n\n알고리즘 교육용 프로그래밍 게임 입니다.";
    private string[] Level1 = { "반가워요 " , " 게임이용 방법을 알려드릴게요 " };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
IEnumerator _typing()
    {
        yield return new WaitForSeconds(1f);
        for(int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }
    }

}
