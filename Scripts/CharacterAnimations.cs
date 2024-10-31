using UnityEngine;

[RequireComponent (typeof(Animator))]

public class CharacterAnimations : MonoBehaviour
{
    private Animator _animator;
    private readonly int _isMovingHash = Animator.StringToHash("IsMoving");

    public bool IsMoving { private get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void PlayMove()
    {
        _animator.SetBool(_isMovingHash, IsMoving);
    }
}