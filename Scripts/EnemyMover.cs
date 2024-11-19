using UnityEngine;

[RequireComponent(typeof(DetectionZone))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private DetectionZone _detectionZone;

    private int _currentWaypoint = 0;
    private Vector3 _playerPosition;
    private EnemyState _currentState;

    private enum EnemyState { Patrolling, Hunting}

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

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyState.Patrolling:
                Patrolling();
                break;
            case EnemyState.Hunting:
                Hunt();
                break;
        }
    }

    private void DetectPlayer()
    {
        _currentState = EnemyState.Hunting;
    }

    private void LosePlayer()
    {
        _currentState = EnemyState.Patrolling;
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