using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteCardManager: MonoBehaviour
{
    [SerializeField]
    private int RouteLength;

    public CardManager cardm;
    public Transform hand;
    public void FindCardIndex()
    {
        
        foreach (Transform card in hand)
        {
            int cardIndex = card.GetComponent<CardTemplate>().cardIndex;
        }
        //nt cardIndex = cardm.card.GetComponent<CardTemplate>().cardIndex;

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
