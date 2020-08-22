using UnityEngine;

namespace Prototypes.Items
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Item/Weapon", order = 0)]
    public class Weapon : Item
    {
        public WeaponType weaponType;
    }
}