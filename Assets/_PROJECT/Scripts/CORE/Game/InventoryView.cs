using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public InventoryData InventoryData { get; private set; }
    [field: SerializeField] public List<SlotView> Slots { get; private set; } = new List<SlotView>();
    [field: SerializeField] public SerializableDictionary<int, SlotView> SlotsDictionary { get; private set; } = new SerializableDictionary<int, SlotView>();

    private static readonly System.Random RandomGenerator = new System.Random();

    public void Initialize(InventoryData inventoryData)
    {
        InventoryData = inventoryData;
        CreateSlots();
    }

    public void CreateSlots()
    {
        var slotPrefab = ProjectReferencesContainer.Instance.GlobalDataBase.SlotViewPrefab;

        for (int i = 0; i < InventoryData.Slots.Count; i++)
        {
            var slotInstance = Instantiate(slotPrefab, transform);
            slotInstance.Initialize(InventoryData.Slots[i]);
            Slots.Add(slotInstance);
            SlotsDictionary[i] = slotInstance;
        }
    }

    public void AddItemToInventory(ItemData itemData)
    {
        SlotView emptySlot = GetFirstEmptySlot();
        if (emptySlot != null)
        {
            emptySlot.AddItem(itemData);
            int slotIndex = emptySlot.SlotData.SlotID;
            InventoryData.Slots[slotIndex].ItemData = itemData;  
        }
    }

    public void RemoveItemFromInventory(ItemData itemData)
    {
        SlotView filledSlot = GetSlotWithItem(itemData);
        if (filledSlot != null)
        {
            filledSlot.RemoveItem();
            int slotIndex = filledSlot.SlotData.SlotID;
            InventoryData.Slots[slotIndex].ItemData = null;  
        }
    }

    public void AddRandomItemsByType(List<ItemType> types)
    {
        foreach (ItemType type in types)
        {
            var randomItem = ProjectReferencesContainer.Instance.GlobalDataBase.GetRandomConfigByType<ItemConfig>(type);
            if (randomItem != null)
            {
                AddItemToInventory(new ItemData(randomItem));
            }
        }
    }

    public void AddAllItemsByType(List<ItemType> types)
    {
        foreach (ItemType type in types)
        {
            var randomItems = ProjectReferencesContainer.Instance.GlobalDataBase.GetAllConfigByType<ItemConfig>(type);
            if (randomItems.Count > 0)
            {
                foreach (var item in randomItems)
                {
                    AddItemToInventory(new ItemData(item));
                }
            }
        }
    }

    public void RemoveItems()
    {
        var filledSlots = Slots.FindAll(slot => !slot.IsEmpty());
        if (filledSlots.Count > 0)
        {
            foreach(var slot in filledSlots)
            {
                slot.RemoveItem();
                int slotIndex = slot.SlotData.SlotID;
                InventoryData.Slots[slotIndex].ItemData = null;
            }
        }
        else
        {
            Debug.LogError("There are no items available for cleaning.");
        }
    }

    private SlotView GetFirstEmptySlot()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].CanAddItem())
            {
                return Slots[i];
            }
        }

        return null;
    }

    private SlotView GetSlotWithItem(ItemData itemData)
    {
        foreach (var slot in Slots)
        {
            if (slot.ContainsItem(itemData))
            {
                return slot;
            }
        }

        return null;
    }

    public void RemoveItemAmountByType(ItemType type = ItemType.Ammo, int amountToRemove = 1)
    {
        var itemsOfType = new List<SlotView>();

        foreach (var slot in Slots)
        {
            if (!slot.IsEmpty() && slot.SlotData.ItemData.Type == type)
            {
                itemsOfType.Add(slot);
            }
        }

        if (itemsOfType.Count == 0)
        {
            return;
        }


        SlotView selectedSlot = itemsOfType[RandomGenerator.Next(0, itemsOfType.Count)];
        ItemData selectedItemData = selectedSlot.SlotData.ItemData;

        if (selectedItemData.Stackable.IsStackable)
        {
            if (selectedItemData.Stackable.CanRemove(amountToRemove))
            {
                selectedItemData.Stackable.Remove(amountToRemove);
            }
            else
            {
                int amountRemoved = selectedItemData.Stackable.Amount;
                selectedItemData.Stackable.Remove(amountRemoved);
            }

            if (selectedItemData.Stackable.Amount == 0)
            {
                selectedSlot.RemoveItem();
                InventoryData.Slots[selectedSlot.SlotData.SlotID].ItemData = null;
            }
        }
        else
        {
            selectedSlot.RemoveItem();
            InventoryData.Slots[selectedSlot.SlotData.SlotID].ItemData = null; 
        }
    }

}
