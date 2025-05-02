using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoOption : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Dropdowm �ɼ� �� �ֱ� ���� ���� ����
    public Toggle fullscreenToggle; // ��Ŭ ��ư���� ��ũ�� ��� ����

    List<Resolution> resolutions = new List<Resolution>(); // ����Ʈ�� �迭 �ֱ�
    private FullScreenMode currentFullscreenMode;

    void Start()
    {
        InitUI(); // UI �ʱ�ȭ �Լ� ȣ��

    }




    void InitUI()
    {
        // AddRange�Լ� �̿��Ͽ� �����ϴ� �ػ� ����Ʈ�� �ֱ�
        resolutions.AddRange(Screen.resolutions); // Screen.resolutions : ����Ͱ� �����ϴ� �ػ� ������ �迭�� �������

        resolutionDropdown.options.Clear(); // Dropdowm�� �ִ� ���� ���� ����

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Count; i++)
        {
            Resolution res = resolutions[i];
            string optionText = $"{res.width} x {res.height} @ {res.refreshRateRatio.value}Hz";
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(optionText));

            if (res.width == Screen.currentResolution.width &&
                res.height == Screen.currentResolution.height &&
                res.refreshRateRatio.Equals(Screen.currentResolution.refreshRateRatio))
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);

        // ���� ��ü ȭ�� ���� ����
        bool isFullscreen = Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen || Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
        fullscreenToggle.isOn = isFullscreen;
        currentFullscreenMode = isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

        fullscreenToggle.onValueChanged.AddListener(ChangeFullScreenMode);
    }

    void ChangeResolution(int index)
    {
        Resolution selected = resolutions[index];
        Screen.SetResolution(
            selected.width,
            selected.height,
            currentFullscreenMode,
            selected.refreshRateRatio
        );
    }

    void ChangeFullScreenMode(bool isFullscreen)
    {
        currentFullscreenMode = isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;

        // ���� ���õ� �ػ� �ٽ� ����
        ChangeResolution(resolutionDropdown.value);
    }

    void OnDestroy()
    {
        resolutionDropdown.onValueChanged.RemoveListener(ChangeResolution);
        fullscreenToggle.onValueChanged.RemoveListener(ChangeFullScreenMode);
    }
}