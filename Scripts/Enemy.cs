using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private bool _isRightMoving;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        Vector3 targetPosition = _waypoints[_currentWaypoint].position;

        Rotate(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    private void Rotate(Vector3 targetPosition)
    {
        int stationary = 0;
        float rotationX = 180f;

        if (targetPosition.x > transform.position.x)
        {
            _isRightMoving = true;
        }
        else
        {
            _isRightMoving = false;
        }

        if (_isRightMoving)
        {
            transform.rotation = Quaternion.Euler(stationary, stationary, stationary);
        }
        else
        {
            transform.rotation = Quaternion.Euler(stationary, rotationX, stationary);
        }
    }
}