using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterAnimations))]

public class PlayerController : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _playerSprite;

    private bool _isGrounded;
    private bool _isMoving;
    private Rigidbody2D _rigidbody;
    private CharacterAnimations _animations;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponent<CharacterAnimations>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        int stationary = 0;
        float direction = Input.GetAxis(Horizontal);

        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

        _isMoving = direction != stationary;

        if (_isMoving)
        {
            if (direction > stationary)
            {
                transform.rotation = Quaternion.Euler(stationary, stationary, stationary);
            }
            else if (direction < stationary)
            {
                float rotationX = 180f;

                transform.rotation = Quaternion.Euler(stationary, rotationX, stationary);
            }
        }

        _animations.IsMoving = _isMoving;
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}