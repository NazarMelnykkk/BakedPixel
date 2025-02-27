public static class CharacterConstructor 
{
    public static CharacterData GetCharacterData()
    {
        var gameData = ProjectReferencesContainer.Instance.DataPersistenceHandlerBase.GameData;
        string id = GetCharacterConfig().Id;

        if (gameData.CharacterData.TryGetValue(id, out CharacterData characterData))
        {
            return characterData;
        }
        else
        {
            return GetCharacterDataByConfig();
        }
    }

    public static CharacterData GetCharacterDataByConfig()
    {
        var gameData = ProjectReferencesContainer.Instance.DataPersistenceHandlerBase.GameData;
        string id = GetCharacterConfig().Id;
        var newCharacter = new CharacterData(GetCharacterConfig());
        gameData.CharacterData[id] = newCharacter;

        return newCharacter;
    }

    public static void SetCharacterData(CharacterData characterData)
    {
        ProjectReferencesContainer.Instance.DataPersistenceHandlerBase.GameData.CharacterData[characterData.Id] = characterData;
    }

    private static CharacterConfig GetCharacterConfig()
    {
        return ProjectReferencesContainer.Instance.GlobalDataBase.GetFirstConfigByType<CharacterConfig>();
    }

}
