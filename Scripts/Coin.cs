using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _count = 10f;
    [SerializeField] private int _minValue = 1;
    [SerializeField] private int _maxValue = 10;

    public int Value { get; private set; }

    public event Action<Coin> Counted;

    private IEnumerator Start()
    {
        Value = UnityEngine.Random.Range(_minValue, _maxValue + 1);

        yield return new WaitForSeconds(_count);

        Counted?.Invoke(this);
    }
}