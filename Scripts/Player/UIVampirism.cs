using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Flipper))]

public class UIVampirism : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vampirism _vampirism;

    private float _maxValueSlider = 1;
    private float _minValueSlider = 0;
    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _vampirism.Actived += DecreaseValue;
        _vampirism.Used += IncreaseValue;
    }

    private void OnDisable()
    {
        _vampirism.Actived -= DecreaseValue;
        _vampirism.Used -= IncreaseValue;
    }

    private void IncreaseValue()
    {
        StartCoroutine(ChangingValue(_maxValueSlider, _vampirism.TimeRecharge));
    }

    private void DecreaseValue()
    {
        StartCoroutine(ChangingValue(_minValueSlider, _vampirism.TimeOfAbility));
    }

    private IEnumerator ChangingValue(float target, float durationTime)
    {
        bool isChanging = true;
        float origin = _slider.value;
        float interpolator = 0f;
        float elapsedTime = 0f;
        var delay = new WaitForFixedUpdate();

        while (isChanging)
        {
            yield return delay;

            elapsedTime += Time.deltaTime;

            interpolator = elapsedTime / durationTime;

            _slider.value = Mathf.Lerp(origin, target, interpolator);

            if (Mathf.Approximately(origin, target))
            {
                isChanging = false;
            }
        }
    }
}