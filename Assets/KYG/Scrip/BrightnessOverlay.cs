using UnityEngine;
using UnityEngine.UI;

public class BrightnessOverlay : MonoBehaviour
{
    public Slider brightnessSlider;
    public Image overlayImage;

    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
        SetBrightness(brightnessSlider.value); // �ʱ�ȭ
    }

    public void SetBrightness(float value)
    {
        if (overlayImage != null)
        {
            Color c = overlayImage.color;
            c.a = 1f - value; // ��� �� ����
            overlayImage.color = c;
        }
    }
}
