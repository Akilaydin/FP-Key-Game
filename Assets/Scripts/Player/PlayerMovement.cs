using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10f;
    [SerializeField]
    private float _turnSpeed = 5f;
    [SerializeField]
    private float sprintMultiplier = 1.5f;

    private CharacterController _characterController;
    private bool _canMove = true;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (_canMove == true)
        {
            Vector3 movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _characterController.Move(movement * playerSpeed * sprintMultiplier * Time.deltaTime);
            }
            else
            {
                _characterController.Move(movement * playerSpeed * Time.deltaTime);
            }
            transform.Rotate(0, _turnSpeed * Input.GetAxis("Mouse X"), 0);
        }
    }
    public void OnStateSwitch(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.InventoryMode:
                _canMove = false;
                break;
            case PlayerState.PlayMode:
                _canMove = true;
                break;
        }
    }
}
