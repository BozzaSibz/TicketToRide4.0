using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFilter : MonoBehaviour
{
    private CardManager cm;
    public Card.Colour colour;

    private void Awake()
    {
        cm = GameObject.Find("Game").GetComponent<CardManager>();
    }

    //public void FilterButton()
    //{
    //    cm.LoadCards(colour);
    //    cm.HandCards.Remove(gameObject);
    //}

}
