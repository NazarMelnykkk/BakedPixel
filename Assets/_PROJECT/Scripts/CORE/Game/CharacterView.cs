using UnityEngine;

public class CharacterView : MonoBehaviour, IDataSave, IDataLoad, IDataInitialize
{
    [field: SerializeField] public CharacterData CharacterData {  get; private set; }
    [field: SerializeField] public InventoryView InventoryView { get;private set; }

    public void Shoot()
    {
        InventoryView.RemoveItemAmountByType();
    }
    public void Initialize()
    {
        CharacterData = CharacterConstructor.GetCharacterDataByConfig();
        InventoryView.Initialize(CharacterData.InventoryData);
    }

    public void LoadData()
    {
        CharacterData = CharacterConstructor.GetCharacterData();
        InventoryView.Initialize(CharacterData.InventoryData);

    }

    public void SaveData()
    {
        CharacterConstructor.SetCharacterData(CharacterData);
    }
}
