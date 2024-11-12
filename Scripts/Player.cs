using UnityEngine;

[RequireComponent(typeof(Coin))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _minHealth = 1;

    private int _health;
    private int _coins = 0;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<HealingPotion>(out HealingPotion healingPotion))
        {
            if (_health != _maxHealth)
            {
                _health++;

                Destroy(healingPotion.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin)) 
        {
            coin = collision.gameObject.GetComponent<Coin>();

            _coins += coin.Value;

            Destroy(coin.gameObject);

            print($"Монеты: {_coins}");
        }
        else if (collision.gameObject.TryGetComponent<Enemy>(out Enemy _))
        {
            _health--;

            print(_health);

            if (_health < _minHealth)
            {
                print("Смерть игрока");
            }
        }        
    }
}