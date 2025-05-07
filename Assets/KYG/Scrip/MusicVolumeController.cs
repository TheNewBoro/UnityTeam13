using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MusicVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // MainAudioMixer
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;



    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }

        else
        {
            SetVolume();
            SetSFXVolume();
        }

    }

    public void SetVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20); // 볼륨 조절 기능 0~1만 움직이기 때문에 Log10(volume) * 20 조정
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // 볼륨 조절 기능 0~1만 움직이기 때문에 Log10(volume) * 20 조정
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume"); // PlayerPrefs를 이용하여 음악 볼륨 저장 기능
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetVolume();
        SetSFXVolume();
    }
}