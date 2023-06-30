using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Destination;

public class DestinationTemplate : MonoBehaviour
{
 
    public Image desImg;

    public int desIndex;

    public Destination des;
    private CardManager cm;
    private CardTemplate ct;
    public bool isDesCard;
    public bool isPlayer1Card; 

    private void Awake()
    {
        cm = GameObject.Find("Game").GetComponent<CardManager>();
    }

    //private void Start()
    //{
    //    DestinationCheck(); 
    //}

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
                isPlayer1Card = true; 
            }
        }
        if (!cm.isPlayerOneTurn)
        {
            Transform p2 = cm.playerTwoHand.transform;
            transform.SetParent(p2);
            if (!cm.HandCards.Contains(gameObject))
            {
                cm.HandCards.Add(gameObject);
                isDesCard = true;
                isPlayer1Card = false; 
            }
        }
    }

    //public void DestinationCheck()
    //{

    //    for (int i = 0; i < cm.des.Length; i++)
    //    {
    //        City1 city1 = cm.des[i].city1;
    //        City2 city2 = cm.des[i].city2;
    //        // Use the enum value as needed
    //        Debug.Log("Enum value for object " + i + ": " + city1 + "and" + city2);

    //        if (cm.des[i].city1 == City1.Dallas && cm.des[i].city2 == City2.NewYork)
    //        {

    //            Debug.Log("card " + i + " Contains cities " + city1 + " and " + city2);
    //            //    if (Route1 == isActiveAndEnabled)
    //            //    {
    //            //        Debug.Log("Destination Card Compleated");
    //            //    }
    //        }
    //    }



    //}

}
