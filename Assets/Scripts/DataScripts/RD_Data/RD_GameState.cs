using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "ScriptableObjects/GameStateSO", order = 1)]
public class RD_GameState : ScriptableObject
{
    [Header("Current Game State")]
    public GameStateEnum CurrentState = GameStateEnum.MainMenu;

    // Örnek metodlar
    public void SetState(GameStateEnum newState)
    {
        CurrentState = newState;
        Debug.Log("Game State changed to: " + CurrentState);
    }

    public bool IsState(GameStateEnum stateToCheck)
    {
        return CurrentState == stateToCheck;
    }
}
