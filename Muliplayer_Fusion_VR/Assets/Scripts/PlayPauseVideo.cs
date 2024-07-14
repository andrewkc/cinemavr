using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayPauseVideo : MonoBehaviour
{
    // Start is called before the first frame update
    private VideoPlayer video;
    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    public void PlayVideo()
    {
        video.Play();
    }
    public void StopVideo()
    {
        video.Stop();
    }
    public void PauseVideo()
    {
        video.Pause();
    }
    
}
