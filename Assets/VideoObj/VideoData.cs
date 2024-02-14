using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "Video Data", menuName = "Scriptable Object/Video Data", order = int.MaxValue)]
public class VideoData : ScriptableObject
{
    [SerializeField]
    private VideoClip[] videoes;
    public VideoClip[] Videos { get { return videoes; } }
}
