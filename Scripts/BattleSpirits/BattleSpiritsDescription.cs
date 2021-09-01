using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleSpiritsDescription
{
    public BattleSpiritsAttack[] attacks;
    public BattleSpiritsCost costs;
    public BattleSpiritsColor[] colors;
    public BattleSpiritsRace[] races;
}
[Serializable]
public class BattleSpiritsRace
{
    public enum Races
    {
        None,
        Avatar_เทพจำแลง, AncientDragon_มังกรโบราณ, Chrownos_มงกุฎเวลา,
        Clown_ตัวตลก, Primal_มายาก่อเกิด, Wanderer_คนพเนจร, Grandwalker
    }
    public Races races;
}
[Serializable]
public class BattleSpiritsCost
{
    public int costs;
    public int costReduces;
}
    [Serializable]
public class BattleSpiritsColor
{
    public enum Colors
    {
        None,
        Black,White,Blue,Cyan,Gray, 
        Green, Purple, Magenta,Red,Yellow
    }
    public Colors colorText;
}
[Serializable]
public class BattleSpiritsAttack
{
    public enum AttackLevels
    {
        None, Lv1,Lv2,Lv3
    }
    [Range(0,99999)]
    public int attackDamage;
    public AttackLevels attackLevels;
}
