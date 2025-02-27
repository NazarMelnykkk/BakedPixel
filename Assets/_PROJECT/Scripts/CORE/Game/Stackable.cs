using System;
using UnityEngine;

[Serializable]
public class Stackable
{
    [field: SerializeField] public bool IsStackable { get; private set; } = false;
    [field: SerializeField] public int Amount { get; private set; } = 1;
    [field: SerializeField] public int MaxStackValue { get; private set; } = 1;
    [field: SerializeField] public Action OnValueChangeEvent { get; set; }

    public Stackable(bool isStackable, int maxStackValue = 1, int amount = 1)
    {
        IsStackable = isStackable;
        MaxStackValue = maxStackValue;
        Amount = amount;
    }

    public bool CanAdd(int count) => IsStackable && (Amount + count) <= MaxStackValue;

    public bool CanRemove(int count) => (Amount - count) >= 0;

    public void Add(int count)
    {
        if (CanAdd(count))
        {
            Amount += count;
            OnValueChangeEvent?.Invoke();
        }
    }

    public void Remove(int count)
    {
        if (CanRemove(count))
        {
            Amount -= count;
            OnValueChangeEvent?.Invoke();
        }
    }
}