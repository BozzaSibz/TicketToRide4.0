using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Button RouteEndTurnButton;
    public PlayerTurnHandler turnHandler;

    private void Start()
    {
        RouteEndTurnButton.onClick.AddListener(SwitchTurns);
    }

    private void SwitchTurns()
    {
        turnHandler.SwitchTurns();
    }
}
