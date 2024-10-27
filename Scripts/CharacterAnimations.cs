using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator _animator;

    public bool IsMoving { private get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }
}