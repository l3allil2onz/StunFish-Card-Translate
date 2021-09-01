using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPage : MonoBehaviour
{
    public static CardPage instance;
    public GameObject fieldCard;
    private void Awake()
    {
        instance = this;
        fieldCard = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
    }
}
