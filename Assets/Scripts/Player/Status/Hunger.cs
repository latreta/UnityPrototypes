using System;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    float maxHunger = 100f;
    [SerializeField]
    float hungerOverTime = 0.1f;
    [SerializeField]
    float CurrentHunger;
    
    public delegate void OnHungerChangedDelegate(float amount);
    public delegate void OnHungerFullDelegate();

    public static OnHungerChangedDelegate hungerChanged = delegate { };
    public static OnHungerFullDelegate maxHungerReached = delegate { };
    
    void OnEnable()
    {
        CurrentHunger = maxHunger;
    }
    private void FixedUpdate()
    {
        IncreaseHunger(hungerOverTime * Time.fixedDeltaTime);
    }

    public void IncreaseHunger(float amount)
    {
        Debug.Log("Getting hungry");
        CurrentHunger -= amount;
        if (CurrentHunger - amount <= 0)
        {
            maxHungerReached?.Invoke();
        }
        float currentHealthPct = CurrentHunger / maxHunger;
        hungerChanged?.Invoke(CurrentHunger);
    }
}
