using Prototypes.Items;

namespace Inventory
{
    public interface IInventoryItem
    {
        Item GetItem();
        bool Use();
        string GetName();
        bool IsConsumable();
        int GetAmount();

        void IncreaseAmount(int amount);
    }
}