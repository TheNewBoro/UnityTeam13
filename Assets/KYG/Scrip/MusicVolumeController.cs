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

        // ����� �� �ҷ����� (�ɼ�)
        //float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        //musicSlider.value = savedVolume;
       //SetVolume(savedVolume);
    }

    public void SetVolume(float value)
    {
        // dB ������ ��ȯ: -80 = ����, 0 = �ִ�
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat(exposedParam, dB);

        // ���� (�ɼ�)
        //PlayerPrefs.SetFloat("MusicVolume", value);
    }
}