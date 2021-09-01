using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ReceiveError : MonoBehaviour
{
    public VideoPlayer m_VideoPlayer;
    string m_MoivePath;

    public void ReceiveVideoError()
    {
        m_VideoPlayer.errorReceived += delegate (VideoPlayer videoPlayer, string message)
        {
            Debug.LogWarning("[VideoPlayer] Play Movie Error: " + message);
            //Handheld.PlayFullScreenMovie(m_MoivePath, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
        };
    }
}
