using Interactables;
using UnityEngine;

public class Pickupable : MonoBehaviour, IPickupable
{
    public void PickupItem(Transform parent)
    {
        transform.parent = parent;
    }

    public void DropItem()
    {
        transform.parent = null;
        transform.Translate(transform.forward);
    }
}
