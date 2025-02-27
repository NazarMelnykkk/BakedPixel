using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceHandlerBase : MonoBehaviour
{
    public GameData GameData;
    protected FileDataHandler _fileDataHandler;
    protected string CurrentProfileID = "Plague.json";

    protected virtual void Awake()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, CurrentProfileID);
    }

    protected virtual void Start()
    {
        LoadGame();

        ProjectReferencesContainer.Instance.SceneLoader.OnSceneLoadEvent += LoadGame;
        ProjectReferencesContainer.Instance.SceneLoader.OnSceneUnloadEvent += SaveGame;
    }

    protected virtual void NewGame()
    {
        GameData = new GameData();

        foreach (IDataInitialize dataPersistenceObject in FindAllDataPersistenceObjects<IDataInitialize>())
        {
            dataPersistenceObject.Initialize();
        }
    }

    public virtual void LoadGame()
    {
        GameData = _fileDataHandler.Load(CurrentProfileID);

        if (GameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded. profile id");
            NewGame();
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in FindAllDataPersistenceObjects<IDataPersistence>())
        {
            dataPersistenceObject.LoadData(GameData); 
        }

        foreach (IDataLoad dataPersistenceObject in FindAllDataPersistenceObjects<IDataLoad>())
        {
            dataPersistenceObject.LoadData(); 
        }

        Debug.Log("Game Loaded");
    }

    [ContextMenu("SAVE")]
    public virtual void SaveGame()
    {
        if (GameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be saved");
            return;
        }

        foreach (IDataPersistence dataPersistenceObject in FindAllDataPersistenceObjects<IDataPersistence>())
        {
            dataPersistenceObject.SaveData(GameData); 
        }

        foreach (IDataSave dataPersistenceObject in FindAllDataPersistenceObjects<IDataSave>())
        {
            dataPersistenceObject.SaveData(); 
        }

        _fileDataHandler.Save(GameData, CurrentProfileID);

    }

    protected virtual void OnApplicationQuit()
    {
        SaveGame();
    }

    protected virtual List<T> FindAllDataPersistenceObjects<T>() where T : class
    {
        IEnumerable<T> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<T>();
        return new List<T>(dataPersistenceObjects);
    }

    protected virtual bool HasGameData()
    {
        return GameData != null;
    }


    protected virtual Dictionary<string, GameData> GetAllprofilesGameData()
    {
        return _fileDataHandler.LoadAllProfiles();
    }
}
