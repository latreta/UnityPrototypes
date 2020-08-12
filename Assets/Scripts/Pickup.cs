using System;
using DefaultNamespace;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
        var pickupAble = hit.gameObject.GetComponent<IPickupable>();
        pickupAble?.Interact();
    }
    
}
