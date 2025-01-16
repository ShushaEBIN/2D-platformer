using System;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Ñollector _collector;
    [SerializeField] private Vampirism _vampirism;

    public float Health { get; private set; }

    public event Action Healthed;

    private void OnEnable()
    {
        _collector.HealingPotionPickUped += GiveHeal;
        _vampirism.Healed += HealVampirism;
    }

    private void OnDisable()
    {
        _collector.HealingPotionPickUped -= GiveHeal;
        _vampirism.Healed -= HealVampirism;
    }

    private void HealVampirism()
    {
        Health = _vampirism.Heal;

        Healthed?.Invoke();
    }

    private void GiveHeal()
    {
        Health = _collector.HealValue;

        Healthed?.Invoke();
    }
}