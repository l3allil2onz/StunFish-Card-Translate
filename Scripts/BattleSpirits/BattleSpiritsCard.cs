using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class BattleSpiritsCard : MonoBehaviour
{
    private Sprite cardImage;
    public int cardNumber;
    public string cardId;
    public string cardBox;
    public string cardName;
    public BattleSpiritsType types;
    public BattleSpiritsSkill[] skills;
    public BattleSpiritsDescription descriptions;

    private int descriptTextSlotAmount;

    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => { LoadBSCardDataByNumber();
            transform.GetComponent<OpenPage>().OpenDescriptionPage(); });
    }
    public void LoadBSCardDataByNumber()
    {
        descriptTextSlotAmount = FindTextSlotAmountInField();
        cardImage = transform.GetChild(0).GetComponent<Image>().sprite;
        CardDescriptionPage.instance.textSlotAmount = descriptTextSlotAmount;
        CardDescriptionPage.instance.cardImg.sprite = cardImage;
        CardDescriptionPage.instance.bigImg.sprite = cardImage;
        CardDescriptionPage.instance.gameCardImg.sprite = DataCenter.instance.logo[0];
        CardDescriptionPage.instance.topPanelText.text = string.Format("{0}\n{1}", cardName, cardId);
        CardDescriptionPage.instance.CreateTextSlotInField();
        SkillTextPattern();
        DescriptionTextPattern();
    }
    private int FindTextSlotAmountInField()
    {
        int tempAmount = 0;
        if(descriptions.attacks.Length > 0)
        {
            tempAmount++;
        }
        if(descriptions.costs.costs > 0)
        {
            tempAmount++;
        }
        if(descriptions.colors.Length > 0)
        {
            tempAmount++;
        }
        if(descriptions.races.Length > 0)
        {
            tempAmount++;
        }
        return tempAmount;
    }
    private void DescriptionTextPattern()
    {
        //  Setting Text
        bool atkIsSetting = false,
            costIsSetting = false,
            colorIsSetting = false,
            raceIsSetting = false;
        for (int j = 0; j < descriptTextSlotAmount; j++)
        {
            //  attack
            if (descriptions.attacks.Length > 0 && !atkIsSetting)
            {
                string strPattern = "";
                for (int atkLv = 0; atkLv < descriptions.attacks.Length; atkLv++)
                {
                    if (atkLv != descriptions.attacks.Length - 1)
                    {
                        strPattern += string.Format("<b>{0} : </b>{1}<b>, </b>",
                            descriptions.attacks[atkLv].attackLevels,
                            descriptions.attacks[atkLv].attackDamage);
                    }
                    else
                    {
                        strPattern += string.Format("<b>{0} : </b>{1}",
                            descriptions.attacks[atkLv].attackLevels,
                            descriptions.attacks[atkLv].attackDamage);
                    }
                }
                CardDescriptionPage.instance.textSlots[j].text = strPattern;
                atkIsSetting = true;
                continue;
            }
            //  cost
            if ((descriptions.costs.costs > 0 && descriptions.costs.costReduces == 0) && !costIsSetting)
            {
                string strPattern = "";
                strPattern += string.Format("<b>Cost : </b>{0}",
                    descriptions.costs.costs,
                    descriptions.costs.costReduces);
                CardDescriptionPage.instance.textSlots[j].text = strPattern;
                costIsSetting = true;
                continue;
            }
            else if((descriptions.costs.costs > 0 && descriptions.costs.costReduces > 0) && !costIsSetting)
            {
                string strPattern = "";
                strPattern += string.Format("<b>Cost : </b>{0}(-{1})",
                    descriptions.costs.costs,
                    descriptions.costs.costReduces);
                CardDescriptionPage.instance.textSlots[j].text = strPattern;
                costIsSetting = true;
                continue;
            }
            //  color
            if (descriptions.colors.Length > 0 && !colorIsSetting)
            {
                string strPattern = string.Format("<b>Color : </b>");
                for (int colorAmount = 0; colorAmount < descriptions.colors.Length; colorAmount++)
                {
                    if (colorAmount != descriptions.colors.Length - 1)
                    {
                        strPattern += string.Format("{0}<b>, </b>", descriptions.colors[colorAmount].colorText);
                    }
                    else
                    {
                        strPattern += string.Format("{0}", descriptions.colors[colorAmount].colorText);
                    }
                }
                CardDescriptionPage.instance.textSlots[j].text = strPattern;
                colorIsSetting = true;
                continue;
            }
            //  race
            if(descriptions.races.Length > 0 && !raceIsSetting)
            {
                string strPattern = string.Format("<b>Race : </b>");
                for (int raceAmount = 0; raceAmount < descriptions.races.Length; raceAmount++)
                {
                    if (raceAmount != descriptions.races.Length - 1)
                    {
                        strPattern += string.Format("{0}<b>, </b>", descriptions.races[raceAmount].races.ToString().Replace("_"," "));
                    }
                    else
                    {
                        strPattern += string.Format("{0}", descriptions.races[raceAmount].races.ToString().Replace("_", " "));
                    }
                }
                CardDescriptionPage.instance.textSlots[j].text = strPattern;
                raceIsSetting = true;
                continue;
            }
        }
    }
    private void SkillTextPattern()
    {
        string strPattern = string.Format("\n\n");
        if (skills.Length > 0)
        {
            for (int skillIndex = 0; skillIndex < skills.Length; skillIndex++)
            {
                //  Levels
                if (skills[skillIndex].levels > 0)
                {
                    strPattern += string.Format("<b>( {0} ) </b>", skills[skillIndex].levels.ToString().Replace("_","-"));
                }
                //  Skills + Condition + Cost
                if (skills[skillIndex].skills > 0 &&
                    skills[skillIndex].skillConditions.Length == 0 &&
                    skills[skillIndex].skillCosts == 0)
                {
                    strPattern += string.Format("<b>[ {0} ] :</b>\n", skills[skillIndex].skills.ToString().Replace("_", " "));
                }
                else if (skills[skillIndex].skills > 0 &&
                        skills[skillIndex].skillConditions.Length == 0 &&
                        skills[skillIndex].skillCosts > 0)
                {
                    strPattern += string.Format("<b>[ {0} : {1} ] :</b>\n", skills[skillIndex].skills.ToString().Replace("_", " "), skills[skillIndex].skillCosts.ToString().Replace("_", " "));
                }
                else if (skills[skillIndex].skills > 0 &&
                        skills[skillIndex].skillConditions.Length > 0 &&
                        skills[skillIndex].skillCosts == 0)
                {
                    strPattern += string.Format("<b>[ {0} - </b>", skills[skillIndex].skills.ToString().Replace("_", " "));
                    for (int conditionIndex = 0; conditionIndex < skills[skillIndex].skillConditions.Length; conditionIndex++)
                    {
                        if (conditionIndex == skills[skillIndex].skillConditions.Length - 1)
                        {
                            strPattern += string.Format("<b>{0}</b>", skills[skillIndex].skillConditions[conditionIndex]);
                        }
                        else
                        {
                            strPattern += string.Format("<b>{0}, </b>", skills[skillIndex].skillConditions[conditionIndex]);
                        }
                    }
                    strPattern += string.Format("<b> ] :</b>\n");
                }
                else if (skills[skillIndex].skills > 0 &&
                        skills[skillIndex].skillConditions.Length > 0 &&
                        skills[skillIndex].skillCosts > 0)
                {
                    strPattern += string.Format("<b>[[ {0} : {1} ] - </b>", skills[skillIndex].skills.ToString().Replace("_", " "), skills[skillIndex].skillCosts.ToString().Replace("_", " "));
                    for (int conditionIndex = 0; conditionIndex < skills[skillIndex].skillConditions.Length; conditionIndex++)
                    {
                        if (conditionIndex == skills[skillIndex].skillConditions.Length - 1)
                        {
                            strPattern += string.Format("<b>{0}</b>", skills[skillIndex].skillConditions[conditionIndex]);
                        }
                        else
                        {
                            strPattern += string.Format("<b>{0}, </b>", skills[skillIndex].skillConditions[conditionIndex]);
                        }
                    }
                    strPattern += string.Format("<b> ] :</b>\n");
                }
                else if (skills[skillIndex].skills <= 0 &&
                        skills[skillIndex].skillConditions.Length <= 0 &&
                        skills[skillIndex].skillCosts <= 0)
                {
                    strPattern += string.Format("\n");
                }
                //  Skill details
                if (skills[skillIndex].levels <= 0 &&
                   skills[skillIndex].skills <= 0 &&
                   skills[skillIndex].skillConditions.Length <= 0 &&
                   skills[skillIndex].skillCosts <= 0)
                {
                    strPattern += string.Format("<b>Skill :</b> {0}\n", skills[skillIndex].skillsDetails);
                }
                else
                {
                    strPattern += string.Format("- {0}\n", skills[skillIndex].skillsDetails);
                }
                strPattern += string.Format("\n");
            }
        }
        CardDescriptionPage.instance.skillPanelText.text = strPattern;
    }
}
