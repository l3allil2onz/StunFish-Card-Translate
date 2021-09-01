using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCardGamePage : MonoBehaviour
{
    public void GetNumber(int cardIndex)
    {
        PageController.instance.selectedCardIndex = cardIndex;
        MenuController.instance.Card();
        DataCenter.instance.AddCardToField();
    }
    public void BackToCardList()
    {
        if (PageController.instance.selectedCardIndex > -1)
        {
            MenuController.instance.Card();
            DataCenter.instance.AddCardToField();
        }
    }
}
