using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterController : MonoBehaviour
{
    [SerializeField] private float meeleeMonsterHP = 1;

    private void Update()
    {
        MonsterDie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("불릿 충돌로 몬스터 체력 감소");
            meeleeMonsterHP--;
        }


    }


    private void MonsterDie()
    {
        if (meeleeMonsterHP <= 0)
        {
            Debug.Log("몬스터 사망으로 삭제");
            Destroy(gameObject);
        }

    }
}
