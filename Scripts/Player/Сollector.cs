using System;
using UnityEngine;

public class Сollector : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Player _player;

    public int CoinValue { get; private set; }
    public int HealValue { get; private set; }

    public event Action CoinPickUped;
    public event Action HealingPotionPickUped;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out HealingPotion healingPotion) &&
            _health.CurrentHealth < _health.MaxHealth)
        {
            HealValue = healingPotion.Heal;

            Destroy(healingPotion.gameObject);

            HealingPotionPickUped?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin = collision.gameObject.GetComponent<Coin>();
            CoinValue = coin.Value;

            Destroy(coin.gameObject);

            CoinPickUped?.Invoke();
        }
    }
}