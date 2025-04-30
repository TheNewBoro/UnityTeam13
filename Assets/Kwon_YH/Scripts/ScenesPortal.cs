using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 SceneManager 사용

public class ScenePortal : MonoBehaviour
{
    [SerializeField] public string sceneToLoad; // 인스펙터에서 지정할 씬 이름
    [SerializeField] public float delayBeforeLoad = 0.5f; // 씬 전환 전에 잠깐 기다릴 시간 (선택 사항)

    private bool isLoading = false; // 중복 씬 로딩 방지를 위한 플래그

    // 플레이어가 트리거 영역에 들어왔을 때 실행됨
    public void OnTriggerEnter(Collider other)
    {
        // "Player" 태그를 가진 오브젝트만 반응하고, 아직 씬 로딩 중이 아닐 때만 실행
        if (!isLoading && other.CompareTag("Player"))
        {
            isLoading = true; // 중복 실행 방지
            StartCoroutine(LoadScene()); // 코루틴으로 씬 로딩 실행
        }
    }

    // 씬 전환을 약간 지연시키기 위한 코루틴
    public System.Collections.IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(delayBeforeLoad); // 설정한 시간만큼 대기
        SceneManager.LoadScene(sceneToLoad); // 지정한 이름의 씬으로 전환
    }
}
