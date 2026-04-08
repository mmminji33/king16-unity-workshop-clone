using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 12f;
    [SerializeField] private LayerMask groundMask;

    private Vector2 _nextDirection;
    private bool _isGround;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        _isGround = CheckIsGround();

        // 좌우 이동 처리
        Vector2 currentVelocity = new Vector2(_nextDirection.x * speed, 0);
        if (currentVelocity.magnitude > 0.01f)
        {
            Vector2 currMove = _rigidBody.position;
            Vector2 nextMove = currentVelocity * Time.fixedDeltaTime;
            _rigidBody.position = currMove + nextMove;
        }

        // 수직 속도 제한
        var v = _rigidBody.linearVelocity;
        if (Mathf.Abs(v.y) > 15.0f) 
        {
            v.y = v.y > 0f ? 15.0f : -15.0f;
        }
        _rigidBody.linearVelocity = v;
    }

    // Input Handler에서 호출할 메서드들
    public void SetDirection(Vector2 direction) => _nextDirection = direction;

    public void Jump()
    {
        if (_isGround)
        {
            float cancelForce = _rigidBody.linearVelocity.y * (-1) * _rigidBody.mass;
            _rigidBody.AddForce(Vector2.up * (cancelForce + jumpPower), ForceMode2D.Impulse);
            SoundManager.Instance.PlaySfx("SFX/Common/jump");
        }
    }

    private bool CheckIsGround()
    {
        Vector2 rayPos = new Vector2(_collider.bounds.center.x, _collider.bounds.min.y);
        RaycastHit2D rayHit = Physics2D.Raycast(rayPos, Vector2.down, 0.1f, groundMask);
        return rayHit.collider != null;
    }
}