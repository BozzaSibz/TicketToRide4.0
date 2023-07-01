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
    private RouteCardManager rcm; 

    public bool isSeenCard = false;

    //public int clickCounter; 

    private void Awake()
    {
        cm = GameObject.Find("Game").GetComponent<CardManager>(); 
    }

    private void Update()
    {
        if (cardIndex == 8 && isSeenCard)
        {
            gameObject.GetComponent<Button>().interactable = cm.clickCounter < 1;
        }
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
            if (cardIndex == 8)
            {
                cm.drawBtn.interactable = false;
                cm.seenCards.gameObject.SetActive(false); 
            }
            cm.ActionClicks();
            MoveToHand();
        }
        if (!isSeenCard)
        {
            
            
                Destroy(gameObject);
                cm.HandCards.Remove(gameObject);
                cm.P1Cards.Remove(gameObject);
                cm.P2Cards.Remove(gameObject);
            
        }
    }

    public void MoveToHand()
    {
        if (cm.isPlayerOneTurn)
        {
            Transform parent = cm.playerOneHand.transform;
            transform.SetParent(parent);
            cm.HandCards.Add(gameObject);
            cm.P1Cards.Add(gameObject);
            cm.SeenCards.Remove(gameObject);
            //cm.DeckCards.Remove(gameObject); 
        }
        if (!cm.isPlayerOneTurn)
        {
            Transform parent = cm.playerTwoHand.transform;
            transform.SetParent(parent);
            cm.HandCards.Add(gameObject);
            cm.P2Cards.Add(gameObject); 
            cm.SeenCards.Remove(gameObject);
            //cm.DeckCards.Remove(gameObject);
        }
        
    }


}