
using DG.Tweening;
using UnityEngine;

/// <summary>
/// USE WITH CUSTOM BUTTON SCRIPT
/// </summary>
public class ButtonScaleAnimation : ScaleAnimation
{
    [field:SerializeField] protected ButtonCustomBase _customBase;

    protected override void OnEnable()
    {
        _customBase.OnButtonSelectEvent += Scale;
        _customBase.OnButtonDeselectEvent += UnScale;
    }

    protected override void OnDisable()
    {
        _customBase.OnButtonSelectEvent -= Scale;
        _customBase.OnButtonDeselectEvent -= UnScale;

        if (transform != null)
        {
            transform.DOKill();
        }
    }

    private void OnValidate()
    {
        if (_customBase == null)
        {
            _customBase = GetComponent<ButtonCustomBase>();
        }
    }
}
