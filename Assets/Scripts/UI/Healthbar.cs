using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : StatusBar
{
    private void OnEnable()
    {
        Health.healthChanged += UpdateSize;
    }
    
    private void OnDisable()
    {
        Health.healthChanged -= UpdateSize;
    }
}
