using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ���� ������Ʈ�� Player �±� �ۼ�
        {
            Destroy(other.gameObject); // ���� ������Ʈ ����
        }
    }
}