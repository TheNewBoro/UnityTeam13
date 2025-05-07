using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterController : MonoBehaviour
{
    [SerializeField] private float meleeMonsterHP = 1;
    private bool isDead = false;

    public float dropRate = 0.1f; // ��� Ȯ�� 
    public GameObject itemPrefab; // ����� ������ ������

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
            Debug.Log("�Ҹ� �浹�� ���� ü�� ����");
            meleeMonsterHP--;
        }
    }


    private void MonsterDie()
    {
        if (meleeMonsterHP <= 0)
        {
            isDead = true;
            
            GameManager.Instance.AddScore(1);
            Debug.Log("���͸� óġ�Ͽ� <color=#0000ffff>���ھ� 1�� �߰�</color>");

            GameObject player = GameObject.FindWithTag("Player");
            if (player!=null)
            {
                player.GetComponent<PlayerController>().GainExperience(5);
            }

            DropItem();
            Debug.Log("������ ���");
            Destroy(gameObject);
            Debug.Log("���� ������� ����");
        }
    }



    void DropItem()
    {
        float rand = Random.Range(0f, 1f);
        if (rand <= dropRate)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
