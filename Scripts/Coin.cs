using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _count = 10f;

    public event Action<Coin> Counted;

    private void Start()
    {
        StartCoroutine();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void StartCoroutine()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        yield return new WaitForSeconds(_count);

        Counted?.Invoke(this);
    }
}