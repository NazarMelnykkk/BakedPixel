using System;
using UnityEngine;

[Serializable]
public class CharacterData 
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public InventoryData InventoryData { get; private set; }

    public CharacterData(CharacterConfig characterConfig)
    {
        Id = characterConfig.Id;
        InventoryData = new InventoryData(characterConfig.InventoryConfig);
    }

    public CharacterData(string id, InventoryData inventoryData)
    {
        Id = id;
        InventoryData = inventoryData;
    }

}
