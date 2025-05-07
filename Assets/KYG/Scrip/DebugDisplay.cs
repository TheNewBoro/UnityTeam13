using UnityEngine;
using TMPro;  // TextMeshPro 사용 시 필요

public class DebugDisplay : MonoBehaviour
{
    public static DebugDisplay Instance;
    public TextMeshProUGUI debugText;
    private string log = "";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Print(string message)
    {
        log += message + "\n";
        debugText.text = log;

        // 너무 길어지면 초기화
        if (log.Length > 1000)
            log = "";
    }
}
