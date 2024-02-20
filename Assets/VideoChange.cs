using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoChange : MonoBehaviour
{
    [SerializeField]
    private VideoData videoData;
    public VideoData VideoData { set { videoData = value; } }

    public GameManager gameManager;
    private VideoPlayer videoPlayer;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    public void NextVideo()
    {
        videoPlayer.clip = videoData.Videos[++count];
    }
}
