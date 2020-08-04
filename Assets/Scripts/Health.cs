using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private Healthbar healthbar;
    float timeElapsed = 0f;

    public int CurrentHealth { get; private set; }

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 5f)
        {
            TakeDamage(-5);
            timeElapsed = 0f;
        }
    }

    private void TakeDamage(int amount)
    {
        Debug.Log("Taking damage");
        CurrentHealth += amount;
        float currentHealthPct = (float)CurrentHealth / (float)maxHealth;
        healthbar.UpdateSize(currentHealthPct);
    }
}
