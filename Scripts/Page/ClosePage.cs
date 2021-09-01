using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePage : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void ResetSetting()
    {
        DataCenter.instance.ResetRectTransform();
    }
    public void ResetAllBanlistSetting()
    {
        BanlistPage.instance.ResetAllRectTransform();
        BanlistPage.instance.guideLineNumber = 1;
    }
    public void ResetBannedSetting()
    {
        BanlistPage.instance.ResetBannedRectTransform();
    }
    public void ResetBanLimitSetting()
    {
        BanlistPage.instance.ResetBanLimitRectTransform();
    }
    public void ResetBanSemiLimitSetting()
    {
        BanlistPage.instance.ResetBanSemiLimitRectTransform();
    }
    public void ClearField()
    {
        if (DataCenter.instance.fieldCard.transform.childCount > 0)
        {
            DataCenter.instance.DestroyCardInField();
        }
    }
    public void ClearBanlistField()
    {
        BanlistPage.instance.ClearBannedCardOnField();
        BanlistPage.instance.ClearBanLimitCardOnField();
        BanlistPage.instance.ClearBanSemiLimitCardOnField();
    }
    public void ClearBannedField()
    {
        BanlistPage.instance.ClearBannedCardOnField();
    }
    public void ClearBanLimitField()
    {
        BanlistPage.instance.ClearBanLimitCardOnField();
    }
    public void ClearBanSemiLimitField()
    {
        BanlistPage.instance.ClearBanSemiLimitCardOnField();
    }
    public void AnimationClose()
    {
        GetComponent<Animator>().SetTrigger("ClosePage");
    }
}
