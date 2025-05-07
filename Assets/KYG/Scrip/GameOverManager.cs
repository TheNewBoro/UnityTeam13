using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Ÿ��Ʋ ������ �̵�
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title"); // "Title"�� Ÿ��Ʋ �� �̸�
    }

    // ���� ����
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ��� ����
#else
        Application.Quit(); // ����� ���ӿ��� ����
#endif
    }
}
