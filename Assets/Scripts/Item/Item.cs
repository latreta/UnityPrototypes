using UnityEngine;

namespace Prototypes.Items
{
    [CreateAssetMenu(fileName = "NewCommonItem", menuName = "Item/Common", order = 0)]
    public class Item : ScriptableObject
    {
        public new string name;
        public bool isConsumable;
        public Sprite inventoryImage;
    }
}