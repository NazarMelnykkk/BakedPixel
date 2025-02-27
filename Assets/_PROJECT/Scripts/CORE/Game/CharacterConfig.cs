using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Character/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public InventoryConfig InventoryConfig { get; private set; }
}
