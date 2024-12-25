using UnityEngine;

public class HealingPotion : MonoBehaviour 
{
    [SerializeField] private int _heal;

    public int Heal { get; private set; }

    private void Start()
    {
        Heal = _heal;
    }
}