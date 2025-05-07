using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldData : MonoBehaviour
{
    public int health = 1; // 실드 체력

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // 몬스터 공격 태그가 붙은 오브젝트와 충돌 시
        {
            health -= 1;
            if (health <= 0)
            {                
                Destroy(gameObject); // 실드 파괴
            }
        }
    }
}
