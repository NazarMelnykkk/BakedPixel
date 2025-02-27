using System;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryDebugActionType
{
    None = 0,
    Shoot = 1,
    AddAmmo = 2,
    AddItems = 3,
    ClearItems = 4,

}


public class CharacterInventoryDebugController : MonoBehaviour
{
    [field: SerializeField] public CharacterView CharacterView { get; private set; }
    [field: SerializeField] public SerializableDictionary<InventoryDebugActionType, DebugInventoryButton> Buttons { get; private set; } = new();

    [field: SerializeField] private GameObject _buttonHolder;

    public void Awake()
    {
        var buttons = _buttonHolder.GetComponentsInChildren<DebugInventoryButton>();
        foreach (var button in buttons)
        {
            if (Enum.TryParse(button.InventoryDebugActionType.ToString(), out InventoryDebugActionType actionType))
            {
                Buttons[actionType] = button;
            }
        }

        InitializeButtons();
    }

    private void InitializeButtons()
    {
        if (Buttons.TryGetValue(InventoryDebugActionType.Shoot, out var shootButton))
            shootButton.OnButtonClickEvent +=  CharacterView.Shoot;

        if (Buttons.TryGetValue(InventoryDebugActionType.AddAmmo, out var addAmmoButton))
            addAmmoButton.OnButtonClickEvent += () => CharacterView.InventoryView.AddAllItemsByType(new List<ItemType> { ItemType.Ammo });


        if (Buttons.TryGetValue(InventoryDebugActionType.AddItems, out var addItemsButton))
            addItemsButton.OnButtonClickEvent += () => CharacterView.InventoryView.AddRandomItemsByType(new List<ItemType> { ItemType.Weapon, ItemType.Head, ItemType.Body });


        if (Buttons.TryGetValue(InventoryDebugActionType.ClearItems, out var clearItemsButton))
            clearItemsButton.OnButtonClickEvent += CharacterView.InventoryView.RemoveItems;
    }

    private void OnDestroy()
    {
        if (Buttons.TryGetValue(InventoryDebugActionType.Shoot, out var shootButton))
            shootButton.OnButtonClickEvent -=  CharacterView.Shoot;

        if (Buttons.TryGetValue(InventoryDebugActionType.AddAmmo, out var addAmmoButton))
            addAmmoButton.OnButtonClickEvent -= () => CharacterView.InventoryView.AddAllItemsByType(new List<ItemType> { ItemType.Ammo });

        if (Buttons.TryGetValue(InventoryDebugActionType.AddItems, out var addItemsButton))
            addItemsButton.OnButtonClickEvent -= () => CharacterView.InventoryView.AddRandomItemsByType(new List<ItemType> { ItemType.Weapon, ItemType.Head, ItemType.Body });

        if (Buttons.TryGetValue(InventoryDebugActionType.ClearItems, out var clearItemsButton))
            clearItemsButton.OnButtonClickEvent -= CharacterView.InventoryView.RemoveItems;
    }

}
