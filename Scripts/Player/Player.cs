using UnityEngine;

[RequireComponent(typeof(�ollector))]

public class Player : MonoBehaviour
{
    private int _coins = 0;
    private �ollector _collector;

    private void Awake()
    {
        _collector = GetComponent<�ollector>();
    }

    private void OnEnable()
    {
        _collector.CoinPickUped += AddCoins;
    }

    private void OnDisable()
    {
        _collector.CoinPickUped -= AddCoins;
    }

    private void AddCoins()
    {
        _coins += _collector.CoinValue;
    }
}