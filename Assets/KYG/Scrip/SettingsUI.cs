using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UnityEngine.UI 사용한다고 선언
public class SettingsUI : MonoBehaviour
{
    private Animator animator; // UI Animator 컨트롤할 animator 변수 선언

    private void Awake() // 게임 오브젝트가 실행될때 제일 처음 실행되는 Awake
    {
        animator = GetComponent<Animator>();
    }

    public void Close() // 설정창 UI 닫을때 사용
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        Debug.Log("Trigger close activated");
        animator.SetTrigger("close");
        yield return new WaitForSeconds(1f);
        Debug.Log("Deactivating GameObject");
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}

