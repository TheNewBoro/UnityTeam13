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
            Debug.Log("�Ҹ� �浹�� ���� ü�� ����");
            meeleeMonsterHP--;
        }


    }


    private void MonsterDie()
    {
        if (meeleeMonsterHP <= 0)
        {
            Debug.Log("���� ������� ����");
            Destroy(gameObject);
        }

    }
}
