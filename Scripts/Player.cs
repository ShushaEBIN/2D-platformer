using UnityEngine;

[RequireComponent(typeof(Coin))]

public class Player : MonoBehaviour
{
    private int _coins = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin)) 
        {
            coin = collision.gameObject.GetComponent<Coin>();

            _coins += coin.Value;

            Destroy(coin.gameObject);

            print($"Монеты: {_coins}");
        }
    }
}