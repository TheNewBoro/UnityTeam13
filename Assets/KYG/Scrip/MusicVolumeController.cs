using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeController : MonoBehaviour
{
    public Slider musicSlider;
    public AudioMixer audioMixer; // MainAudioMixer
    private const string exposedParam = "BGMVolume";

    void Start()
    {
        GetComponent<AudioSource>().Play();
        musicSlider.onValueChanged.AddListener(SetVolume);

        // 저장된 값 불러오기 (옵션)
        //float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        //musicSlider.value = savedVolume;
       //SetVolume(savedVolume);
    }

    public void SetVolume(float value)
    {
        // dB 단위로 변환: -80 = 무음, 0 = 최대
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat(exposedParam, dB);

        // 저장 (옵션)
        //PlayerPrefs.SetFloat("MusicVolume", value);
    }
}