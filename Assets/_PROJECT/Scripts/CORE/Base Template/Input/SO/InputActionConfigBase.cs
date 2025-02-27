using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

// make more ACTION variant
[CreateAssetMenu(fileName = "InputAction", menuName = "InputAction/InputActionConfig")]
public class InputActionConfigBase : ScriptableObject, IInputAction
{
    [field: SerializeField] public CharacterAction Action { get; private set; }
    [field: SerializeField] public InputActionReference InputReference { get; private set; }
    [field: SerializeField] public Action OnPerformedEvent;

    public void Initialize()
    {
        InputReference.action.performed += ctx => OnPerformedEvent?.Invoke();
    }

    public void Cleanup()
    {
        InputReference.action.performed -= ctx => OnPerformedEvent?.Invoke();
    }
}
