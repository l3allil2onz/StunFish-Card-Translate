using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RebirthForYouSkill
{
    public enum Skills
    {
        None,
        AUTO,
        ACT,
        CANCEL,
        CONT
    }
    public Skills skill;
    public string skillDetails;
    public string[] skillConditions;
}
