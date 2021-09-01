using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleSpiritsSkill
{
    public enum Levels
    {
        None,
        Lv1,
        Lv2,
        Lv3,
        Lv1_Lv2,
        Lv2_Lv3,
        Lv1_Lv2_Lv3
    }
    public enum Skills
    {
        None,
        Reborn,
        Core_Charge,
        Grand_Field,
        Grand_Skill,
        Burst,
        Flash,
        Main
    }
    public enum SkillCosts
    {
        None,
        Cost_1, Cost_2, Cost_3, Cost_4, Cost_5,
        Cost_6, Cost_7, Cost_8, Cost_9, Cost_10
    }
    public enum CountTypes
    {
        
        None,
        Equal,LessThan,GreaterThan,
        LessThanEqual, GreaterThanEqual
    }
    
    public Levels levels;
    public Skills skills;
    public string skillsDetails;
    public SkillCosts skillCosts;
    public string[] skillConditions;
}
