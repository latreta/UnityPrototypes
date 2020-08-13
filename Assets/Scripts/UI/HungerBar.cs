using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar: StatusBar
{
    private void OnEnable()
    {
        Hunger.hungerChanged += UpdateSize;
    }
    
    private void OnDisable()
    {
        Hunger.hungerChanged -= UpdateSize;
    }
}