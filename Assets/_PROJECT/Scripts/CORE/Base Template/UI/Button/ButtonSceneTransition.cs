using UnityEngine;

public class ButtonSceneTransition : ButtonCustomBase
{
    [SerializeField] private SceneConfig _sceneToTransition;

    public override async void Click()
    {
        base.Click();

        await ProjectReferencesContainer.Instance.SceneLoader.Transition(_sceneToTransition.SceneName, gameObject.scene.name);
        PlaySound();
    }

    private void PlaySound()
    {
        ProjectReferencesContainer.Instance.AudioHandler.PlaySound(SoundConstants.UICLICK_TYPE, SoundConstants.UICLICK);
    }
}
