using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Hunger Hunger { get; private set; }
    public Health Health { get; private set; }
    public Thirsty Thirsty { get; private set; }
}
