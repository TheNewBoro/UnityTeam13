using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LodingScene : MonoBehaviour
{
    static string nextScene;

    [SerializeField] private Image progressBar;
    [SerializeField] private TMP_Text loadingText;      // 로딩 중 표시용
    [SerializeField] private TMP_Text continueText;      // "아무 키나 누르세요"

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loding Scene");
    }

    void Start()
    {
        if (string.IsNullOrEmpty(nextScene))
        {
            // Debug.LogError("nextScene 값이 설정되지 않았습니다! LoadScene()을 통해 로딩씬으로 진입하세요.");
            return;
        }

        if (progressBar == null || loadingText == null || continueText == null)
        {
            // Debug.LogError("UI 컴포넌트가 누락되었습니다! 인스펙터에서 연결하세요.");
            return;
        }

        continueText.gameObject.SetActive(false);
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f; // 반복문
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress; // 로딩 진행도 표시
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer / 2f);

                if (progressBar.fillAmount >= 1f)
                {
                    loadingText.text = "그래도 재밌게 즐겨주세요!";
                    continueText.gameObject.SetActive(true);
                    break;
                }
            }
        }

        // 대기 상태: 키 입력 기다림
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        op.allowSceneActivation = true;
    }
}
