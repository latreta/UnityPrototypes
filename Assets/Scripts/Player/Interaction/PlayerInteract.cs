using DefaultNamespace.Player;
using Interactables;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IRayProvider rayProvider;

    void Awake()
    {
        rayProvider = GetComponent<IRayProvider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rayProvider.Interact();
        }
    }
}
