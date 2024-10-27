using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _coins++;

            print($"Монеты: {_coins}");
        }
    }
}