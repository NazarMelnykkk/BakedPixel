using UnityEngine;

[CreateAssetMenu(fileName = "InputMapConfig", menuName = "InputAction/InputMapConfig")]
public class InputMapConfig : ScriptableObject
{
    [field: SerializeField] public InputMapType MapType { get; private set; }
}
