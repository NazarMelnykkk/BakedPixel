using System;
using UnityEngine;

public enum ItemType
{
    None = 0,

    Head = 1,
    Body = 2,
    Weapon = 3,
    Ammo = 4,
}

public enum AmmoType
{
    None = 0,
    Rifle = 1,
    Pistol = 2,
}

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Character/Item/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public ItemType Type { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public float ItemWeight { get; private set; }
    [field: SerializeField] public Stackable Stackable { get; private set; }
    [field: SerializeReference, SubclassSelector] public ItemPropertiesBase Properties { get; private set; }


    public void OnValidate()
    {
        if (name != Name)
        {
            Debug.Log($"Name doesn't match", this);
            Name = name;
        }

        if (Id == "")
        {
            Id = UniqueIDGenerator.GenerateID();
        }
    }
}