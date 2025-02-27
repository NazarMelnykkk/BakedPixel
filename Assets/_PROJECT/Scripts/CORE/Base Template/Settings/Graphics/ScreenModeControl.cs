using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenModeControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _screenModeDropdown;


    private void OnEnable()
    {
        _screenModeDropdown.onValueChanged.AddListener(SetScreenMode);
    }

    private void OnDisable()
    {
        _screenModeDropdown.onValueChanged.RemoveListener(SetScreenMode);
    }

    private void Start()
    { 
        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();
        dropdownOptions.Add(new TMP_Dropdown.OptionData("FullScreen"));
        dropdownOptions.Add(new TMP_Dropdown.OptionData("Maximized"));
        dropdownOptions.Add(new TMP_Dropdown.OptionData("Windowed"));

        _screenModeDropdown.options = dropdownOptions;
    }

    private void SetScreenMode(int selectedScreenModeIndex)
    {
        ProjectReferencesContainer.Instance.GraphicsHandler.SetGraphicsSetting(GraphicType.ScreenMode, selectedScreenModeIndex, true);
    }
}
