using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾ ���ɰ� �浹���� �� �����
        if (other.CompareTag("Player")) // �浹 ����� Player �±׶��
        {
            Debug.Log("�÷��̾� ���!"); // �÷��̾� ��� �α� ���
        }
    }
}
