using UnityEngine;
using UnityEngine.UI;

public class HungerBar: MonoBehaviour
{
    [SerializeField]
    private Image bar;

    public void UpdateSize(float percentage)
    {
        bar.fillAmount = percentage;
        Debug.Log("Updating hunger bar: " + percentage);
    }

    private void OnEnable()
    {
        Hunger.hungerChanged += UpdateSize;
        Debug.Log("Subscribing");
    }
    
    private void OnDisable()
    {
        Hunger.hungerChanged -= UpdateSize;
    }
}
