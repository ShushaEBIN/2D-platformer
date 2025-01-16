using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Health _health;
    [SerializeField] private Damager _damager;

    public int Damage { get; private set; }
    public Health Health { get; private set; }
    public Damager Damager { get; private set; }

    private void Start()
    {
        Damage = _damage;
        Health = _health;
        Damager = _damager;
    }
}