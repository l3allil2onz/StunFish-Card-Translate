using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    private bool isPause = false;
    private bool firstPlay = false;
    VideoPlayer vp;

    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if(vp.isPrepared && !vp.isPlaying && !vp.isPaused)
        {
            vp.Play();
            transform.parent.GetComponent<Button>().interactable = true;
        }
    }
    public void ClickToPlayVideo()
    {
        if (!firstPlay)
        {
            vp.Prepare();
            transform.parent.GetComponent<Button>().interactable = false;
            firstPlay = true;
        }
    }
    public void PauseVideo()
    {
        if (vp.isPrepared)
        {
            StartCoroutine(WaitForPauseWithSeconds(1f));
        }
    }
    IEnumerator WaitForPauseWithSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (vp.isPlaying && !vp.isPaused)
        {
            vp.Pause();
        }
        else if(!vp.isPlaying && vp.isPaused)
        {
            vp.Play();
        }
    }
}
