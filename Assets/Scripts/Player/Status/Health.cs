using System;
using System.Collections;
using DefaultNamespace.Player.Status;
using UnityEngine;

public class Health : MonoBehaviour, IStatus
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    float lifeOverTime = 0.1f;
    [SerializeField]
    private float CurrentHealth;

    private Coroutine currentBuff = null;

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

    public void ApplyBuff(Buff buff)
    {

        if (currentBuff == null)
        {
            currentBuff = StartCoroutine("HandleBuff", buff);
        }

    }

    public IEnumerator HandleBuff(Buff buff)
    {
        var previousValue = maxHealth;
        maxHealth = buff.isDebuff ? maxHealth - buff.amount : maxHealth + buff.amount;
        yield return new WaitForSeconds(buff.duration);
        maxHealth = previousValue;
        currentBuff = null;
        yield return null;
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
