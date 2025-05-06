using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LodingScene : MonoBehaviour
{
    static string nextScene;

    [SerializeField] private Image progressBar;
    [SerializeField] private TMP_Text loadingText;      // �ε� �� ǥ�ÿ�
    [SerializeField] private TMP_Text continueText;      // "�ƹ� Ű�� ��������"

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loding Scene");
    }

    void Start()
    {
        if (string.IsNullOrEmpty(nextScene))
        {
            // Debug.LogError("nextScene ���� �������� �ʾҽ��ϴ�! LoadScene()�� ���� �ε������� �����ϼ���.");
            return;
        }

        if (progressBar == null || loadingText == null || continueText == null)
        {
            // Debug.LogError("UI ������Ʈ�� �����Ǿ����ϴ�! �ν����Ϳ��� �����ϼ���.");
            return;
        }

        continueText.gameObject.SetActive(false);
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer / 2f);

                if (progressBar.fillAmount >= 1f)
                {
                    loadingText.text = "Loading complete!";
                    continueText.gameObject.SetActive(true);
                    break;
                }
            }
        }

        // ��� ����: Ű �Է� ��ٸ�
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        op.allowSceneActivation = true;
    }
}
