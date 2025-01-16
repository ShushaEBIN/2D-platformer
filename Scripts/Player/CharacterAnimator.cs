using UnityEngine;

[RequireComponent (typeof(Animator))]

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private AnimationClip _swordAttack;

    private Animator _animator;
    private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
    private readonly int _isSwordAttackHash = Animator.StringToHash("IsSwordAttack");

    public bool IsMoving { private get; set; }
    public bool IsSwordAttack { private get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void PlayMove()
    {
        _animator.SetBool(_isMovingHash, IsMoving);
    }

    public void PlayAttack()
    {
        _animator.SetBool(_isSwordAttackHash, IsSwordAttack);
    }

    public float ReturnSwordAttackLength()
    {
        return _swordAttack.length;
    }
}