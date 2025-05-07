using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // 타이틀 씬으로 이동
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title"); // "Title"은 타이틀 씬 이름
    }

    // 게임 종료
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 종료
#else
        Application.Quit(); // 빌드된 게임에서 종료
#endif
    }
}
