using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryData 
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public InventoryWeight InventoryWeight { get; private set; }
    [field: SerializeField] public List<SlotData> Slots { get; private set; } = new List<SlotData>();

    public InventoryData(InventoryConfig inventoryConfig)
    {
        Name = inventoryConfig.Name;
        InventoryWeight = inventoryConfig.InventoryWeight;
        GenerateSlots(inventoryConfig.MaxSlots, inventoryConfig.LockedSlots, inventoryConfig.SlotUnlockPrice);
    }

    public InventoryData(string name, InventoryWeight inventoryWeight, List<SlotData> slots)
    {
        Name = name;
        InventoryWeight = inventoryWeight;
        Slots = new List <SlotData>(slots);
    }

    private void GenerateSlots(int maxSlots, int lockedSlots, int slotUnlockPrice)
    {
        int unlockedCount = maxSlots - lockedSlots;

        for (int i = 0; i < maxSlots; i++)
        {
            bool isLocked = i >= unlockedCount;
            Slots.Add(new SlotData(i, new Protected(isLocked, slotUnlockPrice)));
        }
    }

}
