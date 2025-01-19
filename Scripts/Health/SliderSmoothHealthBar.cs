using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class SliderSmoothHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    protected override void ChangeValue()
    {
        StartCoroutine(ChangingValue());
    }

    private IEnumerator ChangingValue()
    {
        bool isChanging = true;
        float origin = _slider.value;
        float target = _health.CurrentHealth;
        float interpolator = 0;
        float delta = 4;
        var delay = new WaitForFixedUpdate();

        while (isChanging)
        {
            yield return delay;

            _slider.value = Mathf.Lerp(origin, target, interpolator);

            interpolator += delta * Time.deltaTime;

            if (Mathf.Approximately(origin, target))
            {
                isChanging = false;
            }
        }
    }
}