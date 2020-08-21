using Interactables;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera firstPersonCamera;

    private void FixedUpdate()
    {
        if (firstPersonCamera != null)
        {
            Interact();
        }
    }

    private void Interact()
    {
        Ray ray = firstPersonCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 2f))
        {
            IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}
