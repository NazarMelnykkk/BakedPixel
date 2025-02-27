using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [field: SerializeField] public PlayerInput PlayerInput { get; private set; }

    [field: SerializeField] public List<InputActionConfigBase> InputActions {  get; private set; }
    private Dictionary<CharacterAction, InputActionConfigBase> _actionDictionary;

    [field: SerializeField] public List<InputMapConfig> inputMapConfigs { get; private set; }
    private Dictionary<InputMapType, InputMapConfig> _mapDictionary;

    private void Awake()
    {
        _mapDictionary = new Dictionary<InputMapType, InputMapConfig>();

        foreach (var config in inputMapConfigs)
        {
            if (!_mapDictionary.ContainsKey(config.MapType))
            {
                _mapDictionary[config.MapType] = config;
            }
        }
    }

    private void OnEnable()
    {
        _actionDictionary = new Dictionary<CharacterAction, InputActionConfigBase>();

        foreach (var action in InputActions)
        {
            if (action is IInputAction inputAction)
            {
                inputAction.Initialize();
            }

            if (!_actionDictionary.ContainsKey(action.Action))
            {
                _actionDictionary[action.Action] = action;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var action in InputActions)
        {
            if (action is IInputAction inputAction)
            {
                inputAction.Cleanup();
            }
        }

        _actionDictionary.Clear();
    }

    public InputActionConfigBase GetActionByType(CharacterAction action)
    {
        _actionDictionary.TryGetValue(action, out var config);
        return config;
    }

    //
    public void ChangeInputMap(InputMapType type)
    {
        if (!_mapDictionary.TryGetValue(type, out var config))
        {
            Debug.LogWarning($"InputMapConfig for {type} not found.");
            return;
        }

        foreach (var map in PlayerInput.actions.actionMaps)
        {
            map.Disable();
        }

        var targetMap = PlayerInput.actions.FindActionMap(config.MapType.ToString(), true);
        if (targetMap != null)
        {
            targetMap.Enable();
            Debug.Log($"Activated Input Map: {config.MapType.ToString()}");
        }
        else
        {
            Debug.LogWarning($"InputActionMap with name {config.MapType.ToString()} not found.");
        }
    }



    //Test


    [ContextMenu("ChangeMapOnUI")]
    public void ChangeMapOnUI()
    {
        var type = InputMapType.UI;

        if (!_mapDictionary.TryGetValue(type, out var config))
        {
            Debug.LogWarning($"InputMapConfig for {type} not found.");
            return;
        }

        foreach (var map in PlayerInput.actions.actionMaps)
        {
            map.Disable();
        }

        var targetMap = PlayerInput.actions.FindActionMap(config.MapType.ToString(), true);

        if (targetMap != null)
        {
            targetMap.Enable();
            Debug.Log($"Activated Input Map: {config.MapType.ToString()}");
        }
        else
        {
            Debug.LogWarning($"InputActionMap with name {config.MapType.ToString()} not found.");
        }
    }

    [ContextMenu("ChangeMapOnCharacter")]
    public void ChangeMapOnCharacter()
    {
        var type = InputMapType.Character;

        if (!_mapDictionary.TryGetValue(type, out var config))
        {
            Debug.LogWarning($"InputMapConfig for {type} not found.");
            return;
        }

        foreach (var map in PlayerInput.actions.actionMaps)
        {
            map.Disable();
        }

        var targetMap = PlayerInput.actions.FindActionMap(config.MapType.ToString(), true);

        if (targetMap != null)
        {
            targetMap.Enable();
            Debug.Log($"Activated Input Map: {config.MapType.ToString()}");
        }
        else
        {
            Debug.LogWarning($"InputActionMap with name {config.MapType.ToString()} not found.");
        }
    }

}
