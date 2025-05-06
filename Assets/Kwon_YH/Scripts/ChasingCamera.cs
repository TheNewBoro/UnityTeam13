using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    public Transform target;      // ���� ���
    public Vector3 offset;        // ��ġ ������

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
