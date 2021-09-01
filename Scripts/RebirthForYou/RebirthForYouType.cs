using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RebirthForYouType
{
    public enum Types
    {
        None,
        Character,
        Spark,
        Rebirth
    }
    public Types types;
}
