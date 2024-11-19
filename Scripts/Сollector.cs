using System;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class Сollector : MonoBehaviour
{
    private Player _player;

    public int CoinValue { get; private set; }

    public event Action CoinPickUped;
    public event Action HealingPotionPickUped;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out HealingPotion healingPotion) && _player.Health < _player.MaxHealth)
        {
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