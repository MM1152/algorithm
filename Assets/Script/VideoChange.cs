using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoChange : MonoBehaviour
{
    [SerializeField]
    private VideoData videoData;

    public GameManager gameManager;
    public Text text;
    private VideoPlayer videoPlayer;

    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = videoData.Videos[count];
    }
    public void NextVideo()
    {
        Debug.Log(count);
        count++;
        
    }
}
