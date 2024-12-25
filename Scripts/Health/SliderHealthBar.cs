using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    protected override void ChangeValue()
    {
        _slider.value = _health.CurrentHealth;
    }
}