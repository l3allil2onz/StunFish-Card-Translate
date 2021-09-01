using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class RebirthForYouCard : MonoBehaviour
{
    private Sprite cardImage;
    public int cardNumber;
    public string cardId;
    public string cardBox;
    public string cardName;
    public RebirthForYouType types;
    public RebirthForYouSkill[] skills;
    public RebirthForYouDescription descriptions;

    private int descriptTextSlotAmount;

    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => {
            LoadRBCardDataByNumber();
            transform.GetComponent<OpenPage>().OpenDescriptionPage();
        });
    }
    private void LoadRBCardDataByNumber()
    {
        descriptTextSlotAmount = FindTextSlotAmountInField();
        cardImage = transform.GetChild(0).GetComponent<Image>().sprite;
        CardDescriptionPage.instance.textSlotAmount = descriptTextSlotAmount;
        CardDescriptionPage.instance.cardImg.sprite = cardImage;
        CardDescriptionPage.instance.bigImg.sprite = cardImage;
        CardDescriptionPage.instance.gameCardImg.sprite = DataCenter.instance.logo[1];
        CardDescriptionPage.instance.topPanelText.text = string.Format("{0}\n{1}", cardName, cardId);
        CardDescriptionPage.instance.CreateTextSlotInField();
        SkillTextPattern();
        DescriptionTextPattern();
    }
    private int FindTextSlotAmountInField()
    {
        int tempAmount = 0;
        if (descriptions.serie.Length > 0)
        {
            tempAmount++;
        }
        if (descriptions.cost > 0)
        {
            tempAmount++;
        }
        if (descriptions.type > 0)
        {
            tempAmount++;
        }
        if (descriptions.races.Length > 0)
        {
            tempAmount++;
        }
        if (descriptions.attackDamage > 0)
        {
            tempAmount++;
        }
        if (descriptions.defense > 0)
        {
            tempAmount++;
        }
        return tempAmount;
    }
    private void SkillTextPattern()
    {
        string strPattern = string.Format("\n\n");
        if (skills.Length > 0)
        {
            for(int index = 0; index < skills.Length; index++)
            {
                if(skills[index].skill > 0)
                {
                    strPattern += string.Format("<b>[ {0} ] </b>", skills[index].skill);
                }
                if(skills[index].skillDetails.Length > 0)
                {
                    strPattern += string.Format("{0}", skills[index].skillDetails);
                }
                if(skills[index].skillConditions.Length > 0)
                {
                    strPattern += string.Format("<b> ( </b>");
                    for (int conIndex = 0; conIndex < skills[index].skillConditions.Length; conIndex++)
                    {
                        if (conIndex == skills[index].skillConditions.Length - 1)
                        {
                            strPattern += string.Format("{0}", skills[index].skillConditions[index]);
                        }
                        else
                        {
                            strPattern += string.Format("{0}<b>, </b>", skills[index].skillConditions[index]);
                        }
                    }
                    strPattern += string.Format("<b> )</b>");
                }
                strPattern += string.Format("\n\n");
            }
        }
        CardDescriptionPage.instance.skillPanelText.text = strPattern;
    }
    private void DescriptionTextPattern()
    {
        //  Setting Text
        if (descriptTextSlotAmount > 0)
        {
            bool isSerieSetting = false,
                isCostSetting = false,
                isTypeSetting = false,
                isRaceSetting = false,
                isAtkSetting = false,
                isDefSetting = false;
            for (int index = 0; index < descriptTextSlotAmount; index++)
            {
                if (descriptions.serie.Length > 0 && !isSerieSetting)
                {
                    string strPattern = string.Format("<b>Serie : </b>{0}", descriptions.serie);
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isSerieSetting = true;
                    continue;
                }
                if (descriptions.cost > 0 && !isCostSetting)
                {
                    string strPattern = string.Format("<b>Cost : </b>{0}", descriptions.cost);
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isCostSetting = true;
                    continue;
                }
                if (descriptions.type > 0 && !isTypeSetting)
                {
                    string strPattern = string.Format("<b>Type : </b>{0}", descriptions.type);
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isTypeSetting = true;
                    continue;
                }
                if (descriptions.races.Length > 0 && !isRaceSetting)
                {
                    string strPattern = "<b>Race : </b>";
                    for (int raceIndex = 0; raceIndex < descriptions.races.Length; raceIndex++)
                    {
                        if (raceIndex == descriptions.races.Length - 1)
                        {
                            strPattern += string.Format("{0}", descriptions.races[raceIndex].race.ToString().Replace("_"," "));
                        }
                        else
                        {
                            strPattern += string.Format("{0}<b>,</b> ", descriptions.races[raceIndex].race.ToString().Replace("_", " "));
                        }
                    }
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isRaceSetting = true;
                    continue;
                }
                if (descriptions.attackDamage > 0 && !isAtkSetting)
                {
                    string strPattern = string.Format("<b>Attack Damage : </b>{0}", descriptions.attackDamage);
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isAtkSetting = true;
                    continue;
                }
                if (descriptions.defense > 0 && !isDefSetting)
                {
                    string strPattern = string.Format("<b>Defense : </b>{0}", descriptions.defense);
                    CardDescriptionPage.instance.textSlots[index].text = strPattern;
                    isDefSetting = true;
                    continue;
                }
            }
        }
    }
}
