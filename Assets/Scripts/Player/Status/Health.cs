using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    float lifeOverTime = 0.1f;
    [SerializeField]
    private float CurrentHealth;

    private float timeElapsed = 0f;

    private Boolean isHungry = false;

    public delegate void HealthChangeDelegate(float amount);

    public delegate void OnDeathDelegate();

    public static event HealthChangeDelegate healthChanged = delegate {};
    public static OnDeathDelegate onCharacterDeath = delegate { };

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
        onCharacterDeath += Die;
        Hunger.maxHungerReached += MaxHungerReached;
    }

    private void MaxHungerReached()
    {
        isHungry = true;
    }

    private void OnDisable()
    {
        onCharacterDeath -= Die;
        Hunger.maxHungerReached -= MaxHungerReached;
    }

    private void Die()
    {
        Debug.Log("Dead");
    }

    void FixedUpdate()
    {
        if (isHungry)
        {
            TakeDamage(lifeOverTime * Time.fixedDeltaTime);
        }
    }

    private void TakeDamage(float amount)
    {
        Debug.Log("Taking damage");
        CurrentHealth -= amount;
        if (CurrentHealth - amount <= 0)
        {
            onCharacterDeath?.Invoke();
            return;
        }
        float currentHealthPct = CurrentHealth / maxHealth;
        healthChanged?.Invoke(currentHealthPct);
        timeElapsed = 0f;
    }
}
