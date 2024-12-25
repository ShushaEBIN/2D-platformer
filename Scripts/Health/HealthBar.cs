using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected int _currentHealth;
    protected int _maxHealth;
    protected Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
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