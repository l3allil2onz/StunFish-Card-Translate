using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenuPanelController : MonoBehaviour
{
    private void Awake()
    {

    }
    public void PressPlaylistsPanel()
    {
        VideoPage.instance.selectedGuideline[0].SetActive(true);
        VideoPage.instance.selectedGuideline[1].SetActive(false);
        VideoPage.instance.childs[VideoPage.instance.childs.Count - 2].SetActive(true);
        VideoPage.instance.childs[VideoPage.instance.childs.Count - 1].SetActive(false);
    }
    public void PressVideosPanel()
    {
        VideoPage.instance.selectedGuideline[0].SetActive(false);
        VideoPage.instance.selectedGuideline[1].SetActive(true);
        VideoPage.instance.childs[VideoPage.instance.childs.Count - 2].SetActive(false);
        VideoPage.instance.childs[VideoPage.instance.childs.Count - 1].SetActive(true);
    }
}
