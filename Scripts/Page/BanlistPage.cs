using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class BanlistPage : MonoBehaviour
{
    public static BanlistPage instance;

    public GameObject banlistCardPrefab;
    public RectTransform bannedField, banLimitField, banSemiLimitField;
    public Scrollbar bannedScrollBar, banLimitScrollBar, banSemiLimitScrollBar;
    private int bannedAmount;
    private int banLimitAmount;
    private int banSemiLimitAmount;

    private int cardType;
    private string path;
    private string extension = ".png";
    //  เก็บผลรวมของ offSetMin
    private float totalOffSetMinY_Banned = 0;
    private float totalOffSetMinY_BanLimit = 0;
    private float totalOffSetMinY_BanSemi = 0;
    private float defaultOffSetMinY = 1100f;

    public int guideLineNumber;
    public List<GameObject> childs = new List<GameObject>();
    public List<Button> menuPanelBtn = new List<Button>();
    public List<GameObject> selectedGuideline = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        if (transform.childCount > 0)
        {
            foreach (Transform rect in transform)
            {
                childs.Add(rect.gameObject);
            }
        }
    }
    public void AddCardToField()
    {
        cardType = PageController.instance.selectedCardIndex;
        switch (cardType)
        {
            case 0:
                bannedAmount = DataCenter.instance.bsBannedAmount;
                banLimitAmount = DataCenter.instance.bsBanLimitAmount;
                banSemiLimitAmount = DataCenter.instance.bsBanSemiLimAmount;
                CheckBanlistType(cardType);
                break;
            case 1:
                bannedAmount = DataCenter.instance.rbBannedAmount;
                banLimitAmount = DataCenter.instance.rbBanLimitAmount;
                banSemiLimitAmount = DataCenter.instance.rbBanSemiLimAmount;
                CheckBanlistType(cardType);
                break;
            default:
                break;
        }
    }
    private void CheckBanlistType(int type)
    {
        if (guideLineNumber > 0)
        {
            switch (guideLineNumber)
            {
                case 1:
                    CallBannedCardByGameTypes(type);
                    GenerateBannedLine(bannedAmount);
                    //baned
                    break;
                case 2:
                    CallBanLimitCardByGameTypes(type);
                    GenerateBanLimitLine(banLimitAmount);
                    //limit
                    break;
                case 3:
                    CallSemiBanCardByGameTypes(type);
                    GenerateBanSemiLine(banSemiLimitAmount);
                    //semi limit
                    break;
                default:
                    break;
            }
        }
        else
        {
            print("No slected guildeline.");
        }
    }
    private void CallBannedCardByGameTypes(int type)
    {
        switch (type)
        {

            case 0:
                BattleSpiritsBanned();
                break;
            case 1:
                RebirthForYouBanned();
                break;
            default:
                break;
        }
    }
    private void CallBanLimitCardByGameTypes(int type)
    {
        switch (type)
        {
            case 0:
                BattleSpiritsBanLimit();
                break;
            case 1:
                RebirthForYouBanLimit();
                break;
            default:
                break;
        }
    }
    private void CallSemiBanCardByGameTypes(int type)
    {
        switch (type)
        {
            case 0:
                BattleSpiritsSemiBan();
                break;
            case 1:
                RebirthForYouSemiBan();
                break;
            default:
                break;
        }
    }
    private void BattleSpiritsBanned()
    {
        path = string.Format("BanlistCards/BattleSpirits/0_0/");
        for (int i = 1; i <= bannedAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, bannedField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void BattleSpiritsBanLimit()
    {
        path = string.Format("BanlistCards/BattleSpirits/0_1/");
        for (int i = 1; i <= banLimitAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, banLimitField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void BattleSpiritsSemiBan()
    {
        path = string.Format("BanlistCards/BattleSpirits/0_2/");
        for (int i = 1; i <= banSemiLimitAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, banSemiLimitField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void RebirthForYouBanned()
    {
        path = string.Format("BanlistCards/Rebirth/0_0/");
        for (int i = 1; i <= bannedAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, bannedField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void RebirthForYouBanLimit()
    {
        path = string.Format("BanlistCards/Rebirth/0_1/");
        for (int i = 1; i <= banLimitAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, banLimitField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void RebirthForYouSemiBan()
    {
        path = string.Format("BanlistCards/Rebirth/0_2/");
        for (int i = 1; i <= banSemiLimitAmount; i++)
        {
            //Sprite thisSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + i + extension);
            Sprite thisSprite = Resources.Load<Sprite>(path + i);
            if (thisSprite != null)
            {
                GameObject thisBanCard = Instantiate(banlistCardPrefab, banSemiLimitField.transform);
                thisBanCard.transform.GetChild(0).GetComponent<Image>().sprite = thisSprite;
            }
            else
            {
                print("[!] ไม่มีข้อมูลรูปภาพของ การ์ดที่ถูกแบน [!]");
            }
        }
    }
    private void GenerateBannedLine(int cardAmount)
    {
        //  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = bannedField;
        if (cardAmount > 0)
        {
            rect.offsetMin = rect.offsetMin + new Vector2(0f, defaultOffSetMinY);
            for (int j = 0; j < bannedField.transform.childCount; j++)
            {
                if ((j % maxCardPerLine) == 0 && j > 0)
                {
                    totalOffSetMinY_Banned += 415;
                    // [ left - bottom ]
                    rect.offsetMin += new Vector2(0f, -415f);
                    // [ right - top ]
                    rect.offsetMax = new Vector2(0f, 0f);
                }
            }
        }
    }
    private void GenerateBanLimitLine(int cardAmount)
    {
        //  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = banLimitField;
        if (cardAmount > 0)
        {
            rect.offsetMin = rect.offsetMin + new Vector2(0f, defaultOffSetMinY);
            for (int j = 0; j < banLimitField.transform.childCount; j++)
            {
                if ((j % maxCardPerLine) == 0 && j > 0)
                {
                    totalOffSetMinY_BanLimit += 415;
                    // [ left - bottom ]
                    rect.offsetMin += new Vector2(0f, -415f);
                    // [ right - top ]
                    rect.offsetMax = new Vector2(0f, 0f);
                }
            }
        }
    }
    private void GenerateBanSemiLine(int cardAmount)
    {
        //  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = banSemiLimitField;
        if (cardAmount > 0)
        {
            rect.offsetMin = rect.offsetMin + new Vector2(0f, defaultOffSetMinY);
            for (int j = 0; j < banSemiLimitField.transform.childCount; j++)
            {
                if ((j % maxCardPerLine) == 0 && j > 0)
                {
                    totalOffSetMinY_BanSemi += 415;
                    // [ left - bottom ]
                    rect.offsetMin += new Vector2(0f, -415f);
                    // [ right - top ]
                    rect.offsetMax = new Vector2(0f, 0f);
                }
            }
        }
    }
    public void ResetAllRectTransform()
    {
        RectTransform rectBanned = bannedField;
        RectTransform rectBanLimit = banLimitField;
        RectTransform rectBanSemi = banSemiLimitField;
        Scrollbar scBarBanned = bannedScrollBar;
        Scrollbar scBarBanLimit = banLimitScrollBar;
        Scrollbar scBarBanSemi = banSemiLimitScrollBar;
        float defOffsetMinY = defaultOffSetMinY;
        scBarBanned.value = 1f;
        scBarBanLimit.value = 1f;
        scBarBanSemi.value = 1f;
        scBarBanned.size = 1f;
        scBarBanLimit.size = 1f;
        scBarBanSemi.size = 1f;
        // [ left - bottom ]
        rectBanned.offsetMin = rectBanned.offsetMin + new Vector2(0f, 0f);
        rectBanLimit.offsetMin = rectBanLimit.offsetMin + new Vector2(0f, 0f);
        rectBanSemi.offsetMin = rectBanSemi.offsetMin + new Vector2(0f, 0f);
        // [ right - top ]
        rectBanned.offsetMax = new Vector2(0f, 0f);
        rectBanLimit.offsetMax = new Vector2(0f, 0f);
        rectBanSemi.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY_Banned = 0;
        totalOffSetMinY_BanLimit = 0;
        totalOffSetMinY_BanSemi = 0;
    }
    public void ResetBannedRectTransform()
    {
        RectTransform rectBanned = bannedField;
        Scrollbar scBarBanned = bannedScrollBar;
        scBarBanned.value = 1f;
        scBarBanned.size = 1f;
        // [ left - bottom ]
        rectBanned.offsetMin = new Vector2(0f, 0f);
        // [ right - top ]
        rectBanned.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY_Banned = 0;
    }
    public void ResetBanLimitRectTransform()
    {
        RectTransform rectBanLimit = banLimitField;
        Scrollbar scBarBanLimit = banLimitScrollBar;
        scBarBanLimit.value = 1f;
        scBarBanLimit.size = 1f;
        // [ left - bottom ]
        rectBanLimit.offsetMin = new Vector2(0f, 0f);
        // [ right - top ]
        rectBanLimit.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY_BanLimit = 0;
    }
    public void ResetBanSemiLimitRectTransform()
    {
        RectTransform rectBanSemi = banSemiLimitField;
        Scrollbar scBarBanSemi = banSemiLimitScrollBar;
        scBarBanSemi.value = 1f;
        scBarBanSemi.size = 1f;
        // [ left - bottom ]
        rectBanSemi.offsetMin = new Vector2(0f, 0f);
        // [ right - top ]
        rectBanSemi.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY_BanSemi = 0;
    }
    public void ClearBanlistCardOnField(Transform field)
    {
        if (field.transform.childCount > 0)
        {
            foreach (Transform card in field)
            {
                Destroy(card.gameObject);
            }
        }
    }
    public void ClearBannedCardOnField()
    {
        if (bannedField.transform.childCount > 0)
        {
            foreach (RectTransform card in bannedField.transform)
            {
                Destroy(card.gameObject);
            }
        }
    }
    public void ClearBanLimitCardOnField()
    {
        if (banLimitField.transform.childCount > 0)
        {
            foreach (RectTransform card in banLimitField.transform)
            {
                Destroy(card.gameObject);
            }
        }
    }
    public void ClearBanSemiLimitCardOnField()
    {
        if (banSemiLimitField.transform.childCount > 0)
        {
            foreach (RectTransform card in banSemiLimitField.transform)
            {
                Destroy(card.gameObject);
            }
        }
    }
}
