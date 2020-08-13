using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public abstract class StatusBar: MonoBehaviour, IStatusBar
    {
        [SerializeField]
        private Image bar;
        
        public void UpdateSize(float percentage)
        {
            bar.fillAmount = percentage;
        }
    }
}