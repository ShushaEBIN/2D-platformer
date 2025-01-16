using System;
using UnityEngine;

[RequireComponent(typeof(Damager), typeof(Healer))]

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _minHealth = 0;
    private Damager _damager;
    private Healer _healher;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public event Action HealthChanged;
    
    private void Awake()
    {
        _damager = GetComponent<Damager>();
        _healher = GetComponent<Healer>();

        CurrentHealth = _maxHealth;
        MaxHealth = _maxHealth;
    }

    private void OnEnable()
    {
        _damager.Damaged += TakeDamage;
        _healher.Healthed += Heal;
    }

    private void OnDisable()
    {
        _damager.Damaged -= TakeDamage;
        _healher.Healthed -= Heal;
    }

    private void Start()
    {       
        HealthChanged?.Invoke();
    }

    private void TakeDamage()
    {
        CurrentHealth -= _damager.Damage;
        
        if (CurrentHealth <= _minHealth)
        {
            Destroy(gameObject);
        }        

        HealthChanged?.Invoke();
    }

    private void Heal()
    {
        CurrentHealth += _healher.Health;

        if (CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }

        HealthChanged?.Invoke();
    }
}