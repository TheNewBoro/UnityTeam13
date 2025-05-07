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
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20); // ���� ���� ��� 0~1�� �����̱� ������ Log10(volume) * 20 ����
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // ���� ���� ��� 0~1�� �����̱� ������ Log10(volume) * 20 ����
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume"); // PlayerPrefs�� �̿��Ͽ� ���� ���� ���� ���
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetVolume();
        SetSFXVolume();
    }
}