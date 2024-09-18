

using UnityEngine;
using UnityEngine.UI;

public class AudioScreen : MonoBehaviour
{
    [SerializeField]
    private Slider m_MusicVolumeSlider;
    [SerializeField]
    private Slider m_EffectsVolumeSlider;

    private void Start()
    {
        m_MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        m_EffectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);

        m_MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        m_EffectsVolumeSlider.onValueChanged.AddListener(OnEffectsVolumeChange);
    }

    private void OnMusicVolumeChange(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        AudioManager.Instance.SetMusicVolume(value);
    }

    private void OnEffectsVolumeChange(float value)
    {
        PlayerPrefs.SetFloat("EffectsVolume", value);
    }
}
