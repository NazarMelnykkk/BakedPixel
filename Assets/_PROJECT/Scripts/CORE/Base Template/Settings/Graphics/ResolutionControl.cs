using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionDropdown;

    private Resolution[] _availableResolutions;
    private List<Resolution> _filteredResolutions;

    private int _currentResolutionIndex = 0;

    private void OnEnable()
    {
        _resolutionDropdown.onValueChanged.AddListener(SetResolution);

    }

    private void OnDisable() 
    {
        _resolutionDropdown.onValueChanged.RemoveListener(SetResolution);
    }

    private void Start()
    {
        _availableResolutions = Screen.resolutions;
        _filteredResolutions = new List<Resolution>();

        _resolutionDropdown.ClearOptions();

        int currentRefreshRate = Mathf.RoundToInt((float)Screen.currentResolution.refreshRateRatio.numerator / Screen.currentResolution.refreshRateRatio.denominator);

        foreach (var resolution in _availableResolutions)
        {
            int refreshRate = Mathf.RoundToInt((float)resolution.refreshRateRatio.numerator / resolution.refreshRateRatio.denominator);
            if (refreshRate == currentRefreshRate)
            {
                _filteredResolutions.Add(resolution);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < _filteredResolutions.Count; i++)
        {
            var resolution = _filteredResolutions[i];
            int refreshRate = Mathf.RoundToInt((float)resolution.refreshRateRatio.numerator / resolution.refreshRateRatio.denominator);
            string resolutionOption = $"{resolution.width}x{resolution.height} {refreshRate}Hz";
            options.Add(resolutionOption);

            if (resolution.width == Screen.width && resolution.height == Screen.height)
            {
                _currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = _currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    private void SetResolution(int selectedResolutionIndex)
    {
        ProjectReferencesContainer.Instance.GraphicsHandler.SetGraphicsSetting(GraphicType.Resolution, selectedResolutionIndex, true);
     
    }
}
