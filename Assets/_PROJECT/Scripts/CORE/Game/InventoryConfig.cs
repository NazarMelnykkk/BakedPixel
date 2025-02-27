using UnityEngine;

[CreateAssetMenu(fileName = "InventoryConfig", menuName = "Character/Inventory/InventoryConfig")]
public class InventoryConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public InventoryWeight InventoryWeight { get; private set; } 
    [field: SerializeField] public int MaxSlots { get; private set; } = 30;
    [field: SerializeField] public int LockedSlots { get; private set; } = 15;
    [field: SerializeField] public int SlotUnlockPrice { get; private set; } = 5; 
}
