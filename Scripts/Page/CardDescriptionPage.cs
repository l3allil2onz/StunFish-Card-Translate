using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDescriptionPage : MonoBehaviour
{
    public static CardDescriptionPage instance;

    public GameObject descriptionSlotPrefab;
    public GameObject descriptionField;
    public Image bigImg;
    public Image gameCardImg;
    public Image cardImg;
    public Text topPanelText;
    public Text skillPanelText;
    public Scrollbar[] scrollBars;

    public int textSlotAmount;
    public List<Text> textSlots = new List<Text>();

    private float totalOffSetMinY = 0;
    private float defaultOffSetMinY = 0;

    private void Awake()
    {
        instance = this;
    }
    public void ResetRectTransform()
    {
        RectTransform rect = descriptionField.transform.GetComponent<RectTransform>();
        // [ left - bottom ]
        rect.offsetMin = rect.offsetMin += new Vector2(0f, (totalOffSetMinY - defaultOffSetMinY));
        // [ right - top ]
        rect.offsetMax = new Vector2(0f, 0f);
        totalOffSetMinY = 0;
    }
    public void CreateTextSlotInField()
    {
        if (textSlotAmount > 0)
        {
            for (int i = 0; i < textSlotAmount; i++)
            {
                GameObject thisSlot = Instantiate(descriptionSlotPrefab, descriptionField.transform);
                textSlots.Add(thisSlot.transform.GetChild(0).transform.GetComponent<Text>());
            }
            //  Generate Field
            RectTransform rect = descriptionField.transform.GetComponent<RectTransform>();
            rect.offsetMin = rect.offsetMin += new Vector2(0f, defaultOffSetMinY);
            for (int j = 0; j < descriptionField.transform.childCount; j++)
            {
                totalOffSetMinY += 115f;
                // [ left - bottom ]
                rect.offsetMin += new Vector2(0f, -115f);
                // [ right - top ]
                rect.offsetMax = new Vector2(0f, 0f);
            }
        }
        else
        {
            print("[!!!]ไม่สามารถสร้างช่องใส่ข้อความได้ เนื่องจากไม่มีการส่งจำนวนช่องข้อความมา[!!!]");
        }
    }
    public void ClearTextSlotInField()
    {
        for(int i = 0; i < scrollBars.Length; i++)
        {
            scrollBars[i].value = 1;
        }
        if (descriptionField.transform.childCount > 0)
        {
            textSlots.Clear();
            foreach (Transform child in descriptionField.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
