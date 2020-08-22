using Interactables;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class FirstPersonRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float rayDistance = 2f;
        public void Interact()
        {
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }
    }
}