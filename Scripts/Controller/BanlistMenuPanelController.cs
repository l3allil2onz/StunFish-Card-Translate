using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanlistMenuPanelController : MonoBehaviour
{
    public static BanlistMenuPanelController instance;

    private void Awake()
    {
        instance = this;
    }
    public void PressBannedPanel()
    {
        if (BanlistPage.instance.bannedField.transform.childCount <= 0)
        {
            BanlistPage.instance.selectedGuideline[0].SetActive(true);
            BanlistPage.instance.selectedGuideline[1].SetActive(false);
            BanlistPage.instance.selectedGuideline[2].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 4].SetActive(true);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 3].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 2].SetActive(false);
            BanlistPage.instance.guideLineNumber = 1;
            BanlistPage.instance.AddCardToField();
        }
    }
    public void PressLimitPanel()
    {
        if (BanlistPage.instance.banLimitField.transform.childCount <= 0)
        {
            BanlistPage.instance.selectedGuideline[0].SetActive(false);
            BanlistPage.instance.selectedGuideline[1].SetActive(true);
            BanlistPage.instance.selectedGuideline[2].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 4].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 3].SetActive(true);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 2].SetActive(false);
            BanlistPage.instance.guideLineNumber = 2;
            BanlistPage.instance.AddCardToField();
        }
    }
    public void PressSemiLimitPanel()
    {
        if (BanlistPage.instance.banSemiLimitField.transform.childCount <= 0)
        {
            BanlistPage.instance.selectedGuideline[0].SetActive(false);
            BanlistPage.instance.selectedGuideline[1].SetActive(false);
            BanlistPage.instance.selectedGuideline[2].SetActive(true);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 4].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 3].SetActive(false);
            BanlistPage.instance.childs[BanlistPage.instance.childs.Count - 2].SetActive(true);
            BanlistPage.instance.guideLineNumber = 3;
            BanlistPage.instance.AddCardToField();
        }
    }
}
