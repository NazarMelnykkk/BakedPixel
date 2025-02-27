using UnityEngine;

public class LoopMusicController : MonoBehaviour
{
    [SerializeField] private SoundConfig _soundConfig;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        PlaySound(_soundConfig);
    }

    public void PlaySound(SoundConfig soundConfig)
    {
        ProjectReferencesContainer.Instance.AudioHandler.PlaySound(soundConfig, _audioSource);
    }

    private void OnEnable()
    {
        ProjectReferencesContainer.Instance.AudioHandler.VolumeValueChanged += ChangeSoundVolume;
    }

    private void OnDisable()
    {
        ProjectReferencesContainer.Instance.AudioHandler.VolumeValueChanged -= ChangeSoundVolume;
    }

    private void ChangeSoundVolume()
    {
        _audioSource.volume = ProjectReferencesContainer.Instance.AudioHandler.GetVolumeByType(_soundConfig.Sound.Type);
    }
}
