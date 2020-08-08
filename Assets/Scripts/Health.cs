using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private Healthbar healthbar;
    float timeElapsed = 0f;
    [SerializeField]
    float lifeOverTime = 0.1f;
    [SerializeField]
    private float CurrentHealth;

    public delegate void HealthChangeDelegate(float amount);

    public static HealthChangeDelegate healthChanged = delegate {};

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        TakeDamage(lifeOverTime * Time.fixedDeltaTime);
    }

    private void TakeDamage(float amount)
    {
        Debug.Log("Taking damage");
        CurrentHealth -= amount;
        float currentHealthPct = CurrentHealth / maxHealth;
        healthChanged?.Invoke(currentHealthPct);
    }
}
