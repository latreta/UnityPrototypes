using System.Collections.Generic;
using Inventory;
using Prototypes.Items;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Dictionary<Item, IInventoryItem> inventory = new Dictionary<Item, IInventoryItem>();

    private float weight = 0f;
}
