using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardTemplate : MonoBehaviour
{
    public TMP_Text titleTxt;
    public Image trainImg;

    public int cardIndex;

    public Card card;
    private CardManager cm;

    public bool isSeenCard = false;

    private void Awake()
    {
        cm = GameObject.Find("Game").GetComponent<CardManager>(); 
    }

    public void Display(Card card)
    {
        this.card = card;
        titleTxt.text = card.title;
        trainImg.sprite = card.image;
    }

    public void CardClick()
    {
        if (isSeenCard)
        {
            MoveToHand(); 
        }
        if (!isSeenCard)
        {
            Destroy(gameObject);
            cm.HandCards.Remove(gameObject);
        }
    }

    public void MoveToHand()
    {
        if (cm.isPlayerOneTurn)
        {
            Transform parent = cm.playerOneHand.transform;
            transform.SetParent(parent);
            cm.HandCards.Add(gameObject);
            cm.SeenCards.Remove(gameObject);
            //cm.DeckCards.Remove(gameObject); 
        }
        if (!cm.isPlayerOneTurn)
        {
            Transform parent = cm.playerTwoHand.transform;
            transform.SetParent(parent);
            cm.HandCards.Add(gameObject);
            cm.SeenCards.Remove(gameObject);
            //cm.DeckCards.Remove(gameObject);
        }
        
    }
}