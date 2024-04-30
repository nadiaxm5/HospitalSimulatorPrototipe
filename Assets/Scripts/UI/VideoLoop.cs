using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoop : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] renders;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        videoPlayer.loopPointReached += VideoEnd;
    }

    void VideoEnd(VideoPlayer vp)
    {
        vp.clip = renders[i];
        if (i >= renders.Length - 1)
            i = 0;
        else
            i++;
    }
}
