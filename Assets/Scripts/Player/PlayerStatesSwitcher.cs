using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatesSwitcher : MonoBehaviour
{
    public UnityEvent<PlayerState> StateSwitch;
    private PlayerState _currentPlayerState;

    private void Start()
    {
        StateSwitch.AddListener(OnStateSwitch);
        SetCurrentPlayerState(PlayerState.PlayMode);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SetCurrentPlayerState(PlayerState.InventoryMode);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetCurrentPlayerState(PlayerState.PlayMode);
        }
    }
    public PlayerState GetCurrentPlayerState()
    {
        return _currentPlayerState;
    }
    public void SetCurrentPlayerState(PlayerState playerState)
    {
        _currentPlayerState = playerState;
        StateSwitch.Invoke(_currentPlayerState);
    }
    private void OnStateSwitch(PlayerState playerState)
    {
        switch (playerState)
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
