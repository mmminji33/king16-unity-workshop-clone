using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private CharacterMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<CharacterMovement>();
    }

    // Input Action의 "Move" 액션과 대응
    public void OnMove(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();
        _movement.SetDirection(inputVec);
    }

    // Input Action의 "Jump" 액션과 대응
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            _movement.Jump();
        }
    }
}