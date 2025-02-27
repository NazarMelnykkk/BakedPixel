using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData 
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public ItemType Type { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public float ItemWeight { get; private set; }
    [field: SerializeField] public Stackable Stackable { get; private set; }
    [field: SerializeField] public ItemPropertiesBase ItemStatsProperties { get; private set; }

    public ItemData(ItemConfig itemConfig)
    {
        Id = UniqueIDGenerator.GenerateID();
        Name = itemConfig.Name;
        Type = itemConfig.Type;
        Icon = itemConfig.Icon;
        ItemWeight = itemConfig.ItemWeight;
        Stackable = new Stackable(itemConfig.Stackable.IsStackable, itemConfig.Stackable.MaxStackValue, itemConfig.Stackable.Amount);
        ItemStatsProperties = itemConfig.Properties;
    }

    public ItemData(string id, string name, ItemType type, Sprite icon, string description, float itemWeight,
        Stackable stackable, List<ItemPropertiesBase> properties, ItemPropertiesBase itemStatsProperties)
    {
        Id = id;
        Name = name;
        Type = type;
        Icon = icon;

        ItemWeight = itemWeight;
        Stackable = stackable;
        ItemStatsProperties = itemStatsProperties;
    }


}
