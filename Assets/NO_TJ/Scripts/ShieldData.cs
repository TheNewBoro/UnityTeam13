using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldData : MonoBehaviour
{
    public int health = 1; // �ǵ� ü��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // ���� ���� �±װ� ���� ������Ʈ�� �浹 ��
        {
            health -= 1;
            if (health <= 0)
            {                
                Destroy(gameObject); // �ǵ� �ı�
            }
        }
    }
}
