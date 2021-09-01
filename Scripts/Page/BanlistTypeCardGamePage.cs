using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanlistTypeCardGamePage : MonoBehaviour
{
    public void GetNumber(int cardIndex)
    {
        PageController.instance.selectedCardIndex = cardIndex;
        MenuController.instance.Banlist();
    }
    public void ResetGuideLine()
    {
        BanlistPage.instance.guideLineNumber = 1;
        StartLoadingBanlist();
    }
    private void StartLoadingBanlist()
    {
        BanlistMenuPanelController.instance.PressBannedPanel();
        BanlistPage.instance.ResetBanLimitRectTransform();
        BanlistPage.instance.ResetBanSemiLimitRectTransform();
    }
}
