using Prototypes.Items;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class InventoryItem: IInventoryItem
    {
        private Item item;
        private int amount;

        public InventoryItem(Item item, int amount = 1)
        {
            this.item = item;
            this.amount = amount;
        }

        public Item GetItem()
        {
            return item;
        }

        public bool Use()
        {
            if (item.isConsumable)
                amount = Mathf.Max(amount - 1, 0);

            return amount <= 0;
        }
        
        public string GetName()
        {
            return item.name;
        }

        public bool IsConsumable()
        {
            return item.isConsumable;
        }

        public int GetAmount()
        {
            return amount;
        }

        public void IncreaseAmount(int amount)
        {
            this.amount += amount;
        }
    }
}