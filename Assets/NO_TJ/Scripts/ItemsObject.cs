using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 먹을 오브젝트에 Player 태그 작성
        {
            Destroy(other.gameObject); // 먹은 오브젝트 삭제
        }
    }
}