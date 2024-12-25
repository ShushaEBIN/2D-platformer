using UnityEngine;

public class Sword : MonoBehaviour 
{
    [SerializeField] private int _damage = 40;

    public int Damage { get; private set; }

    private void Start()
    {
        Damage = _damage;
    }
}