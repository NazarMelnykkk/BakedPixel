using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VSynceControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _vSynceModeDropdown;


    private void OnEnable()
    {
        _vSynceModeDropdown.onValueChanged.AddListener(SetVSynce);
    }

    private void OnDisable()
    {
        _vSynceModeDropdown.onValueChanged.RemoveListener(SetVSynce);
    }

    private void Start()
    {
        List<TMP_Dropdown.OptionData> VSyncenOptions = new List<TMP_Dropdown.OptionData>();
        VSyncenOptions.Add(new TMP_Dropdown.OptionData("Enable"));
        VSyncenOptions.Add(new TMP_Dropdown.OptionData("Disable"));

        _vSynceModeDropdown.options = VSyncenOptions;

        _vSynceModeDropdown.value = QualitySettings.vSyncCount;
    }

    private void SetVSynce(int selectedVSynceIndex)
    {
        ProjectReferencesContainer.Instance.GraphicsHandler.SetGraphicsSetting(GraphicType.VSync, selectedVSynceIndex, true);
    }
}
