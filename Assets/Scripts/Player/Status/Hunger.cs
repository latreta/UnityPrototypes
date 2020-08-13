﻿using System;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    float maxHunger = 100f;
    [SerializeField]
    [Range(0.1f,100f)]
    float hungerOverTime = 0.1f;
    [SerializeField]
    [Range(0,100f)]
    float CurrentHunger;

    private float timeElapsed = 0f;
    [SerializeField]
    [Tooltip("Tick Damage time in seconds")]
    [Range(0f,100f)]
    private float tickTime = 5f;
    
    public delegate void OnHungerChangedDelegate(float amount);
    public delegate void OnHungerFullDelegate();

    public static event OnHungerChangedDelegate hungerChanged = delegate { };
    public static OnHungerFullDelegate maxHungerReached = delegate { };
    
    void OnEnable()
    {
        CurrentHunger = maxHunger;
    }

    private void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
        if (timeElapsed >= tickTime)
        {
            IncreaseHunger(hungerOverTime);
        }
    }

    public void IncreaseHunger(float amount)
    {
        CurrentHunger -= amount;
        if (CurrentHunger <= 0)
        {
            CurrentHunger = 0f;
            maxHungerReached?.Invoke();
        }
        float currentHealthPct = CurrentHunger / maxHunger;
        hungerChanged?.Invoke(currentHealthPct);
        timeElapsed = 0f;
    }
}