using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    public Transform target;      // 따라갈 대상
    public Vector3 offset;        // 위치 오프셋

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
