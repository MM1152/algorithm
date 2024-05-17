using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inputBelt : MonoBehaviour
{
    public List<int> boxNum;
    public List<Animator> BeltAni;

    public GameObject Box;
    public BeltController beltController;

    public GameObject box;
//    private float boxinitPos;
    private float boxtransY;
    private void Awake()
    {
        boxNum = new List<int>();
        beltController = gameObject.transform.Find("Belt").GetComponent<BeltController>();
        boxtransY = -1f;
      //  boxinitPos = 0.4f;
    }
    private void LateUpdate()
    {
        if (gameObject.transform.Find("Box(Clone)"))
        {
            box = gameObject.transform.Find("Box(Clone)").gameObject;
        }
        
        if (gameObject.transform.childCount > 1 && gameObject.transform.Find("Box(Clone)").transform.position.y <= -0.6f)
        {
            BoxMove();
        }else if(beltController.BeltAni[0].GetBool("IsBeltMove"))
        {
            beltController.BeltStop();
        }
           
    }

    private void BoxMove()
    {
            for (int i = 1; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).transform.Translate(new Vector3(0f , 0.03f , 0f));
                beltController.BeltMove();
            }
    }
    public void SettingBox()
    {
        for (int i = 0; i < boxNum.Count; i++)
        {
            GameObject prefeb = Instantiate(Box, transform) as GameObject;
            prefeb.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + boxNum[i];
            prefeb.transform.localPosition += new Vector3(0f, boxtransY, 0f);
            boxtransY += -0.2f;
        }
    }
}
