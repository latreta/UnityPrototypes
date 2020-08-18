using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private List<IBuff> appliedBuffs;

    private void Start()
    {
        appliedBuffs = new List<IBuff>();
    }

    void AddBuff(IBuff buff)
    {
        appliedBuffs.Add(buff);
    }

    void RemoveBuff(IBuff buff)
    {
        appliedBuffs.Remove(buff);
    }
}
