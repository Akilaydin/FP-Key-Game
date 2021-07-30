using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatesController : MonoBehaviour
{
    private PlayerState _currentPlayerState;

    private void Start()
    {
        _currentPlayerState = PlayerState.PlayMode;
    }

    public PlayerState GetCurrentPlayerState()
    {
        return _currentPlayerState;
    }
    public void SetCurrentPlayerState(PlayerState playerState)
    {
        _currentPlayerState = playerState;
    }
    private void Update()
    {
        switch (_currentPlayerState)
        {
            case PlayerState.InventoryMode:
                ShowCursor();
                break;
            case PlayerState.PlayMode:
                HideCursor();
                break;
        }
    }
    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void ShowCursor() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
