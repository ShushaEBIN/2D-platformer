using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private int _damage;

    public int Damage { get; private set; }

    private void Start()
    {
        Damage = _damage;
    }
}