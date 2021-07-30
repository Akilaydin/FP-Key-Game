using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 3f;

    [SerializeField]
    private float _gravity = -9.8f;

    private CharacterController _characterController;
    private Vector3 _jumpingVelocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log(_characterController.isGrounded);
        _jumpingVelocity.y += _gravity * Time.deltaTime;
        if (_characterController.isGrounded == true)
        {
            _jumpingVelocity.y = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _jumpingVelocity.y += Mathf.Sqrt(_jumpForce * -2f * _gravity);
        }
        _characterController.Move(_jumpingVelocity * Time.deltaTime);
    }
}
