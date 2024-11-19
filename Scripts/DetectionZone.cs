using System;
using UnityEngine;

public class DetectionZone : MonoBehaviour 
{
    public Vector3 PlayerPosition { get; private set; }

    public event Action PlayerDetected;
    public event Action PlayerEscaped;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            PlayerPosition = player.transform.position;

            PlayerDetected?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player _))
        {
            PlayerEscaped?.Invoke();
        }
    }
}