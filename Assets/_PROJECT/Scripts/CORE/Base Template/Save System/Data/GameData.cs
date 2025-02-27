[System.Serializable]
public class GameData
{
    public SettingData SettingData;
    public SerializableDictionary<string, CharacterData> CharacterData;

    public GameData()
    {
        SettingData = new SettingData();
        CharacterData = new SerializableDictionary<string, CharacterData>();

    }
}