using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPage : MonoBehaviour
{
    public GameObject pageTarget;
    public void OpenAnyPage()
    {
        pageTarget.SetActive(true);
    }
    public void OpenDescriptionPage()
    {
        pageTarget = CardDescriptionPage.instance.gameObject;
        pageTarget.SetActive(true);
    }
    public void OpenBanlistCardBigImageForm()
    {
        int lastChild = BanlistPage.instance.transform.childCount;
        lastChild--;
        pageTarget = BanlistPage.instance.transform.GetChild(lastChild).gameObject;
        pageTarget.SetActive(true);
        pageTarget.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite =
            transform.GetChild(0).GetComponent<Image>().sprite;
    }
}
