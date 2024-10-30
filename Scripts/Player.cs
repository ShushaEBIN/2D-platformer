using UnityEngine;

[RequireComponent(typeof(Coin))]

public class Player : MonoBehaviour
{
    private int _coins = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();

            _coins += coin.Value;

            print($"Монеты: {_coins}");
        }
    }
}