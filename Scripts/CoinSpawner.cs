using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Vector2 _spawnPositionMin = new Vector2(-15, 5);
    [SerializeField] private Vector2 _spawnPositionMax = new Vector2(15, 6);
    [SerializeField] private float _repeatRate = 5f;
    [SerializeField] private int _poolCapacity = 50;
    [SerializeField] private int _poolMaxCapacity = 50;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (coin) => SpawnCoin(coin),
        actionOnRelease: (coin) => coin.gameObject.SetActive(false),
        actionOnDestroy: (coin) => Delete(coin),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxCapacity);
    }

    private void Start()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            _pool.Get();

            yield return wait;
        }
    }

    private void SpawnCoin(Coin coin)
    {
        coin.Counted += SendToPool;

        coin.transform.position = GetRandomPosition();
        coin.gameObject.SetActive(true);
    }

    private Vector2 GetRandomPosition()
    {
        float positionX = Random.Range(_spawnPositionMin.x, _spawnPositionMax.x);
        float positionY = Random.Range(_spawnPositionMin.y, _spawnPositionMax.y);

        return new Vector2(positionX, positionY);
    }

    private void SendToPool(Coin coin)
    {
        coin.Counted -= SendToPool;

        _pool.Release(coin);
    }

    private void Delete(Coin coin)
    {
        coin.Counted -= SendToPool;

        Destroy(coin);
    }
}