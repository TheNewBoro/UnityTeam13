using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float dropRate = 0.1f; // ��� Ȯ�� 
    public GameObject itemPrefab; // ����� ������ ������
    [SerializeField] private float meeleeMonsterHP = 1;

    private void Update()
    {
        MonsterDie();
    }
    private void MonsterDie()
    {
        if (meeleeMonsterHP <= 0)
        {
            Debug.Log("���� ������� ����");
            Destroy(gameObject);
            DropItem();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("�Ҹ� �浹�� ���� ü�� ����");
            meeleeMonsterHP--;
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
