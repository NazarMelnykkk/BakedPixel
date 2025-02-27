using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public enum ResourceType
{
    Character,
    Inventory,
    Item
}

public class GlobalDataBase : MonoBehaviour
{
    [Tooltip("RESOURCES PATHS")]
    private readonly Dictionary<ResourceType, string> _resourcePaths = new()
    {
        { ResourceType.Character, "Assets/_PROJECT/Configs/GAME/Character" },
        { ResourceType.Inventory, "Assets/_PROJECT/Configs/GAME/Inventory" },
        { ResourceType.Item, "Assets/_PROJECT/Configs/GAME/Item" }
    };

    private readonly Dictionary<ResourceType, List<ScriptableObject>> _configData = new();
    private readonly Dictionary<string, ScriptableObject> _configDictionary = new();

    [field: SerializeField] public ItemView ItemViewPrefab { get; set; }
    [field: SerializeField] public SlotView SlotViewPrefab { get; set; }

    private static readonly System.Random RandomGenerator = new System.Random();

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        _configDictionary.Clear();
        foreach (var dataList in _configData.Values)
        {
            foreach (var config in dataList)
            {
                if (config != null)
                    _configDictionary[config.name] = config;
            }
        }
    }

    public T GetConfigByName<T>(string name) where T : ScriptableObject
    {
        return _configDictionary.TryGetValue(name, out var config) ? config as T : null;
    }

    public T GetFirstConfigByType<T>() where T : ScriptableObject
    {
        return _configData.Values
            .SelectMany(dataList => dataList)
            .OfType<T>()
            .FirstOrDefault();
    }

    public T GetRandomConfigByType<T>(ItemType type) where T : ScriptableObject
    {
        var matchingConfigs = _configData.Values
            .SelectMany(dataList => dataList)
            .OfType<T>()
            .Where(config => config is ItemConfig item && item.Type == type)
            .ToList();

        if (matchingConfigs.Count == 0)
            return null;

        int randomIndex = RandomGenerator.Next(0, matchingConfigs.Count);
        return matchingConfigs[randomIndex];
    }

    public List<T> GetAllConfigByType<T>(ItemType type) where T : ScriptableObject
    {
        var matchingConfigs = _configData.Values
            .SelectMany(dataList => dataList)
            .OfType<T>()
            .Where(config => config is ItemConfig item && item.Type == type)
            .ToList();

        return matchingConfigs; 
    }

    private void OnValidate()
    {
        LoadItemsFromResources();
    }

    private void LoadItemsFromResources()
    {
#if UNITY_EDITOR
        _configData.Clear();

        foreach (var (type, path) in _resourcePaths)
        {
            string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { path });
            var configList = guids
                .Select(guid => AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToList();

            _configData[type] = configList;
        }

        InitializeDictionary();
#endif
    }
}

