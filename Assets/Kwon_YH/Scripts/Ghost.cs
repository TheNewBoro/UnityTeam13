using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //플레이어가 유령과 충돌했을 때 실행됨
        if (other.CompareTag("Player")) // 충돌 대상이 Player 태그라면
        {
            Debug.Log("플레이어 사망!"); // 플레이어 사망 로그 출력
        }
    }
}
