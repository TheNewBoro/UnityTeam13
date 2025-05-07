using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private Slider expSlider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateLevel(int level)
    {
        levelText.text = $"Level: {level}";
    }

    public void UpdateExperience(int currentExp, int expToLevelUp)
    {
        expText.text = $"EXP: {currentExp} / {expToLevelUp}";
        expSlider.maxValue = expToLevelUp;
        expSlider.value = currentExp;
    }
}
