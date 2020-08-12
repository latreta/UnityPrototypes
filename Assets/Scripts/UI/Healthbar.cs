using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image bar;

    public void UpdateSize(float percentage)
    {
        bar.fillAmount = percentage;
    }

    private void OnEnable()
    {
        Health.healthChanged += UpdateSize;
    }
    
    private void OnDisable()
    {
        Health.healthChanged -= UpdateSize;
    }
}
