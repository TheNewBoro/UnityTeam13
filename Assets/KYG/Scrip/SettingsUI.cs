using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UnityEngine.UI ����Ѵٰ� ����
public class SettingsUI : MonoBehaviour
{
    private Animator animator; // UI Animator ��Ʈ���� animator ���� ����

    private void Awake() // ���� ������Ʈ�� ����ɶ� ���� ó�� ����Ǵ� Awake
    {
        animator = GetComponent<Animator>();
    }

    public void Close() // ����â UI ������ ���
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

