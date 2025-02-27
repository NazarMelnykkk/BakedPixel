using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QualityControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _qualityLevelDropdown;

    private List<string> _qualityLevels;

    private void OnEnable()
    {
        _qualityLevelDropdown.onValueChanged.AddListener(SetQuality);
    }

    private void OnDisable()
    {
        _qualityLevelDropdown.onValueChanged.RemoveListener(SetQuality);
    }

    private void Start()
    {
        string[] qualityNames = QualitySettings.names;
        _qualityLevels = new List<string>(qualityNames);


        _qualityLevelDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (string qualityLevel in _qualityLevels)
        {
            options.Add(new TMP_Dropdown.OptionData(qualityLevel));
        }

        _qualityLevelDropdown.AddOptions(options);
        _qualityLevelDropdown.value = QualitySettings.GetQualityLevel();
    }

    private void SetQuality(int selectedQualityIndex)
    {
        ProjectReferencesContainer.Instance.GraphicsHandler.SetGraphicsSetting(GraphicType.QualityLevel, selectedQualityIndex, true);
    }
}

