using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    public Card[] card;
    public Destination[] des;
    public GameObject template;
    public GameObject desTemplate;
    public Transform seenCards;
    public Transform playerOneHand;
    public Transform playerTwoHand;
    public Transform deck;
    public Transform destinationDeck;
    public Transform destinationDrawn;
    public Transform p1ScrollRect;
    public Transform p2ScrollRect;
    public int cardsInDeckNum;
    public GameObject doneObj;
    public Button doneBtn;
    public List<GameObject> HandCards = new List<GameObject>();
    public List<GameObject> SeenCards = new List<GameObject>();
    //public List<GameObject> DeckCards = new List<GameObject>(); 
    private Transform currentPlayerHand;
    public bool isPlayerOneTurn;
    public Button drawBtn;
    public int clickCounter;
    public int filterCounter;
    public TMP_Text FilterTxt;
    private DestinationTemplate dTemplate;


    private void Start()
    {
        currentPlayerHand = playerOneHand;
        isPlayerOneTurn = true;
        LoadCards();
        LoadDes();
        for (int i = 0; i < 4; i++)
        {
            GenerateP1();
            GenerateP2();
        }
        DestinationCheck(); 
    }

    private void Update()
    {
        int cardCount = seenCards.childCount;
        if (cardCount < 5)
        {
            GenerateSeenCard();
        }

        if (deck.childCount == 0)
        {
            Debug.Log("No more cards in the deck.");
            LoadCards();
            return;
        }

        if (destinationDeck.childCount == 0)
        {
            Debug.Log("No more cards in destinations.");
            LoadDes();
            return;
        }

        if (destinationDrawn.childCount < 3)
        {
            doneBtn.interactable = true;
        }

        HandCardFalse();
    }

    public void LoadCards()
    {
        for (int j = 0; j < cardsInDeckNum; j++)
        {
            for (int i = 0; i < card.Length; i++)
            {
                GameObject obj = Instantiate(template, deck);
                CardTemplate cardTemplate = obj.GetComponent<CardTemplate>();
                cardTemplate.cardIndex = i;
                cardTemplate.Display(card[i]);
                obj.SetActive(false);
                //DeckCards.Add(obj); 
            }
        }
        OutputCardIndexes();
    }

    public void LoadDes()
    {
        for (int i = 0; i < des.Length; i++)
        {
            GameObject objD = Instantiate(desTemplate, destinationDeck);
            dTemplate = objD.GetComponent<DestinationTemplate>();
            dTemplate.desIndex = i;
            dTemplate.DisplayDes(des[i]);
            objD.SetActive(false);
        }
    }

    //public void DrawCard()
    //{
    //    //randomly select a card from the deck
    //    int randomIndex = Random.Range(0, deck.childCount);
    //    Transform selectedCard = deck.GetChild(randomIndex);

    //    //instantiate the selected card as a drawn card
    //    GameObject drawnCard;

    //    //checks if drawn card goes to players hand or refills seen card deck
    //    int cardCount = seenCards.childCount;
    //    if (cardCount < 5)
    //    {
    //        drawnCard = Instantiate(template, seenCards);
    //    }
    //    else
    //    {
    //        drawnCard = Instantiate(template, playerOneHand);
    //    }

    //    CardTemplate drawnCardTemplate = drawnCard.GetComponent<CardTemplate>();
    //    drawnCardTemplate.cardIndex = selectedCard.GetComponent<CardTemplate>().cardIndex;
    //    drawnCardTemplate.Display(selectedCard.GetComponent<CardTemplate>().card);

    //    //add the drawn card to the handCards list
    //    HandCards.Add(drawnCard);

    //    //removes the selected card from the deck
    //    Destroy(selectedCard.gameObject);


    //}

    public void DrawCard()
    {
        // Randomly select a card from the deck
        int randomIndex = Random.Range(0, deck.childCount);
        Transform selectedCard = deck.GetChild(randomIndex);

        // Instantiate the selected card as a drawn card
        GameObject drawnCard = Instantiate(template, currentPlayerHand);

        CardTemplate drawnCardTemplate = drawnCard.GetComponent<CardTemplate>();
        drawnCardTemplate.cardIndex = selectedCard.GetComponent<CardTemplate>().cardIndex;
        drawnCardTemplate.Display(selectedCard.GetComponent<CardTemplate>().card);

        // Add the drawn card to the handCards list
        HandCards.Add(drawnCard);
        //DeckCards.Remove(drawnCard); 

        // Remove the selected card from the deck
        Destroy(selectedCard.gameObject);

        ActionClicks();
        //if (clickCounter == 2 )
        //{
        //    drawBtn.interactable = false;
        //    seenCards.gameObject.SetActive(false); 
        //}


        //// Switch to the next player's hand
        //if (currentPlayerHand == playerOneHand)
        //{
        //    currentPlayerHand = playerTwoHand;
        //}
        //else
        //{
        //    currentPlayerHand = playerOneHand;
        //}
    }


    private void GenerateSeenCard()
    {
        //randomly select a card from the deck
        int randomIndex = Random.Range(0, deck.childCount);
        Transform selectedCard = deck.GetChild(randomIndex);

        //instantiate the selected card as a seen card
        GameObject seenCard = Instantiate(template, seenCards);

        CardTemplate seenCardTemplate = seenCard.GetComponent<CardTemplate>();
        seenCardTemplate.cardIndex = selectedCard.GetComponent<CardTemplate>().cardIndex;
        seenCardTemplate.Display(selectedCard.GetComponent<CardTemplate>().card);

        //removes the selected card from the deck
        Destroy(selectedCard.gameObject);

        seenCardTemplate.isSeenCard = true;

        SeenCards.Add(seenCard);
        //DeckCards.Remove(seenCard); 

    }

    private void GenerateP1()
    {
        //randomly select a card from the deck
        int randomIndex = Random.Range(0, deck.childCount);
        Transform selectedCard = deck.GetChild(randomIndex);

        //instantiate the selected card as a seen card
        GameObject deal1 = Instantiate(template, playerOneHand);

        CardTemplate seenCardTemplate = deal1.GetComponent<CardTemplate>();
        seenCardTemplate.cardIndex = selectedCard.GetComponent<CardTemplate>().cardIndex;
        seenCardTemplate.Display(selectedCard.GetComponent<CardTemplate>().card);

        //removes the selected card from the deck
        Destroy(selectedCard.gameObject);

        HandCards.Add(deal1);
        //DeckCards.Remove(deal1); 
    }

    private void GenerateP2()
    {
        //randomly select a card from the deck
        int randomIndex = Random.Range(0, deck.childCount);
        Transform selectedCard = deck.GetChild(randomIndex);

        //instantiate the selected card as a seen card
        GameObject deal2 = Instantiate(template, playerTwoHand);

        CardTemplate seenCardTemplate = deal2.GetComponent<CardTemplate>();
        seenCardTemplate.cardIndex = selectedCard.GetComponent<CardTemplate>().cardIndex;
        seenCardTemplate.Display(selectedCard.GetComponent<CardTemplate>().card);

        //removes the selected card from the deck
        Destroy(selectedCard.gameObject);

        //playerTwoHand.gameObject.SetActive(false); 

        HandCards.Add(deal2);
        //DeckCards.Remove(deal2);
    }

    public void DestinationDraw()
    {
        doneObj.SetActive(true);
        doneBtn.interactable = false;
        if (destinationDrawn.childCount == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                //randomly select a destination from the deck
                int randomIndex = Random.Range(0, destinationDeck.childCount);
                Transform selectedDes = destinationDeck.GetChild(randomIndex);

                //instantiate the selected card
                GameObject drawnDes;

                drawnDes = Instantiate(desTemplate, destinationDrawn);

                DestinationTemplate drawnDesTemplate = drawnDes.GetComponent<DestinationTemplate>();
                drawnDesTemplate.desIndex = selectedDes.GetComponent<DestinationTemplate>().desIndex;
                drawnDesTemplate.DisplayDes(selectedDes.GetComponent<DestinationTemplate>().des);

                //removes the selected card from the deck
                Destroy(selectedDes.gameObject);
            }
        }
        else
        {
            Debug.Log("You cannot draw more than 3 cards in a turn.");
        }
    }

    public void DesDone(Transform desParent)
    {
        int childCount = desParent.childCount;
        if (destinationDrawn.childCount < 3)
        {
            for (int i = childCount - 1; i >= 0; i--)
            {
                Transform child = desParent.GetChild(i);
                Destroy(child.gameObject);
            }
        }
        else
        {
            Debug.Log("You must select at least one destination card.");
        }
        doneObj.SetActive(false);
    }

    public void HandCardFalse()
    {
        int childCount = playerOneHand.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = playerOneHand.GetChild(i);
            CardTemplate cardTemplate = child.GetComponent<CardTemplate>();
            if (cardTemplate != null)
            {
                cardTemplate.isSeenCard = false;
            }
        }
    }

    public void OutputCardIndexes()
    {
        Debug.Log("Hand Cards:");
        for (int i = 0; i < HandCards.Count; i++)
        {
            GameObject cardObject = HandCards[i];
            CardTemplate cardTemplate = cardObject.GetComponent<CardTemplate>();
            int cardIndex = cardTemplate.cardIndex;
            Debug.Log(cardIndex);
        }

        Debug.Log("Seen Cards:");
        for (int i = 0; i < SeenCards.Count; i++)
        {
            GameObject cardObject = SeenCards[i];
            CardTemplate cardTemplate = cardObject.GetComponent<CardTemplate>();
            int cardIndex = cardTemplate.cardIndex;
            Debug.Log(cardIndex);
        }
    }

    public void EndTurn()
    {
        // Switch to the next player's hand
        if (currentPlayerHand == playerOneHand)
        {
            currentPlayerHand = playerTwoHand;
            isPlayerOneTurn = false;
            Debug.Log(currentPlayerHand);
            playerOneHand.gameObject.SetActive(false);
            p1ScrollRect.gameObject.SetActive(false);
            playerTwoHand.gameObject.SetActive(true);
            p2ScrollRect.gameObject.SetActive(true);

        }
        else
        {
            currentPlayerHand = playerOneHand;
            isPlayerOneTurn = true;
            Debug.Log(currentPlayerHand);
            playerTwoHand.gameObject.SetActive(false);
            p2ScrollRect.gameObject.SetActive(false);
            playerOneHand.gameObject.SetActive(true);
            p1ScrollRect.gameObject.SetActive(true);
        }
        clickCounter = 0;
        drawBtn.interactable = true;
        seenCards.gameObject.SetActive(true);

        filterCounter = 7;
        filterTrainCard();
    }

    public void FilterHandBlue()

    {
        for (int i = 0; i < HandCards.Count; i++)
        {
            GameObject cardObject = HandCards[i];
            CardTemplate cardTemplate = cardObject.GetComponent<CardTemplate>();
            int cardIndex = cardTemplate.cardIndex;
            Debug.Log(cardIndex);
            cardObject.SetActive(false);

            if (cardIndex == 0)
            {
                cardObject.SetActive(true);
            }
        }
    }

    public void FilterHandAll()
    {
        for (int i = 0; i < HandCards.Count; i++)
        {
            GameObject cardObject = HandCards[i];
            CardTemplate cardTemplate = cardObject.GetComponent<CardTemplate>();
            int cardIndex = cardTemplate.cardIndex;
            Debug.Log(cardIndex);

            cardObject.SetActive(true);
        }
    }

    public void ActionClicks()
    {
        clickCounter++;
        Debug.Log("click");

        switch (clickCounter)
        {
            case 1:
                // First click logic
                Debug.Log("First click");
                break;

            case 2:
                // Second click logic
                Debug.Log("Second click");
                drawBtn.interactable = false;
                seenCards.gameObject.SetActive(false);
                break;
        }

    }


    public void filterTrainCard()
    {
        filterCounter++;
        filterCounter = filterCounter % 9;

        Debug.Log("click");
        Transform hand;

        if (isPlayerOneTurn)
        {
            hand = playerOneHand;
        }
        else
        {
            hand = playerTwoHand;
        }

        foreach (Transform card in hand)
        {
            int cardIndex = card.GetComponent<CardTemplate>().cardIndex;

            if (cardIndex == filterCounter || cardIndex == 8)
            {
                card.gameObject.SetActive(true);
            }
            else
            {
                card.gameObject.SetActive(false);
            }
            if (filterCounter == 8)
                card.gameObject.SetActive(true);
        }

        switch (filterCounter)
        {
            case 0:
                FilterTxt.text = "Black";
                break;
            case 1:
                FilterTxt.text = "Blue";
                break;
            case 2:
                FilterTxt.text = "Green";
                break;
            case 3:
                FilterTxt.text = "Orange";
                break;
            case 4:
                FilterTxt.text = "Pink";
                break;
            case 5:
                FilterTxt.text = "Red";
                break;
            case 6:
                FilterTxt.text = "White";
                break;
            case 7:
                FilterTxt.text = "Yellow";
                break;
            case 8:
                FilterTxt.text = "Filter";
                break;


            default:
                FilterTxt.text = "Filter";
                break;
        }

    }

    //public bool TrainRoutes()
    //{

    //}

    public void DestinationCheck()
    {
        for (int i = 0; i < des.Length; i++)
        {
            des[i].index = i; 
            
            Debug.Log(i);
        }
       
    }
}
