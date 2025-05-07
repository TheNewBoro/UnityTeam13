using UnityEngine;
using TMPro;  // TextMeshPro ��� �� �ʿ�

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

        // �ʹ� ������� �ʱ�ȭ
        if (log.Length > 1000)
            log = "";
    }
}
