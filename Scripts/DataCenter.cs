using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DataCenter : MonoBehaviour
{
    public static DataCenter instance;
    public GameObject slotPrefab,fieldCard,scrollBar;
    private static string path;
    private static string extension = ".prefab";

    //  เก็บภาพโลโก้ของแต่ละการ์ดเกมว
    public Sprite[] logo;
    //  เก็บค่าเริ่มต้น RectTransform ของ cardField
    private static RectTransform defaultCardField;
    //  เก็บค่าเริ่มต้นของ ScrollBar
    private static Scrollbar defaultScrollbar;
    //  เก็บผลรวมของ offSetMin
    private float totalOffSetMinY = 0;
    private float defaultOffSetMinY = 1100f;

    //  [Card count] Battle spirits
    public int bsCardAmount = 18;
        //  Banlist
    public int bsBannedAmount = 24;
    public int bsBanLimitAmount = 43;
    public int bsBanSemiLimAmount = 0;
    public List<GameObject> bsCardPrefabs = new List<GameObject>();
    //  [Card count] Rebirth for you
    public int rbCardAmount = 15;
        //  Banlist
    public int rbBannedAmount = 0;
    public int rbBanLimitAmount = 0;
    public int rbBanSemiLimAmount = 0;
    public List<GameObject> rbCardPrefabs = new List<GameObject>();
    //  All card on field
    public List<GameObject> cardOnField = new List<GameObject>();
    public List<GameObject> cardWithFilter = new List<GameObject>();
    //  Colors
    public static List<Color> colourData= new List<Color>();
    //  FilterExample
    public GameObject[] filterEx;

    private void Awake()
    {
        instance = this;
        DefaultSetting();
    }
    private void ColorSettings()
    {
        for (int i = 0; i < 11; i++)
        {
            colourData.Add(Color.clear);
        }
        colourData[0] = new Color(0, 0, 0, 0);
        colourData[1] = new Color(0, 0, 0, 1);
        colourData[2] = new Color(1, 1, 1, 1);
        colourData[3] = new Color(0, 0, 1, 1);
        colourData[4] = new Color(0, 1, 1, 1);
        colourData[5] = Color.gray;
        colourData[6] = new Color(0, 1, 0, 1);
        colourData[7] = new Color(0.5f, 0, 1, 1);
        colourData[8] = new Color(1, 0, 1, 1);
        colourData[9] = new Color(1, 0, 0, 1);
        colourData[10] = new Color(1, 0.92f, 0.016f, 1);
    }
    public void AddCardToField()
    {
        switch (PageController.instance.selectedCardIndex)
        {
            //  BS
            case 0:
                BattleSpirits();
                break;
            //  RB
            case 1:
                RebirthForYou();
                break;
            default:
                break;
        }
    }
    private void DefaultSetting()
    {
        ColorSettings();
        LoadCardOfBSToLists();
        LoadCardOfRBToLists();
    }
    public void DestroyCardInField()
    {
        foreach (Transform child in fieldCard.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void ResetRectTransform()
    {
        RectTransform rect = fieldCard.transform.GetComponent<RectTransform>();
        Scrollbar scBar = scrollBar.transform.GetComponent<Scrollbar>();
        scBar.value = 1f;
        // [ left - bottom ]
        rect.offsetMin = rect.offsetMin += new Vector2(0f, (totalOffSetMinY - defaultOffSetMinY));
        // [ right - top ]
        rect.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY = 0;
        cardOnField.Clear();
    }
    public void CreateCardWithFilter()
    {
        //  Generate Card
        for (int i = 0; i < cardWithFilter.Count; i++)
        {
            GameObject thisCard = Instantiate(cardWithFilter[i], fieldCard.transform);
            cardOnField.Add(thisCard);
        }
        /*//  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = fieldCard.transform.GetComponent<RectTransform>();
        rect.offsetMin = rect.offsetMin += new Vector2(0f, defaultOffSetMinY);
        for (int j = 0; j < fieldCard.transform.childCount; j++)
        {
            if ((j % maxCardPerLine) == 0 && j > 0)
            {
                totalOffSetMinY += 415f;
                // [ left - bottom ]
                rect.offsetMin += new Vector2(0f, -415f);
                // [ right - top ]
                rect.offsetMax = new Vector2(0f, 0f);
            }
        }*/
    }
    private void BattleSpirits()
    {
        //  Generate Card
        for (int i = 0; i < bsCardAmount; i++)
        {
            GameObject thisCard = Instantiate(bsCardPrefabs[i], fieldCard.transform);
            cardOnField.Add(thisCard);
        }
        //  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = fieldCard.transform.GetComponent<RectTransform>();
        rect.offsetMin = rect.offsetMin += new Vector2(0f, defaultOffSetMinY);
        for (int j = 0; j < fieldCard.transform.childCount;j++)
        {
            if((j % maxCardPerLine) == 0 && j > 0)
            {
                totalOffSetMinY += 415f;
                // [ left - bottom ]
                rect.offsetMin += new Vector2(0f, - 415f);
                // [ right - top ]
                rect.offsetMax = new Vector2(0f, 0f);
            }
        }
    }
    private void RebirthForYou()
    {
        //  Generate Card
        for (int i = 0; i < rbCardAmount; i++)
        {
            GameObject thisCard = Instantiate(rbCardPrefabs[i], fieldCard.transform);
            cardOnField.Add(thisCard);
        }
        //  Generate Field
        int maxCardPerLine = 3;
        RectTransform rect = fieldCard.transform.GetComponent<RectTransform>();
        rect.offsetMin = rect.offsetMin += new Vector2(0f, defaultOffSetMinY);
        for (int j = 0; j < fieldCard.transform.childCount; j++)
        {
            if ((j % maxCardPerLine) == 0 && j > 0)
            {
                totalOffSetMinY += 415f;
                // [ left - bottom ]
                rect.offsetMin += new Vector2(0f, -415f);
                // [ right - top ]
                rect.offsetMax = new Vector2(0f, 0f);
            }
        }
    }
    private void LoadCardOfBSToLists()
    {
        path = string.Format("Prefabs/BattleSpirits/");
        int tempIndex;
        for (int i = 1; i <= bsCardAmount; i++)
        {
            tempIndex = i;
            //GameObject thisPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path + i + extension);
            GameObject thisPrefab = Resources.Load<GameObject>(path + i);
            if (thisPrefab != null)
            {
                bsCardPrefabs.Add(thisPrefab);
                /*print(" [+][Battle Spirits] การ์ด " + bsCardPrefabs[tempIndex-1].name +
                    " "+ bsCardPrefabs[tempIndex-1].GetComponent<BattleSpiritsCard>().cardName + " ได้ถูกเพิ่ม [+] ");*/
            }
            else
            {
                print(" [!!!][Battle Spirits] การ์ด " + i + " ไม่มีข้อมูลอยู่ [!!!] ");
            }
        }
    }
    private void LoadCardOfRBToLists()
    {
        path = string.Format("Prefabs/RebirthForYou/");
        int tempIndex;
        for (int i = 1; i <= rbCardAmount; i++)
        {
            tempIndex = i;
            GameObject thisPrefab = Resources.Load<GameObject>(path + i);
            if (thisPrefab != null)
            {
                rbCardPrefabs.Add(thisPrefab);
                /*print(" [+][Rebirth For You] การ์ด " + rbCardPrefabs[tempIndex-1].name +
                    " " + rbCardPrefabs[tempIndex-1].GetComponent<RebirthForYouCard>().cardName + " ได้ถูกเพิ่ม [+] ");*/
            }
            else
            {
                print(" [!!!][Rebirth For You] การ์ด " + i + " ไม่มีข้อมูลอยู่ [!!!] ");
            }
        }
    }
   /* [MenuItem("AssetDatabase/[-] ClearCardData/Battle Spirits")]
    private static void MenuClearBS()
    {
        bsCardPrefabs.Clear();
    }
    [MenuItem("AssetDatabase/[-] ClearCardData/Rebirth For You")]
    private static void MenuClearRB()
    {
        rbCardPrefabs.Clear();
    }
    [MenuItem("AssetDatabase/[-] ClearCardData/All")]
    private static void MenuClearDataAll()
    {
        bsCardPrefabs.Clear();
        rbCardPrefabs.Clear();
    }*/
}
        /*foreach(object obj in objects)
        {
            Type type = obj.GetType();
            if(type == typeof(Sprite))
            {
                Sprite thisSprite = obj as Sprite;
                int index = int.Parse(thisSprite.name);
                SortByNumber(index, thisSprite);
            }
        }*/
    
    /*private void SortByNumber(int index,Sprite thisSprite)
    {
        if (cards_BattleSpirits.Count > 0)
        {
            for (int i = 0; i < cards_BattleSpirits.Count; i++)
            {
                if (index > int.Parse(cards_BattleSpirits[i].name))
                {
                    if (i == cards_BattleSpirits.Count - 1)
                    {
                        cards_BattleSpirits.Insert(cards_BattleSpirits.Count - 1, thisSprite);
                    }
                    else
                    {
                        cards_BattleSpirits.Insert(i++, thisSprite);
                    }
                }
                else if (index < int.Parse(cards_BattleSpirits[i].name))
                {
                    if (i == 0)
                    {
                        cards_BattleSpirits.Insert(0, thisSprite);
                    }
                    else
                    {
                        cards_BattleSpirits.Insert(i--, thisSprite);
                    }
                }
            }
        }
        else
        {
            cards_BattleSpirits.Add(thisSprite);
        }
    }*/

