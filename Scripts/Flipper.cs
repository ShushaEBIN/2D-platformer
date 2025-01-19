using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private List<Transform> _transform;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _transform.Count; i++)
        {
            _transform[i].rotation = _camera.transform.rotation;
        }        
    }
}