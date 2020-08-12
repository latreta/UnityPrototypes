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

    public delegate void HealthChangeDelegate(float amount);

    public delegate void OnDeathDelegate();
    
    
    public static HealthChangeDelegate healthChanged = delegate {};
    public static OnDeathDelegate onCharacterDeath = delegate { };

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
        onCharacterDeath += Die;
    }

    private void OnDisable()
    {
        Debug.Log("Destroying");
        onCharacterDeath -= Die;
    }

    private void Die()
    {
        Debug.Log("Dead");
        //Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        TakeDamage(lifeOverTime * Time.fixedDeltaTime);
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
    }
}
