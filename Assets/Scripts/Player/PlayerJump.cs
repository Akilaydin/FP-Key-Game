using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 3f;
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private LayerMask _groundLayer;

    private CharacterController _characterController;
    private Vector3 _jumpingVelocity;
    private bool _canJump; 

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void OnStateSwitch(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.InventoryMode:
                _canJump = false;
                break;
            case PlayerState.PlayMode:
                _canJump = true;
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if (_canJump == true)
        {
            _jumpingVelocity.y += _gravity * Time.deltaTime;
            if (_characterController.isGrounded == true)
            {
                _jumpingVelocity.y = 0;
            }

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                _jumpingVelocity.y += Mathf.Sqrt(_jumpForce * -2f * _gravity);
            }
            _characterController.Move(_jumpingVelocity * Time.deltaTime);
        }
    }
    private bool IsGrounded()
    {
        float rayLength = _characterController.height * 2;
        return (Physics.Raycast(transform.position, -transform.up, rayLength, _groundLayer));
    }
}
