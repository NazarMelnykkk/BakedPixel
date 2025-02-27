using UnityEngine;

public class DebugInventoryButton : ButtonCustomBase
{
    [field: SerializeField] public InventoryDebugActionType InventoryDebugActionType {  get; private set; }
}
