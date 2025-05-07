using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoOption : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Dropdowm 옵션 값 넣기 위해 변수 선언
    public Toggle fullscreenToggle; // 토클 버튼으로 스크린 모드 설정

    List<Resolution> resolutions = new List<Resolution>(); // 리스트에 배열 넣기
    private FullScreenMode currentFullscreenMode;

    void Start()
    {
        InitUI(); // UI 초기화 함수 호출

    }




    void InitUI()
    {
        // AddRange함수 이용하여 지원하는 해상도 리스트에 넣기
        resolutions.AddRange(Screen.resolutions); // Screen.resolutions : 모니터가 지원하는 해상도 정보가 배열에 들어있음

        resolutionDropdown.options.Clear(); // Dropdowm에 있는 기존 정보 제거

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

        // 현재 전체 화면 상태 설정
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

        // 현재 선택된 해상도 다시 적용
        ChangeResolution(resolutionDropdown.value);
    }

    void OnDestroy()
    {
        resolutionDropdown.onValueChanged.RemoveListener(ChangeResolution);
        fullscreenToggle.onValueChanged.RemoveListener(ChangeFullScreenMode);
    }
}