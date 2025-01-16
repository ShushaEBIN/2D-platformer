using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _timeOfAbility;
    [SerializeField] private float _timeRecharge;
    [SerializeField] private float _checkRate;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private SpriteRenderer _radiusSprite;

    private bool _isReady = true;

    public float Heal { get; private set; }

    public event Action Healed;

    private void Awake()
    {
        _radiusSprite.enabled = false;
        UpdateRadius();
    }

    public void CheckReadinessOfVampirism()
    {
        if (_isReady)
        {
            StartCoroutine(ActivateAbility());
        }
    }

    private void SearchEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);

        Enemy nearestEnemy = null;
        float shortestEnemy = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance < shortestEnemy)
                {
                    shortestEnemy = distance;
                    nearestEnemy = enemy;
                }
            }
        }
        
        if (nearestEnemy != null)
        {
            float limitedDamage = _damage;

            if (nearestEnemy.Health.CurrentHealth < _damage)
            {
                limitedDamage = nearestEnemy.Health.CurrentHealth;
            }

            nearestEnemy.Damager.TakeDamage(limitedDamage);

            Heal = limitedDamage;
            Healed?.Invoke();
        }
    }

    private IEnumerator ActivateAbility()
    {
        float elapsedTime = 0f;
        float timeDamage = 0f;

        _isReady = false;

        _radiusSprite.enabled = true;

        while (elapsedTime < _timeOfAbility)
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime >= timeDamage)
            {
                SearchEnemy();

                timeDamage += _checkRate;
            }

            yield return null;
        }

        StartCoroutine(ResetAbility());
    }

    private IEnumerator ResetAbility()
    {
        _radiusSprite.enabled = false;

        yield return new WaitForSeconds(_timeRecharge);

        _isReady = true;
    }

    private void UpdateRadius()
    {
        Vector3 spriteVector = new Vector3(_radius, _radius, _radius);

        _radiusSprite.transform.localScale = spriteVector;
    }
}