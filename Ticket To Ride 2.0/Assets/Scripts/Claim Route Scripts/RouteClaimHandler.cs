using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteClaimHandler : MonoBehaviour
{
   
        public Button[] buttons;   

        public Text pointsText;    
        public Text routesText;    
        public Text trainsText;

        public int[] buttonPoints; 
        public int[] trainsRemaining;

        private int points;        
        private int routes;        
        private int trains = 45;



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


            pointsText.text = "POINTS: " + points.ToString();
            routesText.text = "CLAIMED ROUTES: " + routes.ToString();
            trainsText.text = "TRAINS REMAINING: " + trains.ToString();

            
        }
        private void UpdateTrainsRemainingText()
        {
            string trainsRemainingText = "TRAINS REMAINING: ";

            for (int i = 0; i < trainsRemaining.Length; i++)
            {
                trainsRemainingText += trainsRemaining[i].ToString();

                if (i < trainsRemaining.Length - 1)
                {
                    trainsRemainingText += ", ";
                }
            }
            trainsText.text = trainsRemainingText;
        }


    }

