using UnityEngine;

[RequireComponent(typeof(Ñollector))]

public class Player : MonoBehaviour
{
    private int _coins = 0;
    private Ñollector _collector;

    private void Awake()
    {
        _collector = GetComponent<Ñollector>();
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