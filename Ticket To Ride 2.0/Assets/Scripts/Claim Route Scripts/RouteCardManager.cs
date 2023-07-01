using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteCardManager: MonoBehaviour
{
    [SerializeField]
    private int RouteLength;
    [SerializeField]
    private int RouteColour; 
    public CardManager cm;
    public bool canClaimCard; 
    public void FindCardIndex()
    {
        int countBlack= 0;
        int countBlue= 0;
        int countGreen = 0;
        int countOrange = 0;
        int countPink = 0;
        int countRed= 0;
        int countWhite = 0;
        int countYellow = 0;

        if (cm.isPlayerOneTurn)
        {
            IList list = cm.P1Cards;
            for (int i = 0; i < list.Count; i++)
            {
                Transform card = (Transform)list[i];
                int cardIndex = card.GetComponent<CardTemplate>().cardIndex;
                if (cardIndex == 0)
                {
                    countBlack++;
                }
                if (cardIndex == 1)
                {
                    countBlue++;
                }
                if (cardIndex == 2)
                {
                    countGreen++;
                }
                if (cardIndex == 3)
                {
                    countOrange++;
                }
                if (cardIndex == 4)
                {
                    countPink++;
                }
                if (cardIndex == 5)
                {
                    countRed++;
                }
                if (cardIndex == 6)
                {
                    countWhite++;
                }
                if (cardIndex == 7)
                {
                    countYellow++;
                }
            }
            if (RouteColour == 0)
            {
                if (countBlack == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 1)
            {
                if (countBlue == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 2)
            {
                if (countGreen == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 3)
            {
                if (countOrange == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 4)
            {
                if (countPink == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 5)
            {
                if (countRed == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 6)
            {
                if (countWhite == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 7)
            {
                if (countYellow == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
        }
        if (!cm.isPlayerOneTurn)
        {
            IList list = cm.P2Cards;
            for (int i = 0; i < list.Count; i++)
            {
                Transform card = (Transform)list[i];
                int cardIndex = card.GetComponent<CardTemplate>().cardIndex;
                if (cardIndex == 0)
                {
                    countBlack++;
                }
                if (cardIndex == 1)
                {
                    countBlue++;
                }
                if (cardIndex == 2)
                {
                    countGreen++;
                }
                if (cardIndex == 3)
                {
                    countOrange++;
                }
                if (cardIndex == 4)
                {
                    countPink++;
                }
                if (cardIndex == 5)
                {
                    countRed++;
                }
                if (cardIndex == 6)
                {
                    countWhite++;
                }
                if (cardIndex == 7)
                {
                    countYellow++;
                }
            }
            if (RouteColour == 0)
            {
                if (countBlack == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 1)
            {
                if (countBlue == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 2)
            {
                if (countGreen == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 3)
            {
                if (countOrange == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 4)
            {
                if (countPink == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 5)
            {
                if (countRed == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 6)
            {
                if (countWhite == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
            if (RouteColour == 7)
            {
                if (countYellow == RouteLength)
                {
                    canClaimCard = true;
                }
                else
                {
                    canClaimCard = false;
                }
            }
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
