using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button switchButton;
    public Button[] buttons;
    public Image[] player1Images;
    public Image[] player2Images;

    private int currentPlayer;
    private int buttonIndex;

    private void Start()
    {
        currentPlayer = 1;
        buttonIndex = 0;

        switchButton.onClick.AddListener(OnSwitchButtonClick);

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnSwitchButtonClick()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
    }

    private void OnButtonClick(int buttonIndex)
    {
        if (buttonIndex >= buttons.Length)
            return;

        Image image = buttons[buttonIndex].GetComponent<Image>();
        Color targetColor = (currentPlayer == 1) ? Color.blue : Color.red;

        image.color = targetColor;
        image.gameObject.SetActive(true);
    }
}
