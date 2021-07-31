using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [Range(-250f,250f)]
    [SerializeField]
    private float _sensetivity = -5f;
    [SerializeField]
    private Transform _playerCamera;

    private float _camRotation = 0f;
    private bool _canLook;
    private void Update()
    {
        if (_canLook == true)
        {
            _camRotation = Mathf.Clamp(_camRotation + Input.GetAxis("Mouse Y") * _sensetivity, -89f, 89f);
            _playerCamera.localEulerAngles = new Vector3(_camRotation, 0, 0);
        }
    }

    public void OnStateSwitch(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.InventoryMode:
                _canLook = false;
                break;
            case PlayerState.PlayMode:
                _canLook = true;
                break;
            default:
                break;
        }
    }
}
