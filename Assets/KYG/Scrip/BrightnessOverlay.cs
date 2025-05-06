using UnityEngine;
using UnityEngine.UI;

public class BrightnessOverlay : MonoBehaviour
{
    public Slider brightnessSlider;
    public Image overlayImage;

    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
        SetBrightness(brightnessSlider.value); // 초기화
    }

    public void SetBrightness(float value)
    {
        if (overlayImage != null)
        {
            Color c = overlayImage.color;
            c.a = 1f - value; // 밝기 값 반전
            overlayImage.color = c;
        }
    }
}
