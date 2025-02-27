public interface IDataPersistence
{
    public void SaveData(GameData data);
    public void LoadData(GameData data);

}

public interface IDataSave
{
    public void SaveData();
}

public interface IDataLoad
{
    public void LoadData();
}

public interface IDataInitialize
{
    public void Initialize();
}

