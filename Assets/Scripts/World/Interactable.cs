using UnityEngine;

namespace Interactables
{
    public class Interactable: MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log(gameObject.name);
        }
    }
}