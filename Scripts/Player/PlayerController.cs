using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterAnimations))]
[RequireComponent(typeof(InputHandler))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private bool _isMoving;
    private bool _isAttacking = false;
    private Rigidbody2D _rigidbody;
    private CharacterAnimations _animations;
    private InputHandler _inputHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponent<CharacterAnimations>();
        _inputHandler = GetComponent<InputHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _isGrounded = false;
        }
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        int stationary = 0;
        float direction = _inputHandler.ReturnHorizontalInput();

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
        _animations.PlayMove();
    }

    private void Jump()
    {
        if (_isGrounded && _inputHandler.ReturnJumpPressed())
        {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Attack()
    {
        if (_inputHandler.ReturnAttackPressed() && _isAttacking == false)
        {           
            _isAttacking = true;
            SetAttackStatus(_isAttacking);

            StartCoroutine(ResetAttack());
        }
    }

    private void SetAttackStatus(bool isAttacking)
    {
        _animations.IsSwordAttack = isAttacking;
        _animations.PlayAttack();
    }

    private IEnumerator ResetAttack()
    {
        float timeOfAttack = _animations.ReturnSwordAttackLength();

        yield return new WaitForSeconds(timeOfAttack);

        _isAttacking = false;
        SetAttackStatus(_isAttacking);
    }
}