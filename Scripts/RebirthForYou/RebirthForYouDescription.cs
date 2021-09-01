using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class RebirthForYouDescription
{
    public string serie;
    public int cost;
    public enum Types
    {
        None,คาแรคเตอร์,ReBirth
    }
    public Types type;
    public RebirthForYouRace[] races;
    public int attackDamage;
    public int defense;
}
[Serializable]
public class RebirthForYouRace
{
    public enum Races
    {
        None,
        ป๊อปปิ้นปาร์ตี้, ดนตรี, ช็อกโก้โคโรเนะ, โรเซเรีย, อัฟเตอร์โกลว,พาสเทล_พาเล็ต,เฮลโล_แฮ๊ปปี้_เวิร์ล
    }
    public Races race;
}
