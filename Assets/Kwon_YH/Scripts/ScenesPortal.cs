using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� SceneManager ���

public class ScenePortal : MonoBehaviour
{
    [SerializeField] public string sceneToLoad; // �ν����Ϳ��� ������ �� �̸�
    [SerializeField] public float delayBeforeLoad = 0.5f; // �� ��ȯ ���� ��� ��ٸ� �ð� (���� ����)

    private bool isLoading = false; // �ߺ� �� �ε� ������ ���� �÷���

    // �÷��̾ Ʈ���� ������ ������ �� �����
    public void OnTriggerEnter(Collider other)
    {
        // "Player" �±׸� ���� ������Ʈ�� �����ϰ�, ���� �� �ε� ���� �ƴ� ���� ����
        if (!isLoading && other.CompareTag("Player"))
        {
            isLoading = true; // �ߺ� ���� ����
            StartCoroutine(LoadScene()); // �ڷ�ƾ���� �� �ε� ����
        }
    }

    // �� ��ȯ�� �ణ ������Ű�� ���� �ڷ�ƾ
    public System.Collections.IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(delayBeforeLoad); // ������ �ð���ŭ ���
        SceneManager.LoadScene(sceneToLoad); // ������ �̸��� ������ ��ȯ
    }
}
