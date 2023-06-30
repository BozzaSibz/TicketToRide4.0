using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTurnHandler : MonoBehaviour
{
    public Button[] buttons;

    public Text player1PointsText;
    public Text player1RoutesText;
    public Text player1TrainsText;

    public Text player2PointsText;
    public Text player2RoutesText;
    public Text player2TrainsText;

    public int[] buttonPoints;
    public int[] trainsRemaining;

    private int player1Points;
    private int player1Routes;
    private int player1Trains = 45;

    private int player2Points;
    private int player2Routes;
    private int player2Trains = 45;

    private bool isPlayer1Turn = true;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    private void OnButtonClick(int buttonIndex)
    {
        if (isPlayer1Turn)
        {
            UpdatePlayerData(buttonIndex, "PLAYER 1", ref player1Points, ref player1Routes, ref player1Trains,
                player1PointsText, player1RoutesText, player1TrainsText);
        }
        else
        {
            UpdatePlayerData(buttonIndex, "PLAYER 2", ref player2Points, ref player2Routes, ref player2Trains,
                player2PointsText, player2RoutesText, player2TrainsText);
        }

        // Toggle turn
        isPlayer1Turn = !isPlayer1Turn;
    }

    private void UpdatePlayerData(int buttonIndex, string player, ref int points, ref int routes, ref int trains,
        Text pointsText, Text routesText, Text trainsText)
    {
        int buttonPrice = buttonPoints[buttonIndex];
        points += buttonPrice;
        routes += 1;

        if (trainsRemaining[buttonIndex] <= trains)       // Check if there are enough remaining trains
        {
            trains -= trainsRemaining[buttonIndex];       // Decrease the trains count by the specified amount
            trainsRemaining[buttonIndex] = 0;
        }
        else
        {
            trainsRemaining[buttonIndex] -= trains;
            trains = 0;
        }

        pointsText.text ="POINTS: " + points.ToString();
        routesText.text ="CLAIMED ROUTES: " + routes.ToString();
        trainsText.text ="TRAINS REMAINING: " + trains.ToString();
    }

    public void SwitchTurns()
    {
        isPlayer1Turn = !isPlayer1Turn;
        
    }

}


