using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FilterPage : MonoBehaviour
{
    public static FilterPage instance;
    public GameObject filterSlotPrefab;
    public GameObject acceptBtnPrefab;
    public GameObject slotField;
    public List<Dropdown> dropdownFilter;
    public List<Dropdown> dropdownFilterPrototype;

    private void Awake()
    {
        instance = this;
    }
    public void CreateFilterSlot()
    {
        ClearField();
        int filSlotCount = GetFilterSlotCount();
        for (int i = 0; i < filSlotCount; i++)
        {
            //  Create
            GameObject thisFilterSlot = Instantiate(filterSlotPrefab, slotField.transform);
            dropdownFilter.Add(thisFilterSlot.GetComponent<DropdownFilter>().selfDropdown);
            //  Setting
            GetFilterPrototype(i);
            dropdownFilter[i].options = dropdownFilterPrototype[i].options;
            dropdownFilter[i].value = dropdownFilterPrototype[i].value;
        }
        //  Create accept button
        GameObject thisAcceptButton = Instantiate(acceptBtnPrefab, slotField.transform);
        thisAcceptButton.GetComponent<Button>().onClick.AddListener(() => { AcceptThisFilteration();
            transform.GetComponent<ClosePage>().AnimationClose();
        });
    }
    private void ClearField()
    {
        if (slotField.transform.childCount > 0)
        {
            foreach (Transform rect in slotField.transform)
            {
                Destroy(rect.gameObject);
            }
        }
        dropdownFilter.Clear();
        dropdownFilterPrototype.Clear();
        DataCenter.instance.cardWithFilter.Clear();
    }
    private void DestroyObjectOnField()
    {
        GameObject cardField = CardPage.instance.fieldCard;
        if (cardField.transform.childCount > 0)
        {
            foreach (Transform rect in cardField.transform)
            {
                Destroy(rect.gameObject);
            }
        }
    }
    private int GetFilterSlotCount()
    {
        int index = GetSelectedCardType();
        int filSlotCount = DataCenter.instance.filterEx[index].transform.childCount;
        return filSlotCount;
    }
    private int GetSelectedCardType()
    {
        int cardIndex = PageController.instance.selectedCardIndex;
        return cardIndex;
    }
    private void GetFilterPrototype(int filterIndex)
    {
        int gameType = GetSelectedCardType();
        int dropdownChildCount = DataCenter.instance.filterEx.Length;
        GameObject filterType = DataCenter.instance.filterEx[gameType];
        Dropdown filterDropdown = filterType.transform.GetChild(filterIndex).GetComponent<DropdownFilter>().selfDropdown;
        dropdownFilterPrototype.Add(filterDropdown);
    }
    public void AcceptThisFilteration()
    {
        DestroyObjectOnField();
        int defaultValueCount = 0;
        int lastIndexLoop = dropdownFilter.Count - 1;
        for (int i = 0; i < dropdownFilter.Count; i++)
        {
            int optionCount = dropdownFilter[i].options.Count;
            if (dropdownFilter[i].value == optionCount - 1)
            {
                defaultValueCount++;
            }
            if ((i == lastIndexLoop) && (defaultValueCount < dropdownFilter.Count))
            {
                SetListenerToFilterByGameType();
            }
        }
    }
    private void SetListenerToFilterByGameType()
    {
        int gameType = GetSelectedCardType();
        switch (gameType)
        {
            //  BS
            case 0:
                BattleSpiritFilteration();
                break;
            //  RB
            case 1:
                RebirthForYouFilteration();
                break;
            default: break;
        }
    }
    private void BattleSpiritFilteration()
    {
        bool checkBox = false;
        bool checkColor = false;
        bool checkCost = false;
        bool checkType = false;
        for (int filterIndex = 0; filterIndex < dropdownFilter.Count; filterIndex++)
        {
            int thisOptionCount = dropdownFilter[filterIndex].options.Count;
            int ocIndex = thisOptionCount - 1;
            int thisOptionValue = dropdownFilter[filterIndex].value;
            switch (filterIndex)
            {
                case 0:
                    if (thisOptionValue < ocIndex)
                    {
                        checkBox = true;
                    }
                    break;
                case 1:
                    if (thisOptionValue < ocIndex)
                    {
                        checkColor = true;
                    }
                    break;
                case 2:
                    if (thisOptionValue < ocIndex)
                    {
                        checkCost = true;
                    }
                    break;
                case 3:
                    if (thisOptionValue < ocIndex)
                    {
                        checkType = true;
                    }
                    break;
                default: break;
            }
        }
        BS_SelectCaseByCheckMark(checkBox, checkColor, checkCost, checkType);
    }
    private void RebirthForYouFilteration()
    {
        bool serieCheck = false;
        bool costCheck = false;
        bool typeCheck = false;
        bool atkCheck = false;
        bool defCheck = false;
        for (int filterIndex = 0; filterIndex < dropdownFilter.Count; filterIndex++)
        {
            int thisOptionCount = dropdownFilter[filterIndex].options.Count;
            int ocIndex = thisOptionCount - 1;
            int thisOptionValue = dropdownFilter[filterIndex].value;
            switch (filterIndex)
            {
                case 0:
                    if (thisOptionValue < ocIndex)
                        serieCheck = true;
                    break;
                case 1:
                    if (thisOptionValue < ocIndex)
                        costCheck = true;
                    break;
                case 2:
                    if (thisOptionValue < ocIndex)
                        typeCheck = true;
                    break;
                case 3:
                    if (thisOptionValue < ocIndex)
                        atkCheck = true;
                    break;
                case 4:
                    if (thisOptionValue < ocIndex)
                        defCheck = true;
                    break;
                default: break;
            }
        }
        RB_SelectCaseByCheckMark(serieCheck, costCheck, typeCheck, atkCheck, defCheck);
    }
    //  ควรใช้เทคนิคลบแล้วสร้างใหม่
    //  เพราะถ้าเรียงหรือเปลี่ยนจากเดิม เวลากลับไปหน้าฟิลเตอร์เพื่อกรองอีกรอบ ตัวที่ถูกคัดออกจากการกรองครั้งก่อนจะไม่กลับมาด้วย
    private void RB_SelectCaseByCheckMark(bool serie, bool cost, bool type, bool atk, bool def)
    {
        string dropdownFilter0 = string.Format("{0}", dropdownFilter[0].options[0].text.Replace("ซีรี่ย์ : ", ""));
        List<GameObject> cardList = GetRBCardList();
        var findCardByFilter = from card in cardList select card;
        if (serie)
        {
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<RebirthForYouCard>().descriptions.serie == dropdownFilter0
                               select card;
            print(cardList[0].GetComponent<RebirthForYouCard>().descriptions.serie + " || " + dropdownFilter0);
        }
        if (cost)
        {
            int optionValue = dropdownFilter[1].value;
            string dropdownFilter1 = string.Format("{0}", dropdownFilter[1].options[optionValue].text.Replace("ค่าร่าย : ", ""));
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<RebirthForYouCard>().descriptions.cost.ToString() == dropdownFilter1
                               select card;
        }
        if (type)
        {
            int optionValue = dropdownFilter[2].value;
            string dropdownFilter2 = string.Format("{0}", dropdownFilter[2].options[optionValue].text.Replace("ประเภท : ", ""));
            switch (dropdownFilter2)
            {
                case "คาแรคเตอร์":
                    dropdownFilter2 = "Character";
                    break;
                case "สปาร์ค":
                    dropdownFilter2 = "Spark";
                    break;
                case "รีเบิร์ส":
                    dropdownFilter2 = "Rebirth";
                    break;
            }
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<RebirthForYouCard>().
                               types.types.ToString() == dropdownFilter2
                               select card;
        }
        if (atk)
        {
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<RebirthForYouCard>().
                               descriptions.attackDamage > 0
                               select card;
        }
        if (def)
        {
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<RebirthForYouCard>().
                               descriptions.defense > 0
                               select card;
        }
        //  Add
        foreach (GameObject card in findCardByFilter)
        {
            print(card);
            DataCenter.instance.cardWithFilter.Add(card);
        }
        //  Create
        DataCenter.instance.CreateCardWithFilter();
    }
    private void BS_SelectCaseByCheckMark(bool box, bool color, bool cost, bool type)
    {
        //  Replace text
        string dropdownFilter0 = string.Format("{0}", dropdownFilter[0].options[0].text.Replace("ชุด : ", ""));
        List<GameObject> cardList = GetBSCardList();
        var findCardByFilter = from card in cardList select card;
        if (box)
        {
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<BattleSpiritsCard>().cardBox == dropdownFilter0
                               select card;
        }
        if (color)
        {
            int colorIndex = -1;
            int optionValue = dropdownFilter[1].value;
            string dropdownFilter1 = string.Format("{0}", dropdownFilter[1].options[optionValue].text.Replace("สี : ", ""));
            switch (dropdownFilter1)
            {
                case "แดง":
                    dropdownFilter1 = "Red";
                    break;
                case "ม่วง":
                    dropdownFilter1 = "Purple";
                    break;
                case "เขียว":
                    dropdownFilter1 = "Green";
                    break;
                case "ขาว":
                    dropdownFilter1 = "White";
                    break;
                case "เหลือง":
                    dropdownFilter1 = "Yellow";
                    break;
                case "น้ำเงิน":
                    dropdownFilter1 = "Blue";
                    break;
                default: break;
            }
            foreach (GameObject cards in findCardByFilter)
            {
                int colorLength = cards.GetComponent<BattleSpiritsCard>().descriptions.colors.Length;
                if (colorLength > 0)
                {
                    for (int i = 0; i < colorLength; i++)
                    {
                        if (cards.GetComponent<BattleSpiritsCard>().
                            descriptions.colors[i].colorText.ToString() == dropdownFilter1)
                        {
                            colorIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            if (colorIndex > -1)
            {
                findCardByFilter = from card in findCardByFilter
                                   where card.GetComponent<BattleSpiritsCard>().
                                   descriptions.colors[colorIndex].colorText.ToString() == dropdownFilter1
                                   select card;
            }
        }
        if (cost)
        {
            int optionValue = dropdownFilter[2].value;
            string dropdownFilter2 = string.Format("{0}", dropdownFilter[2].options[optionValue].text.Replace("ค่าร่าย : ", ""));
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<BattleSpiritsCard>().
                               descriptions.costs.costs == int.Parse(dropdownFilter2)
                               select card;
        }
        if (type)
        {
            int optionValue = dropdownFilter[3].value;
            string dropdownFilter3 = string.Format("{0}", dropdownFilter[3].options[optionValue].text.Replace("ประเภท : ", ""));
            switch(dropdownFilter3)
            {
                case "สปีริต":
                    dropdownFilter3 = "Spirit";
                    break;
                case "เน็กซัส":
                    dropdownFilter3 = "Nexus";
                    break;
                case "เมจิก":
                    dropdownFilter3 = "Magic";
                    break;
            }
            findCardByFilter = from card in findCardByFilter
                               where card.GetComponent<BattleSpiritsCard>().
                               types.types.ToString() == dropdownFilter3
                               select card;
        }
        //  Add
        foreach (GameObject card in findCardByFilter)
        {
            print(card);
            DataCenter.instance.cardWithFilter.Add(card);
        }
        //  Create
        DataCenter.instance.CreateCardWithFilter();
    }
    private List<GameObject> GetRBCardList()
    {
        return DataCenter.instance.rbCardPrefabs;
    }
    private List<GameObject> GetBSCardList()
    {
        return DataCenter.instance.bsCardPrefabs;
    }
}