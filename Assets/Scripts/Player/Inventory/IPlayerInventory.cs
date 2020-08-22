namespace Inventory
{
    public interface IPlayerInventory
    {
        void AddItem();
        void RemoveItem();
        void Use();
        
        bool CanAdd();
        
        bool isOverweight();
        float GetWeight();
        float SetWeight();
        
    }
}