using System;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;

    public float Damage { get; private set; }

    public event Action Damaged;

    public void TakeDamage(float damage)
    {
        if (!_isPlayer)
        {
            Damage = damage;

            Damaged?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_isPlayer && collider.gameObject.TryGetComponent(out Sword sword))
        {
            Damage = sword.Damage;
            
            Damaged?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isPlayer && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Damage = enemy.Damage;

            Damaged?.Invoke();
        }
    }
}