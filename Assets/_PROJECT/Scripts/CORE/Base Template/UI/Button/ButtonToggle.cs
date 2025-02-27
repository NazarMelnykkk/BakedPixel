using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : ButtonCustomBase
{
    [SerializeField] private List<UIContainerController> _container;

    public override void Click()
    {
        base.Click();

        PlaySound();

        foreach (var container in _container)
        {
            container.Toggle();
        }
    }

    private void PlaySound()
    {
        ProjectReferencesContainer.Instance.AudioHandler.PlaySound(SoundConstants.UICLICK_TYPE, SoundConstants.UICLICK);
    }
}
