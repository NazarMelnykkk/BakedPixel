using System;
using UnityEngine;

public enum InventoryWeightType
{
    Infinite,
    Finite,
}

[Serializable]
public class InventoryWeight
{
    [field: SerializeField] public InventoryWeightType InventoryWeightType = InventoryWeightType.Infinite;
    [field: SerializeField] public float CurrentWeight { get; private set; }
    [field: SerializeField] public float MaxWeight { get; private set; } = 999;

    public InventoryWeight(InventoryWeightType type, float currentWeight = 0, float maxWeight = 999)
    {
        InventoryWeightType = type;
        CurrentWeight = currentWeight;
        MaxWeight = maxWeight;
    }

    public bool Add(float weight)
    {
        if (InventoryWeightType == InventoryWeightType.Infinite)
        {
            CurrentWeight += weight;
            return true;
        }
        else if (InventoryWeightType == InventoryWeightType.Finite)
        {
            if (CurrentWeight + weight <= MaxWeight)
            {
                CurrentWeight += weight;
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public void Remove(float weight)
    {
        CurrentWeight = Mathf.Max(0, CurrentWeight - weight);
    }
}
