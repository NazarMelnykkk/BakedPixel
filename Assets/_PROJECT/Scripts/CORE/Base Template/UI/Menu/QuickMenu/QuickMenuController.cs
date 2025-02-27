using UnityEngine;

public class QuickMenuController : MonoBehaviour
{
    [SerializeField] private UIContainerController _uIContainerController;
    private InputActionConfigBase _config;

    private void OnEnable()
    {
        _config = ProjectReferencesContainer.Instance.InputController.GetActionByType(CharacterAction.Menu);

        if (_config != null)
        {
            _config.OnPerformedEvent += ToggleQuickMenu;
        }
    }

    private void OnDisable()
    {
        if (_config != null)
        {
            _config.OnPerformedEvent -= ToggleQuickMenu;
        }
    }

    private void ToggleQuickMenu()
    {
        _uIContainerController.Toggle();
    }

}
