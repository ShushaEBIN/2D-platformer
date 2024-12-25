using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Ñollector _collector;

    private int _coins = 0;

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