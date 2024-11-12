using UnityEngine;

[RequireComponent(typeof(DetectionZone))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private DetectionZone _detectionZone;

    private int _currentWaypoint = 0;
    private bool _isPlayerDetected = false;
    private Vector3 _playerPosition;

    private void Awake()
    {
        _detectionZone = GetComponent<DetectionZone>();
    }

    private void OnEnable()
    {
        _detectionZone.PlayerDetected += DetectPlayer;
        _detectionZone.PlayerEscaped += LosePlayer;
    }

    private void OnDisable()
    {
        _detectionZone.PlayerDetected -= DetectPlayer;
        _detectionZone.PlayerEscaped -= LosePlayer;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Sword>(out Sword _))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_isPlayerDetected)
        {
            Hunt();
        }
        else
        {
            Patrolling();
        }
    }

    private void DetectPlayer()
    {
        _isPlayerDetected = true;
    }

    private void LosePlayer()
    {
        _isPlayerDetected = false;
    }

    private void Hunt()
    {
        _playerPosition = _detectionZone.PlayerPosition;

        Rotate(_playerPosition);
        MoveTowards(_playerPosition);
    }

    private void Patrolling()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        Vector3 targetPosition = _waypoints[_currentWaypoint].position;

        Rotate(targetPosition);
        MoveTowards(targetPosition);
    }

    private void Rotate(Vector3 targetPosition)
    {
        int stationary = 0;
        float rotationX = 180f;

        if (targetPosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(stationary, stationary, stationary);
        }
        else
        {
            transform.rotation = Quaternion.Euler(stationary, rotationX, stationary);
        }
    }

    private void MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}