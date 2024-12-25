using System;
using UnityEngine;

public class Healher : MonoBehaviour
{
    [SerializeField] private Ñollector _collector;

    public int Health { get; private set; }

    public event Action Healthed;

    private void OnEnable()
    {
        _collector.HealingPotionPickUped += GiveHeal;
    }

    private void OnDisable()
    {
        _collector.HealingPotionPickUped -= GiveHeal;
    }

    private void GiveHeal()
    {
        Health = _collector.HealValue;

        Healthed?.Invoke();
    }
}