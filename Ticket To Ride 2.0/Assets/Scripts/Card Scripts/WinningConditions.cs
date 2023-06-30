using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningConditions : MonoBehaviour
{
    public PlayerTurnHandler pth;
    public TMP_Text WinnerTxt;
    public GameObject endOfGamePanel;
    public GameObject CalcPointsPanel; 
    private CardManager cm;
    private DestinationTemplate dt;
    public Transform desEndP1;
    public Transform desEndP2;

    private void Start()
    {
        EndOfGame(); 
    }

    public void EndOfGame()
    {
        //if (pth.player1Trains < 2 || pth.player2Trains < 2)
        //{
            //endOfGamePanel.SetActive(true);
            CalcPointsPanel.SetActive(true); 

            if (dt.isDesCard && dt.isPlayer1Card)
            {
                Transform p1 = desEndP1.transform;
                transform.SetParent(p1);
            }
            if (dt.isDesCard && !dt.isPlayer1Card)
            {
                Transform p2 = desEndP2.transform;
                transform.SetParent(p2);
            }
            
            if (pth.player1Points > pth.player2Points)
            {
                WinnerTxt.text = "Player 1 Wins";
            }
            if (pth.player1Points < pth.player2Points)
            {
                WinnerTxt.text = "Player 2 Wins";
            }
        //}
    }
}
