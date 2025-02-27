using System;
using UnityEngine;

[Serializable]
public abstract class ItemPropertiesBase
{

}

[Serializable]
public class ClothingProperties : ItemPropertiesBase
{
    [field: SerializeField] public StatType Stat { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
}

[Serializable]
public class WeaponProperties : ItemPropertiesBase
{
    [field: SerializeField] public StatType Stat { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
    [field: SerializeField] public AmmoType AmmoType { get; private set; }
}

[Serializable]
public class AmmoProperties : ItemPropertiesBase
{
    [field: SerializeField] public AmmoType AmmoType { get; private set; }
}