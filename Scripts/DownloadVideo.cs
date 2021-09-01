using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Video;

public class DownloadVideo : MonoBehaviour
{
    public string URL;
    public RenderTexture renTex;
    //public Text reqTxt;

    void Start()
    {
        UnityWebRequest request = new UnityWebRequest(URL);
        StartCoroutine(GetVideo(request));
    }
    IEnumerator GetVideo(UnityWebRequest req)
    {
        string logError;
        yield return req.SendWebRequest();

        /*reqTxt.text = string.Format("Progress : {0}\nURL : {1}\nIsError : {2}",
            req.downloadProgress.ToString(), req.url, req.isNetworkError);*/
        logError = (" Downloaded bytes : " + req.downloadedBytes);
        if (req.isNetworkError || req.isHttpError)
        {
            logError = string.Format("<b>[!] Video ({0}) can't send the request, Network error [!]</b>",transform.parent.name);
            print(logError);
            yield break;
        }

        var vp = gameObject.AddComponent<VideoPlayer>();
        vp.playOnAwake = false;
        vp.source = VideoSource.Url;
        vp.url = req.url;
        vp.isLooping = false;
        vp.renderMode = VideoRenderMode.RenderTexture;
        vp.targetTexture = renTex;
        vp.Prepare();
        vp.Play();
    }
}
