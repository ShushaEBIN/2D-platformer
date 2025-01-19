using UnityEngine;

[RequireComponent(typeof(Flipper))]

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected float _currentHealth;
    protected float _maxHealth;
    protected Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
    }

    private void Start()
    {
        _maxHealth = _health.MaxHealth;
    }

    protected abstract void ChangeValue();
}