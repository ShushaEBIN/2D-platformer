using UnityEngine;

[RequireComponent(typeof(Ñollector))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    private int _coins = 0;
    private Ñollector _collector;

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    private void Awake()
    {
        _collector = GetComponent<Ñollector>();
    }

    private void OnEnable()
    {
        _collector.HealingPotionPickUped += Heal;
        _collector.CoinPickUped += AddCoins;
    }

    private void OnDisable()
    {
        _collector.HealingPotionPickUped -= Heal;
        _collector.CoinPickUped -= AddCoins;
    }

    private void Start()
    {
        Health = _maxHealth;
        MaxHealth = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy _))
        {
            Health--;
        }
    }

    private void Heal()
    {
        Health++;
    }

    private void AddCoins()
    {
        _coins += _collector.CoinValue;
    }
}