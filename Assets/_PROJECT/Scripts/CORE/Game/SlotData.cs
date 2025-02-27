using System;
using UnityEngine;

[Serializable]
public class SlotData 
{
    [field: SerializeField] public int SlotID { get; private set; }
    [field: SerializeField] public Protected Protected { get; set; }
    [field: SerializeField] public ItemData ItemData { get; set; }

    public SlotData(int slotID, Protected slotProtected, ItemData itemData = null)
    {
        SlotID = slotID;
        Protected = slotProtected;
        ItemData = itemData; 
    }
}

[Serializable]
public class Protected
{
    [field: SerializeField] public bool IsLocked{ get; private set; } = false;
    [field: SerializeField] public int CostToUnlock { get; private set; } = 0;
    public Protected(bool isLocked, int costToUnlock)
    {
        IsLocked = isLocked;
        CostToUnlock = costToUnlock;
    }

}
