using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DestinationTemplate : MonoBehaviour
{
 
    public Image desImg;

    public int desIndex;

    public Destination des;
    private CardManager cm;
    private CardTemplate ct; 

    private void Awake()
    {
        cm = GameObject.Find("Game").GetComponent<CardManager>();
    }

    public void DisplayDes(Destination des)
    {
        this.des = des;
        desImg.sprite = des.imageD;
    }

    public void CardClick()
    {
        if (cm.isPlayerOneTurn)
        {
            Transform p1 = cm.playerOneHand.transform;
            transform.SetParent(p1);
            if (!cm.HandCards.Contains(gameObject))
            {
                cm.HandCards.Add(gameObject);
            }
        }
        if (!cm.isPlayerOneTurn)
        {
            Transform p2 = cm.playerTwoHand.transform;
            transform.SetParent(p2);
            if (!cm.HandCards.Contains(gameObject))
            {
                cm.HandCards.Add(gameObject);
            }
        }
        
       
    }

}
