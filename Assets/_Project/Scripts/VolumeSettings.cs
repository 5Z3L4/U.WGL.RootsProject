using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _totalSlider, _musicSlider, _sfxSlider;

    private void Awake()
    {
        _totalSlider.value = PlayerPrefs.GetFloat("TotalVolume", 0.5f);
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
    }

    private void Start()
    {
        _mixer.SetFloat("TotalVolume", Mathf.Log10(_totalSlider.value) * 20);
        _mixer.SetFloat("MusicVolume", Mathf.Log10(_musicSlider.value) * 20);
        _mixer.SetFloat("SfxVolume", Mathf.Log10(_sfxSlider.value) * 20);
    }
    public void SetSounds()
    {
        float sliderValue = _totalSlider.value;
        _mixer.SetFloat("TotalVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("TotalVolume", sliderValue);
    }

    public void SetMusic()
    {
        float sliderValue = _musicSlider.value;
        _mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFX()
    {
        float sliderValue = _sfxSlider.value;
        _mixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sliderValue);
    }
}
