using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    // 충돌한 오브젝트가 플레이어일 경우 게임 오버 씬으로 전환
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // "GameOverScene"을 실제 씬 이름으로 바꾸세요
            SceneManager.LoadScene("GameOver Scene");
        }
    }
}
