using UnityEngine;

public class ObjectSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SoundType _type; 

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
        _audioSource.volume = ProjectReferencesContainer.Instance.AudioHandler.GetVolumeByType(_type);
    }
}
