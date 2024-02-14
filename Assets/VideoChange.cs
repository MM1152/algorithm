using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoChange : MonoBehaviour
{
    [SerializeField]
    private VideoData videoData;
    public VideoData VideoData { set { videoData = value; } }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < videoData.Videos.Length; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
