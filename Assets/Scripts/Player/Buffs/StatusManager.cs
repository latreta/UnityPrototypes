using System;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Hunger))]
public class StatusManager: MonoBehaviour
{
    private Health health;
    private Hunger hunger;
    private Thirst thirst;

    public delegate void ApplyHealthBuffDelegate(Buff buff);

    public delegate void ApplyHungerBuffDelegate(Buff buff);

    public static ApplyHealthBuffDelegate onHealthBuffApplied = delegate { };
    public static ApplyHungerBuffDelegate onHungerBuffApplied = delegate { };
    
    private void Awake()
    {
        health = GetComponent<Health>();
        hunger = GetComponent<Hunger>();
        if (health == null)
        {
            ConsoleWarn("Health component not found.");
        }

        if (hunger == null)
        {
            ConsoleWarn("Hunger component not found");
        }
        
    }

    public void ApplyBuff(Buff buff)
    {
        switch (buff.type)
        {
            case StatusType.HEALTH:
                onHealthBuffApplied.Invoke(buff);
                break;
            case StatusType.HUNGER:
                onHungerBuffApplied.Invoke(buff);
                break;
        }
    }

    private void ConsoleWarn(string message)
    {
        Debug.LogWarning(message);
    }
}
