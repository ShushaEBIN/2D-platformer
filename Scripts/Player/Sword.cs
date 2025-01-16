using UnityEngine;

public class Sword : MonoBehaviour 
{
    [SerializeField] private float _damage = 40;

    public float Damage { get; private set; }

    private void Start()
    {
        Damage = _damage;
    }
}