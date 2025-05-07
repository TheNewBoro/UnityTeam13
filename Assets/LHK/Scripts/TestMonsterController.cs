using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterController : MonoBehaviour
{
    [SerializeField] private float meleeMonsterHP = 1;
    private bool isDead = false;

    private void Update()
    {
        if(!isDead)
        {
        MonsterDie();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("불릿 충돌로 몬스터 체력 감소");
            meleeMonsterHP--;
        }


    }


    private void MonsterDie()
    {
        if (meleeMonsterHP <= 0)
        {
            isDead = true;
            
            GameManager.Instance.AddScore(1);
            Debug.Log("몬스터를 처치하여 <color=#0000ffff>스코어 1점 추가</color>");

            GameObject player = GameObject.FindWithTag("Player");
            if (player!=null)
            {
                player.GetComponent<PlayerController>().GainExperience(5);
            }

            Destroy(gameObject);
            Debug.Log("몬스터 사망으로 삭제");
        }
    }
}
