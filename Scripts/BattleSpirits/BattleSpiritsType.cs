using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BattleSpiritsType
{
    public enum Types
    {
        None,
        Spirit,
        Nexus,
        Magic
    }
    public Types types;
}
