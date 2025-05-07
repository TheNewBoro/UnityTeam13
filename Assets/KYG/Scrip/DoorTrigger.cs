using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    // �浹�� ������Ʈ�� �÷��̾��� ��� ���� ���� ������ ��ȯ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // "GameOverScene"�� ���� �� �̸����� �ٲټ���
            SceneManager.LoadScene("GameOver Scene");
        }
    }
}
